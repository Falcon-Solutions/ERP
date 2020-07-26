using DataAccess;
using Falcon.DataAceess.DataRepository;
using Falcon.Entity;
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

        public List<AppliedProspectModel> GetAllProspectStudent()
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

            List<AppliedProspectModel> prospectStudents = new List<AppliedProspectModel>();

            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    prospectStudents.Add(new AppliedProspectModel
                    {
                        Id = Int32.Parse(row["myId"].ToString()),
                        Name = string.Concat(row["FirstName"].ToString(), " ", row["MiddleName"].ToString(), " ", row["LastName"].ToString()),
                        ApplicationNumber = row["ApplicationNo"].ToString(),
                        ApplicationDate = DateTime.Parse(row["ApplicationDate"].ToString()),
                        AdmissionStatus = row["AdmissionStatus"].ToString(),
                    });
                }
            }

            return prospectStudents;
        }

        public ProspectModel GetProspect(int applicationId)
        {
            ProspectModel prospectStudent = null;

            try
            {
                string[] tableNames = { "prospectStudentTable", "AddressTable" };

                DalParameterList dalParam = new DalParameterList();

                dalParam.Add(new DalParameter()
                {
                    ParameterName = "@Id",
                    ParameterValue = applicationId,
                    ParameterDirection = ParameterDirection.Input,
                    ParameterType = SqlDbType.Int
                });

                var result = dataAccess.GetDataSet(StoredProcedureConstants.GetProspectStudentById, CommandType.StoredProcedure, dalParam, tableNames);

                if (result != null && result.Tables.Count == 2)
                {
                    if (result.Tables[0].Rows.Count > 0 && result.Tables[1].Rows.Count > 0)
                    {
                        var addresses = result.Tables["AddressTable"].AsEnumerable()
                                                .Select(row => new AddressDetails()
                                                {
                                                    Id = row.Field<int>("AddressId"),
                                                    AddressLine = row.Field<string>("AddressLine"),
                                                    CityId = row.Field<int>("CityId"),
                                                    StateId = row.Field<int>("StateId"),
                                                    CountryId = row.Field<int>("CountryId"),/*Convert.ToInt32(row.Field<decimal>("Strength"))*/
                                                    Pin = row.Field<string>("Pincode"),
                                                    AddressType = row.Field<string>("AddressType"),
                                                }).ToList();

                        prospectStudent = new ProspectModel();
                        prospectStudent.Id = result.Tables["prospectStudentTable"].Rows[0].Field<int>("myId");
                        prospectStudent.ApplicationNumber = result.Tables["prospectStudentTable"].Rows[0].Field<string>("applicationno");
                        prospectStudent.ApplicationDate = result.Tables["prospectStudentTable"].Rows[0].Field<DateTime>("ApplicationDate");
                        prospectStudent.FirstName = result.Tables["prospectStudentTable"].Rows[0].Field<string>("firstname");
                        prospectStudent.MiddleName = result.Tables["prospectStudentTable"].Rows[0].Field<string>("middlename");
                        prospectStudent.LastName = result.Tables["prospectStudentTable"].Rows[0].Field<string>("lastname");
                        prospectStudent.AadharId = result.Tables["prospectStudentTable"].Rows[0].Field<string>("AadharId");
                        prospectStudent.AdmissionStatusId = result.Tables["prospectStudentTable"].Rows[0].Field<int>("AdmissionStatusId");
                        prospectStudent.BloodGrpId = result.Tables["prospectStudentTable"].Rows[0].Field<int>("BloodGrpId");
                        prospectStudent.CasteId = result.Tables["prospectStudentTable"].Rows[0].Field<int>("CasteId");
                        prospectStudent.CategoryId = result.Tables["prospectStudentTable"].Rows[0].Field<int>("CategoryId");
                        prospectStudent.ClassId = result.Tables["prospectStudentTable"].Rows[0].Field<int>("ClassId");
                        prospectStudent.DoB = result.Tables["prospectStudentTable"].Rows[0].Field<DateTime>("DOB");
                        prospectStudent.Email = result.Tables["prospectStudentTable"].Rows[0].Field<string>("emailid");
                        prospectStudent.GenderId = result.Tables["prospectStudentTable"].Rows[0].Field<int>("GenderId");
                        prospectStudent.IsPermanentSameAsCurrent = result.Tables["prospectStudentTable"].Rows[0].Field<bool>("IsCurrPermSame");
                        prospectStudent.Notes = result.Tables["prospectStudentTable"].Rows[0].Field<string>("Notes");
                        prospectStudent.ParentEmailId = result.Tables["prospectStudentTable"].Rows[0].Field<string>("ParentEmailId");
                        prospectStudent.ReligionId = result.Tables["prospectStudentTable"].Rows[0].Field<int>("ReligionId");
                        prospectStudent.Phone = result.Tables["prospectStudentTable"].Rows[0].Field<string>("phone");
                        prospectStudent.ParentRelationshipId = result.Tables["prospectStudentTable"].Rows[0].Field<int>("ParentRelationshipId");
                        prospectStudent.ParentPhone = result.Tables["prospectStudentTable"].Rows[0].Field<string>("ParentPhone");
                        prospectStudent.ParentOccupationId = result.Tables["prospectStudentTable"].Rows[0].Field<int>("ParentOccupationId");
                        prospectStudent.ParentName = result.Tables["prospectStudentTable"].Rows[0].Field<string>("ParentName");

                        prospectStudent.CurrentAddress = (from address in addresses
                                                          where address.AddressType == AddressType.Current.ToString()
                                                          select address).First();

                        if (addresses.Exists(x => x.AddressType == AddressType.Permanent.ToString()))
                        {


                            prospectStudent.PermanentAddress = (from address in addresses
                                                                where address.AddressType == AddressType.Permanent.ToString()
                                                                select address).First();
                        }
                        else
                        {
                            prospectStudent.PermanentAddress = null;
                        }

                    }
                }

                return prospectStudent;
            }
            catch (Exception ex)
            {

                throw;
            }
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
                    ParameterName = "@NewProspect",
                    ParameterValue = dataSet.Tables["Prospect"],
                    ParameterType = SqlDbType.Structured
                });

                dalParam.Add(new DalParameter()
                {
                    ParameterName = "@Address",
                    ParameterValue = dataSet.Tables["Address"],
                    ParameterType = SqlDbType.Structured
                });

                dataAccess.ExecuteNonQuery(StoredProcedureConstants.AddNewProspect, CommandType.StoredProcedure, dalParam);
                return Convert.ToBoolean(dalParam.Where(x => x.ParameterName == "@IsSuccess").First().ParameterValue);
            }
            catch (Exception ex)
            {
                return false;
            }
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
