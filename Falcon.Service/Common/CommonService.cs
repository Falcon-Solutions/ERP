using Configuration;
using Falcon.DataAceess;
using Falcon.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Falcon.Entity.Address;

namespace Falcon.Service.Common
{
    public class CommonService : ICommonService
    {
        ICommonRepository repository { get; set; }

        public CommonService()
        {
            this.repository = new CommonRepository();
        }

        public Dictionary<string, List<DropdownData>> GetMasterData()
        {
            Dictionary<string, List<DropdownData>> dropdownKeyValuePairs = new Dictionary<string, List<DropdownData>>();

            var result = repository.GetMasterData();

            if (result != null && result.Tables != null)
                if (result.Tables.Count > 0)
                {
                    //Dropdown data for blood group.
                    dropdownKeyValuePairs.Add(CacheKeyConstants.BloodGrpMaster, FilterOutDropdownDataByKey(CacheKeyConstants.BloodGrpMaster, result));

                    dropdownKeyValuePairs.Add(CacheKeyConstants.AdmStatusMaster, FilterOutDropdownDataByKey(CacheKeyConstants.AdmStatusMaster, result));

                    dropdownKeyValuePairs.Add(CacheKeyConstants.ReligionMaster, FilterOutDropdownDataByKey(CacheKeyConstants.ReligionMaster, result));

                    dropdownKeyValuePairs.Add(CacheKeyConstants.CasteMaster, FilterOutDropdownDataByKey(CacheKeyConstants.CasteMaster, result));

                    dropdownKeyValuePairs.Add(CacheKeyConstants.CategoryMaster, FilterOutDropdownDataByKey(CacheKeyConstants.CategoryMaster, result));

                    dropdownKeyValuePairs.Add(CacheKeyConstants.SessionMaster, FilterOutDropdownDataByKey(CacheKeyConstants.SessionMaster, result));

                    dropdownKeyValuePairs.Add(CacheKeyConstants.ClassMaster, FilterOutDropdownDataByKey(CacheKeyConstants.ClassMaster, result));

                    dropdownKeyValuePairs.Add(CacheKeyConstants.SectionMaster, FilterOutDropdownDataByKey(CacheKeyConstants.SectionMaster, result));

                    dropdownKeyValuePairs.Add(CacheKeyConstants.GenderMaster, FilterOutDropdownDataByKey(CacheKeyConstants.GenderMaster, result));
                }

            return dropdownKeyValuePairs;
        }



        #region private Function
        private List<DropdownData> FilterOutDropdownDataByKey(string key, DataSet ds)
        {
            List<DropdownData> dropDowanData = new List<DropdownData>();
            if (ds.Tables[key].Rows.Count > 0)
            {
                //foreach (DataRow row in ds.Tables[key].Rows)
                //{
                //    var item = new DropdownData();

                //    item.Key = Convert.ToInt32(row.Field<decimal>("Key"));
                //    item.Value = row.Field<string>("Value");

                //    dropDowanData.Add(item);

                //    dropDowanData.Add(new DropdownData { Key = 0, Value = string.Empty });

                //    dropDowanData.OrderBy(x => x.Key);
                //}

                dropDowanData.AddRange(ds.Tables[key].AsEnumerable().Select(row => new DropdownData()
                {
                    Text = Convert.ToString(row.Field<int>("Key")),
                    Value = row.Field<string>("Value")
                }).ToList());
            }


            return dropDowanData;
        }

        public List<PostalCodeMaster> GetPostalCodeBySearchKey(string searchKeyword)
        {
            var pinCodeDt = repository.GetPostalCodeBySearchKey(searchKeyword);

            var pinCodeList = new List<PostalCodeMaster>();

            pinCodeList.AddRange(pinCodeDt.AsEnumerable().Select(row => new PostalCodeMaster()
            {
                Id = Convert.ToInt32(row.Field<int>("myId")),
                Area = row.Field<string>("Area"),
                City = row.Field<string>("City"),
                Country = row.Field<string>("Country"),
                District = row.Field<string>("District"),
                Pin = row.Field<string>("PinCode"),
                State = row.Field<string>("State"),
                Tehsil = row.Field<string>("Tehsil")
            }));

            return pinCodeList;
        }
        #endregion
    }
}
