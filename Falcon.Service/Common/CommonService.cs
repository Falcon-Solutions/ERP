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

                    dropdownKeyValuePairs.Add(CacheKeyConstants.CountryMaster, FilterOutDropdownDataByKey(CacheKeyConstants.CountryMaster, result));

                    CachingService.InsertCachedDataByKey(CacheKeyConstants.StateMaster, result.Tables[CacheKeyConstants.StateMaster].AsEnumerable().Select(row => new State()
                    {
                        Id = row.Field<int>("myId"),
                        Name = row.Field<string>("State"),
                        refCountryId = row.Field<int>("refCountryId"),
                    }).ToList());

                    CachingService.InsertCachedDataByKey(CacheKeyConstants.CityMaster, result.Tables[CacheKeyConstants.CityMaster].AsEnumerable().Select(row => new City()
                    {
                        Id = row.Field<int>("myId"),
                        Name = row.Field<string>("City"),
                        refStateId = row.Field<int>("refStateId"),
                    }).ToList());

                }

            return dropdownKeyValuePairs;
        }

        public List<DropdownData> GetCityByStateId(int stateId, bool useCachedData)
        {
            if (useCachedData)
            {
                var states = CachingService.GetCachedDataByKey(CacheKeyConstants.StateMaster) as List<City>;

                return states.Where(x => x.refStateId == stateId)
                    .Select(y => new DropdownData()
                    {
                        Text = y.Name,
                        Value = y.Id.ToString()
                    }).ToList();
            }
            else
            {
                return GetCityByStateId(stateId);
            }
        }

        public List<DropdownData> GetStateByCountryId(int countryId, bool useCachedData)
        {
            if (useCachedData)
            {
                var states = CachingService.GetCachedDataByKey(CacheKeyConstants.StateMaster) as List<State>;

                return states.Where(x => x.refCountryId == countryId)
                    .Select(y => new DropdownData()
                    {
                        Text = y.Name,
                        Value = y.Id.ToString()
                    }).ToList();
            }
            else
            {
                return GetStateByCountryId(countryId);
            }
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

        #region private Function
        private List<DropdownData> FilterOutDropdownDataByKey(string key, DataSet ds)
        {
            List<DropdownData> dropDowanData = new List<DropdownData>();
            if (ds.Tables[key].Rows.Count > 0)
            {
                dropDowanData.AddRange(ds.Tables[key].AsEnumerable().Select(row => new DropdownData()
                {
                    Text = Convert.ToString(row.Field<int>("Key")),
                    Value = row.Field<string>("Value")
                }).ToList());
            }


            return dropDowanData;
        }

        private List<DropdownData> GetCityByStateId(int stateId)
        {
            var dtResult = repository.GetCityByStateId(stateId);
            List<DropdownData> dropDowanData = new List<DropdownData>();

            if (dtResult.Rows.Count > 0)
            {
                dropDowanData.AddRange(dtResult.AsEnumerable().Select(row => new DropdownData()
                {
                    Text = row.Field<string>("City"),
                    Value = Convert.ToString(row.Field<int>("myId"))
                }).ToList());
            }

            return dropDowanData;
        }

        private List<DropdownData> GetStateByCountryId(int countryId)
        {
            var dtResult = repository.GetStateByCountryId(countryId);
            List<DropdownData> dropDowanData = new List<DropdownData>();

            if (dtResult.Rows.Count > 0)
            {
                dropDowanData.AddRange(dtResult.AsEnumerable().Select(row => new DropdownData()
                {
                    Text = row.Field<string>("State"),
                    Value = Convert.ToString(row.Field<int>("myId"))
                }).ToList());
            }

            return dropDowanData;
        }
        #endregion
    }
}
