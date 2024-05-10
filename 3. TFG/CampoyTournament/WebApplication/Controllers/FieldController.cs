using DomainEntities;
using DomainServices;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using WebApplication.Attributes;
using WebApplication.Models.Field;
using System.Linq;

namespace WebApplication.Controllers
{
    public class FieldController : Controller
    {
        #region Fields

        private readonly FieldService _fieldService;
        private readonly HoleService _holeService;

        #endregion

        #region Constructors

        public FieldController(FieldService fieldService, HoleService holeService)
        {
            this._fieldService = fieldService;
            this._holeService = holeService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method will return the Field List View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [LogonAuthorize]
        public ActionResult Index()
        {   
            //get fields from database
            List<Field> fields = _fieldService.GetAllField();

            //create object list of FieldViewModel
            List<FieldViewModel> modelList = new List<FieldViewModel>();

            //populate modelList
            foreach (Field field in fields)
            {            
                var fieldViewModel = new FieldViewModel()
                {
                    Id = field.Id,
                    Name = field.Name,
                    Address = field.Address,
                    City = field.City,
                    Province = field.Province,
                    Web = field.Web,
                    Email = field.Email,
                    Phone = field.Phone
                };
                modelList.Add(fieldViewModel);
            }

            //send model to the UI (View)
            return View(modelList);
        }

        /// <summary>
        /// This method will return the Field Details View
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [LogonAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null) throw new HttpException(404, "");
            //get field from database
            Field field = _fieldService.GetFieldById((int)id);
            if (field == null) throw new HttpException("Field " + id + " not found");

            //get holes for the field using LinQ
            IEnumerable<Hole> holes = from hole in _holeService.GetAllHole()
                        where hole.FieldId.Equals(field.Id)
                        select hole;

            //populate field model
            FieldViewModel model = new FieldViewModel()
            {
                Id = field.Id,
                Name = field.Name,
                Address = field.Address,
                City = field.City,
                Province = field.Province,
                Web = field.Web,
                Email = field.Email,
                Phone = field.Phone,
                Holes = new List<HoleViewModel>()
            };

            HoleViewModel holeViewModel = null;

            //populate list of hole model
            foreach (Hole hole in holes)
            {
                holeViewModel = new HoleViewModel()
                {
                    HoleId = hole.Id,
                    Distance = hole.Distance,
                    Handicap = hole.Handicap
                };
                model.Holes.Add(holeViewModel);
            }

            //send model to the UI (View)
            return View(model);
        }

        /// <summary>
        /// This method will return the Create Field View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Create()
        {
            FieldViewModel model = new FieldViewModel();

            HoleViewModel holeViewModel = null;

            for(int i = 0; i < 18; i++)
            {
                holeViewModel = new HoleViewModel();
                model.Holes.Add(holeViewModel);
            }
            return View(model);
        }

        /// <summary>
        /// This method will create a new Field
        /// </summary>
        /// <param name="model">FieldViewModel</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Create(FieldViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (ValidateHandicaps(model))
                {
                    Field field = new Field()
                    {
                        Name = model.Name,
                        Address = model.Address,
                        City = model.City,
                        Province = model.Province,
                        Web = model.Web,
                        Email = model.Email,
                        Phone = model.Phone
                    };

                    int fieldId = _fieldService.InsertField(field);

                    foreach (HoleViewModel holeViewModel in model.Holes)
                    {
                        Hole hole = new Hole()
                        {
                            Id = holeViewModel.HoleId,
                            FieldId = fieldId,
                            Handicap = holeViewModel.Handicap,
                            Distance = holeViewModel.Distance,
                        };

                        _holeService.InsertHole(hole);
                    }
                    return RedirectToAction("Index");
                }
                else ModelState.AddModelError("", "Los handicaps no pueden estar repetidos!!");
            }
            return View(model);
        }

        /// <summary>
        /// This method will return the Edit Field view
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null) throw new HttpException(404, "");
            // get field from database
            Field field = _fieldService.GetFieldById((int)id);
            if(field == null) throw new HttpException("Field " + id + " not found");

            //get holes using LinQ
            IEnumerable<Hole> holes = from h in _holeService.GetAllHole()
                                      where h.FieldId == field.Id
                                      select h;

            //populate models
            FieldViewModel model = new FieldViewModel()
            {
                Id = field.Id,
                Name = field.Name,
                Address = field.Address,
                City = field.City,
                Province = field.Province,
                Web = field.Web,
                Email = field.Email,
                Phone = field.Phone,
                Holes = new List<HoleViewModel>()
            };

            HoleViewModel holeViewModel;

            foreach (Hole hole in holes)
            {
                holeViewModel = new HoleViewModel()
                {
                    HoleId = hole.Id,
                    Distance = hole.Distance,
                    Handicap = hole.Handicap,
                };
                holeViewModel.Handicaps[(hole.Handicap)].Selected = true;
                model.Holes.Add(holeViewModel);
            }

            //send model to the UI (View)
            return View(model);
        }

        /// <summary>
        /// This method will edit a Field in db
        /// </summary>
        /// <param name="id, model">int,FieldViewModel</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Edit(int id, FieldViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (ValidateHandicaps(model))
                {
                    //populate field entity
                    Field field = new Field()
                    {
                        Id = id,
                        Name = model.Name,
                        Address = model.Address,
                        City = model.City,
                        Province = model.Province,
                        Web = model.Web,
                        Email = model.Email,
                        Phone = model.Phone
                    };

                    //update field
                    _fieldService.UpdateField(field);

                    foreach (var item in model.Holes)
                    {
                        //populate hole entity
                        var hole = new Hole()
                        {
                            Id = item.HoleId,
                            FieldId = field.Id,
                            Handicap = item.Handicap,
                            Distance = item.Distance
                        };

                        //update hole
                        _holeService.UpdateHole(hole);
                    }
                    return RedirectToAction("Index");
                }
                else ModelState.AddModelError("", "Los handicaps no pueden estar repetidos!!");
            }
            //send model to the UI (View)
            return View(model);
        }

        /// <summary>
        /// This method will return a field delete confirmation view
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null) throw new HttpException(404, "");

            //get field from database
            Field field = _fieldService.GetFieldById((int)id);
            if (field == null) throw new HttpException("Field " + id + " not found");

            //populate model
            var model = new FieldViewModel()
            {
                Id = field.Id,
                Name = field.Name,
                Address = field.Address,
                City = field.City,
                Province = field.Province,
                Web = field.Web,
                Email = field.Email,
                Phone = field.Phone
            };

            //send model to the UI (View)
            return View(model);
        }


        /// <summary>
        /// This method will create a new Field
        /// </summary>
        /// <param name="id, fieldViewModel">int, FieldViewModel</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Delete(int? id, FieldViewModel fieldViewModel)
        {
            if (id == null) throw new HttpException(404, "");

            //get holes using LinQ
            IEnumerable<Hole> holes = from h in _holeService.GetAllHole()
                                      where h.FieldId == id
                                      select h;
            //logical delete holes
            foreach (Hole hole in holes) _holeService.LogicalDeleteHole(hole);

            //get field form database
            Field field = _fieldService.GetFieldById((int)id);            
            if(field == null) throw new HttpException("Field " + id + " not found");

            //logical delete field
            _fieldService.LogicalDeleteField(field);

            //return to the Field List Page
            return RedirectToAction("Index");
        }
        #endregion

        #region Utilities
        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Validate handicaps not repeated in model </summary>             ///
        /// <param name="model">FieldViewModel</param>                                ///
        /// <returns>bool</returns>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        private bool ValidateHandicaps(FieldViewModel model)
        {                            
            for (int i = 0; i < model.Holes.Count; i++)
            {
                int handicap = model.Holes[i].Handicap;
                for (int j = (i + 1); j < model.Holes.Count; j++)
                {
                    if (model.Holes[j].Handicap == handicap) return false;                    
                }
            }
            return true;
        }

        #endregion
    }
}

