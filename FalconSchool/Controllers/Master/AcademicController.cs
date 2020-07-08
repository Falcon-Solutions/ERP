using Falcon.Entity.Master;
using Falcon.Service.MasterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FalconSchool.Controllers.Master
{
    public class AcademicController : Controller
    {
        private readonly IMasterService masterService;

        

        public AcademicController(IMasterService service)
        {
            this.masterService = service;
        }

        [HttpGet]
        public ActionResult GetSessionClassSectionMaster(string placeHolder = "Session")
        {
            try
            {
                ViewData.Add(new KeyValuePair<string, object>("IsEdit", true));
                ViewData.Add(new KeyValuePair<string, object>("IsDetails", false));
                ViewData.Add(new KeyValuePair<string, object>("IsDelete", true));

                var model = masterService.GetClassConfiguration();

                ViewBag.Action = "get";
                ViewBag.PlaceHolder = placeHolder;
                ViewBag.AlertShow = false;
                //ViewBag.AlertMessage = "Invalid operation !!!";
                //ViewBag.AlertClass = "alert alert-warning alert-dismissible fade show";
                ViewBag.Success = true;

                return View("~/Views/Master/GetSessionClassSectionMaster.cshtml", model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[ChildActionOnly]
        //public ActionResult SessionMasterList()
        //{
        //    var model = masterService.GetClassConfiguration();

        //    return PartialView("~/Views/Shared/_GridView.cshtml", model.sectionList);
        //}

        public ActionResult GetConfig(string mode = "get", bool success = true)
        {
            var model = masterService.GetClassConfiguration();

            if (mode == "get" && !success)
            {
                ViewBag.Action = "get";
                ViewBag.AlertShow = true;
                ViewBag.AlertMessage = "Invalid operation !!!";
                ViewBag.AlertClass = "alert alert-warning alert-dismissible fade show";
                ViewBag.Success = false;
            }
            else if (mode == "update" && success)
            {
                ViewBag.Action = "update";
                ViewBag.Success = true;
                ViewBag.AlertShow = true;
                ViewBag.AlertMessage = "Successfully updated classes configuration";
                ViewBag.AlertClass = "alert alert-success alert-dismissible fade show";
            }
            else if (mode == "update" && !success)
            {
                ViewBag.Action = "update";
                ViewBag.Success = false;
                ViewBag.AlertShow = true;
                ViewBag.AlertMessage = "Error while saving configuration";
                ViewBag.AlertClass = "alert alert-danger alert-dismissible fade show";
                ViewBag.Message = "Error while saving configuration";
            }
            else
            {
                ViewBag.AlertShow = false;
                ViewBag.Message = "";
            }

            return View("~/Views/Master/ClassConfig.cshtml", model);
        }

        // POST: ProspectStudent/Create
        [HttpPost]
        public ActionResult UpdateConfig(FormCollection collection)
        {
            var str = collection.AllKeys.Skip(1).ToArray();

            if (str.Where(x => x.Substring(0,1) == "0").Count() > 0)
            {
                if (masterService.UpdateClassConfig(collection.AllKeys.Skip(1).ToArray()))
                {
                    return RedirectToAction("GetConfig", new { mode = "update", success = true });
                }
                else
                {
                    return RedirectToAction("GetConfig", new { mode = "update", success = false });
                }
            }
            else
            {
                return RedirectToAction("GetConfig", new { mode = "get", success = false });
            }
        }

        [HttpPost]
        public ActionResult CreateSession(FormCollection collection)
        {
            var session = new SessionModel
            {
                Name = collection["Name"]
            };

            //var isSuccess = masterService.AddSession(session);

            return RedirectToAction("GetSessionClassSectionMaster", new { placeHolder = "Session" });
        }

        [HttpPost]
        public ActionResult EditSession()
        {
            return RedirectToAction("GetSessionClassSectionMaster", new { placeHolder = "Session" });
        }

        [HttpPost]
        public ActionResult DeleteSession()
        {
            return RedirectToAction("GetSessionClassSectionMaster", new { placeHolder = "Session" });
        }

        [HttpPost]
        public ActionResult CreateClass(FormCollection collection)
        {
            return RedirectToAction("GetSessionClassSectionMaster", new { placeHolder = "Class" });
        }

        [HttpPost]
        public ActionResult EditClass()
        {
            return RedirectToAction("GetSessionClassSectionMaster", new { placeHolder = "Class" });
        }

        [HttpPost]
        public ActionResult DeleteClass()
        {
            return RedirectToAction("GetSessionClassSectionMaster", new { placeHolder = "Class" });
        }

        [HttpPost]
        public ActionResult CreateSection(FormCollection collection)
        {
            return RedirectToAction("GetSessionClassSectionMaster", new { placeHolder = "Section" });
        }

        [HttpPost]
        public ActionResult EditSection()
        {
            return RedirectToAction("GetSessionClassSectionMaster", new { placeHolder = "Section" });
        }

        [HttpPost]
        public ActionResult DeleteSection()
        {
            return RedirectToAction("GetSessionClassSectionMaster", new { placeHolder = "Section" });
        }
    }

}
