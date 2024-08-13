using DomainEntities;
using DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Attributes;
using WebApplication.Models.Classification;

namespace WebApplication.Controllers
{
    public class ClassificationController : Controller
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

        public ClassificationController(UserService userService, PlayerService playerService, FieldService fieldService,
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

        /// <summary>
        /// This method will return the Classification View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [LogonAuthorize]
        public ActionResult Index()
        {
            //model
            var model = new List<ClassificationViewModel>();

            //get players from database
            List<Player> players = _playerService.GetAllPlayer();


            var tournamentMatchesWithResult = new List<Match>();

            //get championship matches from database
            var matches = from m in _matchService.GetAllMatch()
                          where m.IsTournament
                          select m;

            //get those championship matches with results
            foreach(var match in matches)
            {                    
                    if (_resultService.CheckResultByMatch(match.Id, "Id")) tournamentMatchesWithResult.Add(match);                    
            }

            foreach (Player player in players)
            {
                var p = _userService.GetUserByPlayerId(player.Id);
                var cm = new ClassificationViewModel() { PlayerId = player.Id, PlayerName = p.Name + " " + p.Surname, PlayerLicense = player.License, TotalGames = tournamentMatchesWithResult.Count() };

                foreach (Match match in tournamentMatchesWithResult)
                {               
                    var results = _resultService.GetResultByMatchPlayer(match.Id, player.Id, "Id");
                    if (results.Count == 0) { cm.GamesDiscarted++; }
                    else { cm.GamesPlayed++; }

                    foreach (var result in results)
                    {                        
                            cm.TotalPoints = cm.TotalPoints + result.StableFordPoints;
                            cm.TotalStrikes = cm.TotalStrikes + result.Strikes;                             
                    }                   
                }
                
                model.Add(cm);
            }

            //send model to the UI (View)
            return View(model);
        }

        #endregion

        #region Utilities

        #endregion
    }
}