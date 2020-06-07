using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Constants;
using Falcon.Entity.Prospect;
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

            return View("Details", model);
        }

        // GET: ProspectStudent/Create
        public ActionResult Create()
        {
            ViewBag.BloodGrpMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.BloodGrpMaster);
            ViewBag.AdmStatusMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.AdmStatusMaster);
            ViewBag.ReligionMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.ReligionMaster);
            ViewBag.CasteMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.CasteMaster);
            ViewBag.CategoryMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.CategoryMaster);
            ViewBag.SessionMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.SessionMaster);
            ViewBag.ClassMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.ClassMaster);
            ViewBag.SectionMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.SectionMaster);
            ViewBag.GenderMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.GenderMaster);
            ViewBag.CityMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.CityMaster);
            ViewBag.StateMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.StateMaster);
            ViewBag.CountryMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.CountryMaster);


            ViewBag.FormAction = "Add";

            return View("AddEdit");
        }

        // POST: ProspectStudent/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var prospectStudent = new AddProspectStudentModel
                {
                    AadharId = collection["AadharId"],
                    AdmissionStatusId = 1,
                    ApplicationDate = DateTime.Now.Date,
                    ApplicationNumber = string.Empty,
                    FirstName = collection["FirstName"],
                    MiddleName = collection["MiddleName"],
                    LastName = collection["LastName"],
                    BloodGrpId = Convert.ToInt32(collection["BloodGroup"]),
                    CasteId = Convert.ToInt32(collection["Caste"]),
                    CategoryId = Convert.ToInt32(collection["Category"]),
                    ClassId = Convert.ToInt32(collection["ClassList"]),
                    ReligionId = Convert.ToInt32(collection["Religion"]),
                    GenderId = Convert.ToInt32(collection["Gender"]),
                    DoB = Convert.ToDateTime(collection["DoB"]),
                    CurrentAddress = collection["CurrentAddress"],
                    PeremenantAddress = collection["PeremenantAddress"],
                    Email = collection["Email"],
                    Phone = collection["Phone"],
                    ParentPhone = collection["ParentPhone"],
                    ParentName = collection["ParentName"],
                    ParentEmailId = collection["ParentEmailId"],
                    ParentOccupation = collection["ParentOccupation"],
                    ParentRelationship = collection["ParentRelationship"],
                    Notes = collection["Notes"],
                };

                var isSuccess = prospectService.AddProspectStudent(prospectStudent);

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ProspectStudent/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.BloodGrpMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.BloodGrpMaster);
            ViewBag.AdmStatusMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.AdmStatusMaster);
            ViewBag.ReligionMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.ReligionMaster);
            ViewBag.CasteMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.CasteMaster);
            ViewBag.CategoryMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.CategoryMaster);
            ViewBag.SessionMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.SessionMaster);
            ViewBag.ClassMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.ClassMaster);
            ViewBag.SectionMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.SectionMaster);
            ViewBag.GenderMaster = MastDataCache.GetCachedDataByKey(CacheKeyConstants.GenderMaster);

            ViewBag.FormAction = "Edit";

            return View("AddEdit");
        }

        // POST: ProspectStudent/Edit/5
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

        // GET: ProspectStudent/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                prospectService.DeleteProspectStudent(id);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
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
