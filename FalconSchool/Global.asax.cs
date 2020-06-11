using Falcon.DataAceess;
using Falcon.Service.Common;
using FalconSchool.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FalconSchool
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LoadMasterDataCache();
        }

        private void LoadMasterDataCache()
        {
            CommonService MasterDataCache = new CommonService();
            var masterData = MasterDataCache.GetMasterData();

            CachingService.LoadStaticCacheForDropdown(masterData);
        }
    }
}
