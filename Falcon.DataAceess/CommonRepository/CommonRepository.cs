using Configuration;
using DataAccess;
using DataAccess.DataProvider;
using Falcon.DataAceess.DataRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;

namespace Falcon.DataAceess
{
    public class CommonRepository : ICommonRepository
    {
        private IAppConfig appConfig;
        private IDataAccess dataAccess;
        public CommonRepository()
        {
            this.appConfig = new AppConfig();
            dataAccess = new MsSqlDataAccess(appConfig.FalconConnectionString);
        }

        public DataSet GetMasterData()
        {
            string[] tableNames = {
                CacheKeyConstants.BloodGrpMaster, CacheKeyConstants.AdmStatusMaster,
                CacheKeyConstants.ReligionMaster, CacheKeyConstants.CasteMaster,
                CacheKeyConstants.CategoryMaster, CacheKeyConstants.SessionMaster,
                CacheKeyConstants.ClassMaster, CacheKeyConstants.SectionMaster,
                CacheKeyConstants.GenderMaster, CacheKeyConstants.CityMaster,
                CacheKeyConstants.StateMaster, CacheKeyConstants.CountryMaster,
                CacheKeyConstants.RelationshipMaster, CacheKeyConstants.OccupationMaster
            };

            return dataAccess.GetDataSet(StoredProcedureConstants.GetMasterData, CommandType.StoredProcedure, tableNames);
        }

        public DataTable GetPostalCodeBySearchKey(string searchKeyword)
        {
            string tableNames = "PostalCodeMaster";

            string commandText = @"SELECT myId, PinCode , Area , City , Tehsil , District , State , Country FROM PinCodeMaster WHERE PinCode = " + searchKeyword;

            return dataAccess.GetDataTable(commandText, CommandType.Text, tableNames);

        }

        public DataTable GetStateByCountryId(int countryId)
        {
            string commandText = @"SELECT myId, State From StateMaster WHERE refCountryId = " + countryId;

            return dataAccess.GetDataTable(commandText, CommandType.Text);

        }

        public DataTable GetCityByStateId(int stateId)
        {
            string commandText = @"SELECT myId, City From CityMaster WHERE refStateId = " + stateId;

            return dataAccess.GetDataTable(commandText, CommandType.Text);
        }


    }
}