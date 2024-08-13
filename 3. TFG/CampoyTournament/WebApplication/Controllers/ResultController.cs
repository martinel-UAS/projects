using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomainEntities;
using WebApplication.Models;
using DomainServices;
using WebApplication.Attributes;
using WebApplication.Models.Result;
using WebApplication.Managers;
using WebApplication.Models.Player;
using WebApplication.Models.Field;

namespace WebApplication.Controllers
{
    public class ResultController : Controller
    {
        #region Fields

        private readonly UserService _userService;
        private readonly PlayerService _playerService;
        private readonly FieldService _fieldService;
        private readonly HoleService _holeService;
        private readonly MatchService _matchService;
        private readonly ResultService _resultService;

        #endregion

        #region Constructors

        public ResultController(UserService userService, PlayerService playerService, FieldService fieldService,
                                HoleService holeService, MatchService matchService, ResultService resultService)
        {
            this._userService = userService;
            this._playerService = playerService;
            this._fieldService = fieldService;
            this._holeService = holeService;
            this._matchService = matchService;
            this._resultService = resultService;
        }

        #endregion

        #region Methods

        [LogonAuthorize]
        public ActionResult Index()
        {
            //Get matches with results and matches without results
            ResultViewModel model = new ResultViewModel()
            {
                AvailableResults = GetAvailableResults(),
                AvailableMatches = GetAvailableMatches()
            };
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a result list from database</summary>       ///
        /// <param name="id">MatchId</param>                                          ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Logged Users only</permission>                                ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [LogonAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null) throw new HttpException(404, "");
            //get match from database
            Match match = _matchService.GetMatchById((int)id);
            if (match == null) throw new HttpException("Match " + id + " not found");

            //get field from database
            var field = _fieldService.GetFieldByIdDeletedOrNot(match.FieldId);
            if (field == null) throw new HttpException("Field " + match.FieldId + " not found");

            //get holes from database 
            var holes = _holeService.GetAllFieldHolesOrderBy(field.Id, "Id");

            //get results of the selected match
            string whereClause = "MatchId = " + id;
            var results = _resultService.GetAllResultsOrderBy(whereClause, "Id");

            //get players using LinQ
            var players = from p in results
                          group p by p.PlayerId;

            var scoreCard = new PlayerScoreCardModel();
            var model = new MatchScoreCardModel();
            model.ScoreCards = new List<PlayerScoreCardModel>();

            foreach (var p in players)
            {
                var player = _playerService.GetPlayerByIdDeletedOrNot(p.Key);
                var user = _userService.GetUserByPlayerIdDeletedOrNot(p.Key);

                scoreCard = new PlayerScoreCardModel() { PlayerLicense = player.License, PlayerName = user.Name, PlayerGameHP = player.GameHP };
                scoreCard.ScoreCard = new List<HoleViewModel>();

                foreach (var hole in holes)
                {
                    var result = _resultService.GetResultByMatchHolePlayer(match.Id, hole.Id, p.Key, "Id");

                    scoreCard.ScoreCard.Add(new HoleViewModel()
                    {                        
                        HoleId = hole.Id,
                        SelectedStrikes = result.Strikes,
                        StablefordPoints = result.StableFordPoints
                    });

                    scoreCard.TotalStableFordPoints = result.StableFordPoints + scoreCard.TotalStableFordPoints;
                    scoreCard.TotalStrikes = result.Strikes + scoreCard.TotalStrikes;
                }

                model.ScoreCards.Add(scoreCard);
          
            }

            var sortedList = model.ScoreCards.OrderBy(m => -1 * m.TotalStableFordPoints)
                             .ToList();

            model = new MatchScoreCardModel() { Date = match.Date, FieldName = field.Name, ScoreCards = sortedList };


            //send viewmodel into UI (View)
            return View(model);
        }

        // GET: /Result/Create
        [HttpPost]
        public ActionResult Create(int? id, int? numberOfPlayers)
        {
            if (id == null || numberOfPlayers == null) throw new HttpException(404, "");
            //get match from database
            Match match = _matchService.GetMatchById((int)id);
            if (match == null) throw new HttpException("Match " + id + " not found");

            //get field from database
            Field field = _fieldService.GetFieldById(match.FieldId);

            //get holes from database
            IEnumerable<Hole> holes = from h in _holeService.GetAllHolesOrderBy("Id")
                                      where h.FieldId == field.Id
                                      select h;

            //get players from db
            var players = _playerService.GetAllPlayer();

            var scoreCards = new List<PlayerScoreCardModel>();

            //rellenar el modelo para resultados
            for (var i = 0; i < numberOfPlayers; i++)
            {
                var result = new List<HoleViewModel>();

                foreach (Hole hole in holes)
                {
                    result.Add(new HoleViewModel()
                    {
                        HoleId = hole.Id
                    });
                }

                var scoreCard = new PlayerScoreCardModel()
                           {
                               ScoreCard = result,
                               Players = GetAvailablePlayers()
                           };

                scoreCards.Add(scoreCard);
            }

            var model = new MatchScoreCardModel() { MatchId = match.Id, ScoreCards = scoreCards };

            return View(model);
        }

        // POST: /Result/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(MatchScoreCardModel model)
        {
            if (ModelState.IsValid)
            {
                if (!ModelIsValid(model))
                {
                    ModelState.AddModelError("", "Los jugadores estan repetidos");
                    for (var i = 0; i < model.ScoreCards.Count; i++)
                    {
                        model.ScoreCards[i].Players = GetAvailablePlayers();
                    }
                    return View("Create", model);
                }
                else
                {                    
                    //get match
                    var match = _matchService.GetMatchById(model.MatchId);

                    foreach (var scoreCard in model.ScoreCards)
                    {
                        FieldViewModel fm = new FieldViewModel()
                        {
                            Id = match.FieldId,
                            Name = _fieldService.GetFieldById(match.FieldId).Name,
                            Holes = new List<HoleViewModel>()
                        };

                        //get player from database
                        var player = _playerService.GetPlayerById(scoreCard.PlayerSelected);
                        var user = _userService.GetUserByPlayerId(player.Id);
                        var totalStrikes = 0;

                        PlayerViewModel pm = new PlayerViewModel()
                        {
                            Id = scoreCard.PlayerSelected,
                            Name = user.Name,
                            Surname = user.Surname,
                            GameHP = player.GameHP,
                            License = player.License,
                            RealHP = player.RealHP
                        };

                        foreach (var r in scoreCard.ScoreCard)
                        {

                            var hm = new HoleViewModel()
                            {
                                HoleId = r.HoleId,
                                Handicap = r.Handicap,
                                Distance = r.Distance,
                                SelectedStrikes = r.SelectedStrikes
                            };
                            fm.Holes.Add(hm);
                        }

                        var afm = GolfManager.GetAdjustedField(pm, fm);

                        foreach (var h in afm.Holes)
                        {
                            var result = new Result()
                            {
                                PlayerId = pm.Id,
                                HoleId = h.HoleId,
                                MatchId = match.Id,
                                Strikes = h.SelectedStrikes,
                                StableFordPoints = GolfManager.GetStablefordScore(h)
                            };

                            totalStrikes = totalStrikes + result.Strikes;
                            _resultService.InsertResult(result);
                        }

                        //Update player handicap
                        if (match.IsTournament)
                        {  
                            player.GameHP = GolfManager.GetNewHandicap(totalStrikes, afm, pm);
                            _playerService.UpdatePlayer(player);
                        }
                    }
                }
            }

            return RedirectToAction("Details", new { id = model.MatchId });
        }
   
        #endregion

        #region Utilities

        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a list of players from the database </summary>                        ///
        /// <param name="">None</param>                                                          ///
        /// <returns>List<SelectListItem></returns>                                              ///
        ////////////////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public List<SelectListItem> GetAvailablePlayers()
        {
            List<SelectListItem> ls = new List<SelectListItem>();

            var users = from u in _userService.GetAllUser()
                        where u.PlayerId != null
                        select u;

            foreach (var u in users)
            {
                if (u != null) ls.Add(new SelectListItem() { Text = (u.Name + " " + u.Surname), Value = u.PlayerId.ToString() });
            }

            return ls;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a list of matches that have results in the database </summary>        ///
        /// <param name="">None</param>                                                          ///
        /// <returns>List<SelectListItem></returns>                                              ///
        ////////////////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public List<SelectListItem> GetAvailableResults()
        {
            List<SelectListItem> ls = new List<SelectListItem>();

            var results = from i in _resultService.GetAllResult()
                          group i by i.MatchId into g
                          select new { Id = g.Key };

            foreach (var m in results)
            {
                var match = _matchService.GetMatchById(m.Id);
                if (match != null) ls.Add(new SelectListItem() { Text = match.Date.ToString("dd-MMM-yy"), Value = match.Id.ToString() });
            }

            return ls;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a list of matches that don't have results in the database </summary>  ///
        /// <param name="">None</param>                                                          ///
        /// <returns>List<SelectListItem></returns>                                              ///
        ////////////////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public List<SelectListItem> GetAvailableMatches()
        {
            List<SelectListItem> ls = new List<SelectListItem>();

            var matches = from c in _matchService.GetAllMatch()
                          where !(from o in _resultService.GetAllResult()
                                  select o.MatchId).Contains(c.Id)
                          select c;

            foreach (var match in matches)
            {
                if (match != null) ls.Add(new SelectListItem() { Text = match.Date.ToString("dd-MMM-yy"), Value = match.Id.ToString() });
            }

            return ls;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a list of posible players in a match                      </summary>  ///
        /// <param name="">None</param>                                                          ///
        /// <returns>List<SelectListItem></returns>                                              ///
        ////////////////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public bool ModelIsValid(MatchScoreCardModel model)
        {
            var players = (from p in model.ScoreCards
                          group p by p.PlayerSelected).Count();

            if(players != model.ScoreCards.Count) return false;
            return true;
        }
        #endregion
    }
}
