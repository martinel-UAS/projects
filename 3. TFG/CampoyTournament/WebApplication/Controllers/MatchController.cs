using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Match;
using DomainServices;
using WebApplication.Attributes;
using DomainEntities;
using System;

namespace WebApplication.Controllers
{
    public class MatchController : Controller
    {
        #region Fields

        private readonly MatchService _matchService;
        private readonly FieldService _fieldService;
        private readonly TournamentService _tournamentService;
        private readonly ResultService _resultService;

        #endregion

        #region Constructors

        public MatchController(MatchService matchService, FieldService fieldService, TournamentService tournamentService, ResultService resultService)
        {
            this._matchService = matchService;
            this._fieldService = fieldService;
            this._tournamentService = tournamentService;
            this._resultService = resultService;           
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method will return the Match List View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [LogonAuthorize]
        public ActionResult Index()
        {
            //create model
            var model = new MatchViewModel();

            //get current system date            
            var today = System.DateTime.Today;

            //get fields from database
            var fields = _fieldService.GetAllField();

            //get matches from database
            var matches = _matchService.GetAllMatch();

            //select future matches using LinQ
            var futureMatches = from match in matches
                                where match.Date >= today
                                select match;

            //populate model
            foreach (Match match in futureMatches)
            {
                var matchViewModel = new MatchViewModel()
                {
                    Id = match.Id,
                    FieldId = match.FieldId,
                    FieldName = _fieldService.GetFieldById(match.FieldId).Name,
                    Date = match.Date,
                    KindOfEvent = (from ev in GetKindOfEvents()
                               where ev.Value == match.IsTournament.ToString()
                               select ev.Text).First(),
                    HasResults = _resultService.CheckResultByMatch(match.Id, "Id")
                };
                model.FutureMatchs.Add(matchViewModel);
            }

            //select most(two) recent matches using LinQ
            var recentMatches = (from match in matches
                                where match.Date < today
                                select match).Take(2);

            //populate model
            foreach (Match match in recentMatches)
            {
                var matchViewModel = new MatchViewModel()
                {
                    Id = match.Id,
                    FieldId = match.FieldId,
                    FieldName = _fieldService.GetFieldById(match.FieldId).Name,
                    Date = match.Date,
                    KindOfEvent = (from ev in GetKindOfEvents()
                                   where ev.Value == match.IsTournament.ToString()
                                   select ev.Text).First(),
                    HasResults= _resultService.CheckResultByMatch(match.Id, "Id")
                };
                model.RecentMatchs.Add(matchViewModel);
            }
 
            //send viewmodel into UI (View)
            return View(model);
        }

        /// <summary>
        /// This method will return the Details Match View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [LogonAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null) throw new HttpException(404,"");
            //get match from database
            var match = _matchService.GetMatchById((int)id);
            if (match == null) throw new HttpException("Match " + id + " not found");

            //get current system date           
            var today = System.DateTime.Today;
            
            //populate model
            var model = new MatchViewModel()
            {
                Id = match.Id,
                FieldId = match.FieldId,
                FieldName = _fieldService.GetFieldById(match.FieldId).Name,
                Date = match.Date,
                KindOfEvent = (from ev in GetKindOfEvents()
                               where ev.Value == match.IsTournament.ToString()
                               select ev.Text).First()
            };

            //send viewmodel into UI (View)
            return View(model);
        }

        /// <summary>
        /// This method will return the create match view
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [AuthorizeUser(AccessLevel = "Admin Player")]
        public ActionResult Create()
        {
            //get current system date
            var today = System.DateTime.Today;

            //initialize model
            var model = new MatchViewModel() {
                AvailableFields = GetAvailableFields(),
                KindOfEvents = GetKindOfEvents(),
                Date = today            
            };

            //send viewmodel into UI (View)
            return View(model);
        }

        /// <summary>
        /// This method will create the match in db
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin Player")]
        public ActionResult Create(MatchViewModel model)
        {
            if (ModelState.IsValid)
            {
                //get current system date
                var today = System.DateTime.Today;

                if (model.Date.CompareTo(today) < 0) ModelState.AddModelError("", "La fecha no puede ser anterior al día de hoy");
                else
                {
                    //select (if exist) a match at the same date
                    var todayMatches = (from match in _matchService.GetAllMatch()
                                        where match.Date == model.Date
                                        select match).FirstOrDefault();

                    if (todayMatches != null) ModelState.AddModelError("", "Ya existe un evento en esta fecha");
                    else //insert new match
                    {
                        Match match = new Match()
                        {
                            TournamentId = _tournamentService.GetAllTournamentsOrderBy("Id").FirstOrDefault().Id,
                            Date = model.Date,
                            FieldId = model.FieldId,
                            IsTournament = model.KindOfEvent.Equals("True")
                        };
                        
                        _matchService.InsertMatch(match);
                        return RedirectToAction("Index");
                    }
                }
            }

            //initialize SelectLists
            model.AvailableFields = GetAvailableFields();
            model.KindOfEvents = GetKindOfEvents();

            //send viewmodel into UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a edit match form</summary>                 ///
        /// <param name="id">MatchId</param>                                          ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin/Players only</permission>                               ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [AuthorizeUser(AccessLevel = "Admin Player")]
        public ActionResult Edit(int? id)
        {
            if (id == null) throw new HttpException(404, "");

            //get match from database
            var match = _matchService.GetMatchById((int)id);
            if (match == null) throw new HttpException("Match " + id + " not found");

            //populate model
            var model = new MatchViewModel()
            {                
                Id = match.Id,
                FieldId = match.FieldId,
                FieldName = _fieldService.GetFieldById(match.FieldId).Name,
                Date = match.Date,
                KindOfEvent = (from ev in GetKindOfEvents()
                               where ev.Value == match.IsTournament.ToString()
                               select ev.Text).First()
            };

            //get the selected item
            string selected = (from sub in GetKindOfEvents()
                               where sub.Text == model.KindOfEvent
                               select sub.Text).First();

            ViewBag.KindOfEvent = new SelectList(GetKindOfEvents(), "Text", "Text", selected);
            
            //initialize SelectLists 
            model.AvailableFields = GetAvailableFields();
            model.KindOfEvents = GetKindOfEvents();

            //send viewmodel into UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Edit match in database</summary>                                ///
        /// <param name="model">MatchViewModel</param>                                ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin/Players only</permission>                               ///
        /// <request>POST</request>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin Player")]
        public ActionResult Edit(MatchViewModel model)
        {
            if (ModelState.IsValid)
            {
                //get current system date
                var today = System.DateTime.Today; 

                if (model.Date.CompareTo(today) < 0)
                {
                    ModelState.AddModelError("", "La fecha no puede ser anterior al día de hoy");
                }
                else if (MatchExists(model))
                {
                    ModelState.AddModelError("", "Ya existe un evento en esta fecha");
                }
                else //update match
                {
                    Match match = new Match() { 
                        TournamentId = _tournamentService.GetAllTournament().FirstOrDefault().Id,           
                        Id = model.Id,
                        Date = model.Date,
                        FieldId = model.FieldId,
                        IsTournament = model.KindOfEvent.Equals("Campeonato")
                    };
                    _matchService.UpdateMatch(match);
                    return RedirectToAction("Index");
                }
            }

            //initialize SelectLists 
            model.AvailableFields = GetAvailableFields();
            model.KindOfEvents = GetKindOfEvents();
            
            //send viewmodel into UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a delete match form</summary>               ///
        /// <param name="id">MatchIdNone</param>                                      ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin/Players only</permission>                               ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [AuthorizeUser(AccessLevel = "Admin Player")]
        public ActionResult Delete(int? id)
        {
            if (id == null) throw new HttpException(404, "");
            //get match from database
            var match = _matchService.GetMatchById((int)id);
            if (match == null) throw new HttpException("Match " + id + " not found");
 
            //populate model
            var model = new MatchViewModel()
            {
                Id = match.Id,
                FieldId = match.FieldId,
                FieldName = _fieldService.GetFieldById(match.FieldId).Name,
                Date = match.Date,
                KindOfEvent = (from ev in GetKindOfEvents()
                               where ev.Value == match.IsTournament.ToString()
                               select ev.Text).First()
            };

            //send viewmodel into UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Logical delete match from database</summary>                    ///
        /// <param name="id, model">MatchId, MatchViewModel</param>                   ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin/Players only</permission>                               ///
        /// <request>POST</request>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin Player")]
        public ActionResult Delete(int? id, MatchViewModel model)
        {
            if (id == null) throw new HttpException(404, "");
            //get match from database
            var match = _matchService.GetMatchById((int)id);
            if (match == null) throw new HttpException("Match " + id + " not found");
            //logical delete match
            _matchService.LogicalDeleteMatch(match);
            return RedirectToAction("Index");
        }

        #endregion

        #region Utilities
        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Populate dropdown from fields in database</summary>             ///
        /// <param name="">None</param>                                               ///
        /// <returns>List<SelectListItem></returns>                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public List<SelectListItem> GetAvailableFields()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            var lm = from m in _fieldService.GetAllField()
                     select m;
            foreach (var temp in lm)
            {
                ls.Add(new SelectListItem() { Text = temp.Name, Value = temp.Id.ToString() });
            }
            return ls;
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Populate dropdown from kindofevents</summary>                   ///
        /// <param name="">None</param>                                               ///
        /// <returns>List<SelectListItem></returns>                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public List<SelectListItem> GetKindOfEvents()
        {
            List<SelectListItem> ls = new List<SelectListItem>();            
            ls.Add(new SelectListItem() { Text = "Amistoso", Value = "False"});
            ls.Add(new SelectListItem() { Text = "Campeonato", Value = "True" });
            return ls;
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Check if a match exist</summary>                                ///
        /// <param name="model">MatchViewModel</param>                                ///
        /// <returns>bool</returns>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public bool MatchExists(MatchViewModel model)
        {
            var currentMatch = _matchService.GetMatchById(model.Id);
            if (currentMatch != null)
            {                                
                if(currentMatch.Date.CompareTo(model.Date) != 0)
                {
                    //select (if exist) a match at the same date
                    var matches = (from match in _matchService.GetAllMatch()
                                        where match.Date == model.Date
                                        select match).FirstOrDefault();

                    if (matches != null) return true;
                }
            }

            return false;
        }

        #endregion
    }
}
