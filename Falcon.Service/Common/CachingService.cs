using Falcon.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Falcon.Service.Common
{
    public class CachingService
    {
        public static void LoadStaticCacheForDropdown(Dictionary<string, List<DropdownData>> masterData)
        {
            foreach (var keyValue in masterData)
            {
                HttpRuntime.Cache.Insert(
              /* key */                keyValue.Key,
              /* value */              keyValue.Value,
              /* dependencies */       null,
              /* absoluteExpiration */ Cache.NoAbsoluteExpiration,
              /* slidingExpiration */  Cache.NoSlidingExpiration,
              /* priority */           CacheItemPriority.NotRemovable,
              /* onRemoveCallback */   null);
            }

        }

        public static bool UpdateAllCacheObjects(Dictionary<string, List<DropdownData>> masterData)
        {
            var enumerator = HttpRuntime.Cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                DeleteCacheByKey(enumerator.Key.ToString());
            }

            LoadStaticCacheForDropdown(masterData);

            return true;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static dynamic GetCachedDataByKey(string key)
        {
            return HttpRuntime.Cache[key];
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public static bool InsertCachedDataByKey(string key, object value)
        {
            HttpRuntime.Cache.Insert(
              /* key */                key,
              /* value */              value,
              /* dependencies */       null,
              /* absoluteExpiration */ Cache.NoAbsoluteExpiration,
              /* slidingExpiration */  Cache.NoSlidingExpiration,
              /* priority */           CacheItemPriority.NotRemovable,
              /* onRemoveCallback */   null);

            return true;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public static bool DeleteCacheByKey(string key)
        {
            HttpRuntime.Cache.Remove(key);
            return true;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public static bool UpdateCacheObjectsByKey(string key, object value)
        {
            if (DeleteCacheByKey(key))
            {
                if (InsertCachedDataByKey(key, value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
