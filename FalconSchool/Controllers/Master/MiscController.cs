using Falcon.Entity.Master;
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
            var masterData = masterservice.GetMiscConfigurationData();

            var model = new MiscConfigurationViewModel();

            var dataList = new List<MiscConfigurationModel>();

            dataList.Add(new MiscConfigurationModel { ControllerName = "Relationship", ModelData = masterData.relationshipList });
            dataList.Add(new MiscConfigurationModel { ControllerName = "Caste", ModelData = masterData.casteList });
            dataList.Add(new MiscConfigurationModel { ControllerName = "Religion", ModelData = masterData.religionList });
            dataList.Add(new MiscConfigurationModel { ControllerName = "Category", ModelData = masterData.categoryList });
            dataList.Add(new MiscConfigurationModel { ControllerName = "Occupation", ModelData = masterData.occupationList });

            model.ViewModel = dataList;

            return View("~/views/master/misc.cshtml", model);
        }
    }
}
