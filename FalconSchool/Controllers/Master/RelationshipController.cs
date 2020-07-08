using Constants;
using Falcon.Service.MasterRepository;
using FalconSchool.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FalconSchool.Controllers.Master
{
    public class RelationshipController : Controller
    {
        private readonly IMasterService masterService;

        public RelationshipController(IMasterService service)
        {
            this.masterService = service;
        }


        public ActionResult Create()
        {
            ViewBag.Action = "Create";
            ViewBag.ControllerName = "Relationship";
            return PartialView("~/Views/Shared/_UpdateMaster.cshtml");
        }

        public ActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            ViewBag.ControllerName = "Relationship";
            return PartialView("_UpdateMaster");
        }

        // POST: Misc/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                masterService.AddRelationship(collection["Name"]);

                return RedirectToAction("Index","Misc");
            }
            catch
            {
                return View();
            }
        }


        // POST: Misc/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Misc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = masterService.DeleteRelationship(id);
                if (result)
                {
                    
                    ViewBag.Action = "delete";
                    ViewBag.Success = true;
                    ViewBag.AlertShow = true;
                    ViewBag.AlertMessage = "Successfully deleted relationship.";
                    ViewBag.AlertClass = "alert alert-success alert-dismissible fade show";

                    return RedirectToAction("Index", "Misc");
                }
                else {
                    ViewBag.Action = "delete";
                    ViewBag.Success = false;
                    ViewBag.AlertShow = true;
                    ViewBag.AlertMessage = "Error while deleting relationship";
                    ViewBag.AlertClass = "alert alert-danger alert-dismissible fade show";

                    return RedirectToAction("Index", "Misc");
                }
                
            }
            catch
            {
                ViewBag.Action = "delete";
                ViewBag.Success = false;
                ViewBag.AlertShow = true;
                ViewBag.AlertMessage = "Error while deleting relationship";
                ViewBag.AlertClass = "alert alert-danger alert-dismissible fade show";

                return RedirectToAction("Index", "Misc");
            }
        }

    }
}
