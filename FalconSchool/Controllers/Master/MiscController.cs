using Falcon.Service.MasterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FalconSchool.Controllers.Master
{

    public class MiscController : Controller
    {
        private readonly IMasterService masterservice;

        public MiscController(IMasterService service)
        {
            this.masterservice = service;
        }


        // GET: Misc
        public ActionResult Index()
        {
            var model = masterservice.GetMiscConfigurationData();
            
            return View("~/views/master/misc.cshtml", model );
        }
    }
}
