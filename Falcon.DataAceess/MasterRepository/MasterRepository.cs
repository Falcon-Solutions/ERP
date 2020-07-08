using System;
using System.Data;
using System.Linq;
using Configuration;
using DataAccess;
using Enum;

namespace Falcon.DataAceess.DataRepository
{
    public class MasterRepository : IMasterRepository
    {
        IDataAccess dataAccess = null;

        public  DataSet GetMiscConfigurationData()
        {
            string[] tableNames = { "OccupationMaster", "RelationshipMaster", "ReligionMaster", "CategoryMaster","CasteMaster" };

            return dataAccess.GetDataSet(StoredProcedureConstants.GetMiscConfigData, CommandType.StoredProcedure, tableNames);

        }



        public MasterRepository(IRepository repository)
        {
            dataAccess = repository.FalconDataAccess;
        }

        public bool AddCaste(string caste)
        {
            try
            {

                string commandText = string.Format(@"Insert INTO casteMaster values({0})", caste);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool AddCategory(string category)
        {
            try
            {

                string commandText = string.Format(@"Insert INTO categoryMaster values({0} )", category);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool AddOcccupation(string occupation)
        {
            try
            {
                string commandText = string.Format(@"Insert INTO occupationMaster values({0})", occupation);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool AddRelationship(string relationship)
        {
            try
            {
                string commandText = string.Format(@"Insert INTO [dbo].[relationshipMaster](RelationShip) values('{0}')",relationship);
                
                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool AddReligion(string religion)
        {
            try
            {
                string commandText = string.Format(@"Insert INTO religionMaster values({0})",religion);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool DeleteCaste(int id)
        {
            try
            {
                string commandText = string.Format(@"Delete from casteMaster where myId ={0}", id);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                string commandText = string.Format(@"Delete from categoryMaster where myId ={0}", id);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteOccupation(int id)
        {
            try
            {
                string commandText = string.Format(@"Delete from occupationMaster where myId ={0}", id);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteRelationship(int id)
        {
            try
            {
                string commandText = string.Format(@"Delete from relationshipMaster where myId ={0}", id);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteReligion(int id)
        {
            try
            {
                string commandText = string.Format(@"Delete from religionMaster where myId ={0}", id);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public DataSet GetClassesMasterConfiguration()
        {
            string[] tableNames = { "SessionMaster", "ClassMaster", "SectionMaster", "ClassXref" };

            return dataAccess.GetDataSet(StoredProcedureConstants.GetClassConfiguration, CommandType.StoredProcedure, tableNames);
        }

        public bool UpdateCaste(int id, string caste)
        {
            try
            {
                string commandText = string.Format(@"Update casteMaster set caste ={1} where myid ={0}", id, caste);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool UpdateCategory(int id, string category)
        {
            try
            {
                string commandText = string.Format(@"Update categoryMaster set category ={1} where myid ={0}", id, category);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool UpdateClassesMasterConfiguration(DataTable classesXRef)
        {
            DalParameterList dalParam = new DalParameterList();

            dalParam.Add(new DalParameter()
            {
                ParameterName = "@IsSuccess",
                ParameterValue = DBNull.Value,
                ParameterDirection = ParameterDirection.Output,
                ParameterType = SqlDbType.Bit
            });

            dalParam.Add(new DalParameter()
            {
                ParameterName = "@ClassX",
                ParameterValue = classesXRef,
                ParameterType = SqlDbType.Structured
            });

            dataAccess.ExecuteNonQuery(StoredProcedureConstants.UpdateClassConfiguration, CommandType.StoredProcedure, dalParam);
            var isSuccess = Convert.ToBoolean(dalParam.Where(x => x.ParameterName == "@IsSuccess").First().ParameterValue);

            return isSuccess;
        }

        public bool UpdateOccupation(int id, string occupation)
        {
            try
            {
                string commandText = string.Format(@"Update occupationMaster set caste ={1} where myid ={0}", id, occupation);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool UpdateRelationship(int id, string relationship)
        {
            try
            {
                string commandText = string.Format(@"Update relationshipMaster set caste ={1} where myid ={0}", id, relationship);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool UpdateReligion(int id, string religion)
        {
            try
            {
                string commandText = string.Format(@"Update religionMaster set caste ={1} where myid ={0}", id, religion);

                return dataAccess.ExecuteNonQuery(commandText, CommandType.Text) > 0 ? true : false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
