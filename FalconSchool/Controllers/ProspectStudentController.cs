using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Constants;
using Falcon.Entity;
using Falcon.Entity.Address;
using Falcon.Entity.Prospect;
using Falcon.Service.Common;
using Falcon.Service.Prospect;
using FalconSchool.Caching;
using Utility;

namespace FalconSchool.Controllers
{
    public class ProspectStudentController : Controller
    {

        private readonly IProspectStudentService prospectService;

        public ProspectStudentController(IProspectStudentService service)
        {
            this.prospectService = service;
        }

        // GET: ProspectStudent
        public ActionResult List()
        {
            var model = prospectService.GetProspectStudentList();

            return View(model);
        }

        // GET: ProspectStudent/Details/5
        public ActionResult Details(int id)
        {
            var model = prospectService.GetProspectStudentDetailsById(id);
            model.ActionType = FormAction.Get;
            return View("Details", model);
        }

        // GET: ProspectStudent/Create
        public ActionResult Create()
        {
            ViewBag.RedirectAction = "Create";
            return View("AddEdit");
        }

        // POST: ProspectStudent/Create
        [HttpPost]
        public ActionResult Create(ProspectModel model)//FormCollection collection
        {
            try
            {
                var isSuccess = prospectService.AddProspectStudent(model);

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return RedirectToAction("List");
            }
        }

        // GET: ProspectStudent/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.RedirectAction = "Edit";

            var model = prospectService.GetProspectStudentDetailsById(id);

            model.ActionType = FormAction.Edit;
            model.CurrentAddress.Action = FormAction.Edit;
            if (!(model.PermanentAddress == null))
            {
                model.PermanentAddress.Action = FormAction.Edit;
            }
            return View("AddEdit", model);
        }

        // POST: ProspectStudent/Edit/5
        [HttpPost]
        public ActionResult Edit(ProspectModel updatedModel)
        {
            try
            {
                var oldModel = prospectService.GetProspectStudentDetailsById(updatedModel.Id);

                var difference = updatedModel.DetailedCompare(oldModel);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProspectStudent/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                prospectService.DeleteProspectStudent(id);

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return RedirectToAction("List");
            }
        }

        // POST: ProspectStudent/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        prospectService.DeleteProspectStudent(id);

        //        return RedirectToAction("List");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
