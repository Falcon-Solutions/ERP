﻿using Falcon.Entity;
using Falcon.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FalconSchool.Controllers
{
    public class CommonController : Controller
    {
        private ICommonService commonService;

        public CommonController()
        {
            this.commonService = new CommonService();
        }

        // GET: Common


        public ActionResult Index()
        {
            return View("~/Views/LiveSearch.cshtml");
        }

        // GET: get states by country
        public JsonResult SearchStateByCountryId(int id)
        {
            var result = commonService.GetStateByCountryId(id, true);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: get states by country
        public JsonResult SearchCityByStateId(int id)
        {
            var result = commonService.GetCityByStateId(id, true);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}