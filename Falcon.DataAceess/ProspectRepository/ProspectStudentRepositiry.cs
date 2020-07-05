using DataAccess;
using Falcon.DataAceess.DataRepository;
using Falcon.Entity.Address;
using Falcon.Entity.Prospect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.DataAceess.ProspectRepository
{
    public class ProspectStudentRepositiry : IProspectStudentRepository
    {
        IDataAccess dataAccess = null;

        public ProspectStudentRepositiry(IRepository repository)
        {
            dataAccess = repository.FalconDataAccess;
        }

        public List<ProspectStudentModel> GetAllProspectStudent()
        {
            string tableNames = "AllProspectStudents";

            string commandText = @"SELECT PS.myId 
                                         ,PS.ApplicationNo
                                         ,PS.FirstName
                                         ,PS.MiddleName
                                         ,PS.LastName
                                         ,PS.ApplicationDate
                                         ,ASM.AdmissionStatus
                                    FROM ProspectStudent PS
                                    JOIN AdmStatusMaster ASM
                                        ON PS.AdmissionStatusId = ASM.myId";

            var result = dataAccess.GetDataTable(commandText, CommandType.Text, tableNames);

            List<ProspectStudentModel> prospectStudents = new List<ProspectStudentModel>();

            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    prospectStudents.Add(new ProspectStudentModel
                    {
                        Id = Int32.Parse(row["myId"].ToString()),
                        Name = string.Concat(row["FirstName"].ToString(), " ",row["MiddleName"].ToString(), " ", row["LastName"].ToString()),
                        ApplicationNumber = row["ApplicationNo"].ToString(),
                        ApplicationDate = DateTime.Parse(row["ApplicationDate"].ToString()),
                        AdmissionStatus = row["AdmissionStatus"].ToString(),
                    });
                }
            }

            return prospectStudents;
        }

        public ViewProspectStudentModel ViewProspectStudent(int applicationId)
        {
            string tableName = "prospectStudentTable";

            DalParameterList dalParam = new DalParameterList();

            dalParam.Add(new DalParameter()
            {
                ParameterName = "@Id",
                ParameterValue = applicationId,
                ParameterDirection = ParameterDirection.Input,
                ParameterType = SqlDbType.Int
            });

            var result = dataAccess.GetDataTable(StoredProcedureConstants.GetProspectStudentById, CommandType.StoredProcedure, dalParam, tableName);

            ViewProspectStudentModel prospectStudent = null;

            if (result != null && result.Rows.Count > 0)
            {
                prospectStudent = new ViewProspectStudentModel();

                prospectStudent.Id = Int32.Parse(result.Rows[0]["myId"].ToString());
                prospectStudent.FirstName = result.Rows[0]["FirstName"].ToString();
                prospectStudent.MiddleName = result.Rows[0]["MiddleName"].ToString();
                prospectStudent.LastName = result.Rows[0]["LastName"].ToString();
                prospectStudent.ApplicationNumber = result.Rows[0]["ApplicationNo"].ToString();
                prospectStudent.ApplicationDate = Convert.ToDateTime(result.Rows[0]["ApplicationDate"].ToString());
                prospectStudent.AadharId = result.Rows[0]["AadharId"].ToString();
                prospectStudent.ClassName = result.Rows[0]["Class"].ToString();
                prospectStudent.Gender = result.Rows[0]["Sex"].ToString();
                prospectStudent.DoB = Convert.ToDateTime(result.Rows[0]["DOB"].ToString());
                prospectStudent.Phone = result.Rows[0]["Phone"].ToString();
                prospectStudent.Email = result.Rows[0]["EmailId"].ToString();
                prospectStudent.CompleteCurrentAddress = result.Rows[0]["CurrentAddress"].ToString();
                prospectStudent.CompletePermanentAddress = result.Rows[0]["PermanentAddress"].ToString();
                prospectStudent.Religion = result.Rows[0]["religion"].ToString();
                prospectStudent.Caste = result.Rows[0]["caste"].ToString();
                prospectStudent.Category = result.Rows[0]["category"].ToString();
                prospectStudent.BloodGrp = result.Rows[0]["BloodGroup"].ToString();
                prospectStudent.AdmissionStatus = result.Rows[0]["AdmissionStatus"].ToString();
                prospectStudent.FullName = string.Concat(result.Rows[0]["FirstName"].ToString(), " ", result.Rows[0]["MiddleName"].ToString(), " ", result.Rows[0]["LastName"].ToString());
                prospectStudent.Notes = result.Rows[0]["Notes"].ToString();
                prospectStudent.ParentEmailId = result.Rows[0]["ParentEmailId"].ToString();
                prospectStudent.ParentName = result.Rows[0]["ParentName"].ToString();
                prospectStudent.ParentOccupation = result.Rows[0]["ParentOccupation"].ToString();
                prospectStudent.ParentPhone = result.Rows[0]["ParentPhone"].ToString();
                prospectStudent.ParentRelationship = result.Rows[0]["ParentRelationship"].ToString();
            }

            return prospectStudent;
        }

        public bool AddProspectStudent(DataSet dataSet)
        {
            try
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
                    ParameterName = "@ClassXref",
                    ParameterValue = dataSet.Tables["Prospect"],
                    ParameterType = SqlDbType.Structured
                });

                dataAccess.ExecuteNonQuery(StoredProcedureConstants.UpdateClassConfiguration, CommandType.StoredProcedure, dalParam);
                var isSuccess = Convert.ToBoolean(dalParam.Where(x => x.ParameterName == "@IsSuccess").First().ParameterValue);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }

        public bool UpdateProspectStudent(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProspectStudent(int ProspectStudentId)
        {
            DalParameterList dalParam = new DalParameterList();

            dalParam.Add(new DalParameter()
            {
                ParameterName = "@ProspectId",
                ParameterValue = ProspectStudentId,
                ParameterDirection = ParameterDirection.Input,
                ParameterType = SqlDbType.Int
            });

            var result = dataAccess.ExecuteNonQuery(StoredProcedureConstants.DeleteProsepctStudent, CommandType.StoredProcedure, dalParam);

            return result > 0;
        }
    }
}
