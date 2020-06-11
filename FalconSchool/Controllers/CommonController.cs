using Falcon.Entity;
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
        public JsonResult SearchPostal(string q)
        {
            var _obj = commonService.GetPostalCodeBySearchKey(q);
            return Json(new { total_count = _obj.Count, incomplete_results = false, items = _obj }, JsonRequestBehavior.AllowGet);
        }

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
    }
}