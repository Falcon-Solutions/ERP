using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Entity.Prospect;
using Falcon.DataAceess.ProspectRepository;
using Configuration;
using System.Data;
using Utility;
using Falcon.Entity;

namespace Falcon.Service.Prospect
{
    public class ProspectStudentService : IProspectStudentService
    {
        IProspectStudentRepository repository { get; set; }

        private IAppConfig appConfig;

        public ProspectStudentService(IProspectStudentRepository repository, IAppConfig appConfig)
        {
            this.repository = repository;
            this.appConfig = appConfig;
        }

        public List<AppliedProspectModel> GetProspectStudentList()
        {
            return repository.GetAllProspectStudent();
        }

        public ProspectModel GetProspectStudentDetailsById(int prospectStudentId)
        {
            return repository.GetProspect(prospectStudentId);
        }

        public bool DeleteProspectStudent(int prospectStudentId)
        {
            return repository.DeleteProspectStudent(prospectStudentId);
        }

        public bool AddProspectStudent(ProspectModel prospectStudentModel)
        {
            //Generate Datatable which match the UserDefinedTableType "UT_ProspectStudent"

            DataTable prospectDataTable = new DataTable("Prospect");
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ApplicationNo", DataType = typeof(string), Caption = "ApplicationNo", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_FirstName", DataType = typeof(string), Caption = "FirstName", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_MiddleName", DataType = typeof(string), Caption = "MiddleName", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_LastName", DataType = typeof(string), Caption = "LastName", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Class", DataType = typeof(int), Caption = "ClassId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Sex", DataType = typeof(int), Caption = "GenderId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_DOB", DataType = typeof(DateTime), Caption = "DOB", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Phone", DataType = typeof(string), Caption = "PhoneNumber", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_EmailId", DataType = typeof(string), Caption = "EmailId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Religion", DataType = typeof(int), Caption = "ReligionId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Caste", DataType = typeof(int), Caption = "CasteId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Category", DataType = typeof(int), Caption = "CategoryId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_BloodGrp", DataType = typeof(int), Caption = "BloodGrpId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_AadharId", DataType = typeof(string), Caption = "AadharId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ParentName", DataType = typeof(string), Caption = "ParentName", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ParentPhone", DataType = typeof(string), Caption = "ParentName", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ParentEmailId", DataType = typeof(string), Caption = "ParentEmailId", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ParentRelationship", DataType = typeof(int), Caption = "ParentRelationship", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ParentOccupation", DataType = typeof(int), Caption = "ParentOccupation", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ApplicationDate", DataType = typeof(DateTime), Caption = "ApplicationDate", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_AdmissionStatus", DataType = typeof(int), Caption = "AdmissionStatus", });
            prospectDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Notes", DataType = typeof(string), Caption = "Notes", });

            DataRow prospectRow = prospectDataTable.NewRow();
            prospectRow["UT_ApplicationNo"] = NumberGenerator.RandomDigits(8);
            prospectRow["UT_FirstName"] = prospectStudentModel.FirstName;
            prospectRow["UT_MiddleName"] = prospectStudentModel.MiddleName;
            prospectRow["UT_LastName"] = prospectStudentModel.LastName;
            prospectRow["UT_Class"] = prospectStudentModel.ClassId;
            prospectRow["UT_Sex"] = prospectStudentModel.GenderId;
            prospectRow["UT_DOB"] = prospectStudentModel.DoB.Date;
            prospectRow["UT_Phone"] = prospectStudentModel.Phone;
            prospectRow["UT_EmailId"] = prospectStudentModel.Email;
            prospectRow["UT_Religion"] = prospectStudentModel.ReligionId;
            prospectRow["UT_Caste"] = prospectStudentModel.CasteId;
            prospectRow["UT_Category"] = prospectStudentModel.CategoryId;
            prospectRow["UT_BloodGrp"] = prospectStudentModel.BloodGrpId;
            prospectRow["UT_AadharId"] = prospectStudentModel.AadharId;
            prospectRow["UT_ParentName"] = prospectStudentModel.ParentName;
            prospectRow["UT_ParentPhone"] = prospectStudentModel.ParentPhone;
            prospectRow["UT_ParentEmailId"] = prospectStudentModel.ParentEmailId;
            prospectRow["UT_ParentRelationship"] = prospectStudentModel.ParentRelationshipId;
            prospectRow["UT_ParentOccupation"] = prospectStudentModel.ParentOccupationId;
            prospectRow["UT_ApplicationDate"] = DateTime.Now.Date;
            prospectRow["UT_AdmissionStatus"] = Convert.ToInt32(AdmissionStatus.Applied);
            prospectRow["UT_Notes"] = prospectStudentModel.Notes;

            prospectDataTable.Rows.Add(prospectRow);

            DataTable addressDataTable = new DataTable("Address");
            addressDataTable.Columns.Add(new DataColumn { ColumnName = "UT_AddressId", DataType = typeof(int), Caption = "AddressId", });
            addressDataTable.Columns.Add(new DataColumn { ColumnName = "UT_AddressLine", DataType = typeof(string), Caption = "AddressLine", });
            addressDataTable.Columns.Add(new DataColumn { ColumnName = "UT_CityId", DataType = typeof(int), Caption = "CityId", });
            addressDataTable.Columns.Add(new DataColumn { ColumnName = "UT_Pincode", DataType = typeof(string), Caption = "Pincode", });
            addressDataTable.Columns.Add(new DataColumn { ColumnName = "UT_AddressType", DataType = typeof(string), Caption = "AddressType", });

            DataRow currentAddressRow = addressDataTable.NewRow();
            currentAddressRow["UT_AddressId"] = prospectStudentModel.CurrentAddress.Id;
            currentAddressRow["UT_AddressLine"] = prospectStudentModel.CurrentAddress.AddressLine;
            currentAddressRow["UT_CityId"] = prospectStudentModel.CurrentAddress.CityId;
            currentAddressRow["UT_Pincode"] = prospectStudentModel.CurrentAddress.Pin;
            currentAddressRow["UT_AddressType"] = AddressType.Current.ToString();

            addressDataTable.Rows.Add(currentAddressRow);

            if (!prospectStudentModel.IsPermanentSameAsCurrent)
            {
                DataRow permAddressRow = addressDataTable.NewRow();
                permAddressRow["UT_AddressId"] = prospectStudentModel.PermanentAddress.Id;
                permAddressRow["UT_AddressLine"] = prospectStudentModel.PermanentAddress.AddressLine;
                permAddressRow["UT_CityId"] = prospectStudentModel.PermanentAddress.CityId;
                permAddressRow["UT_Pincode"] = prospectStudentModel.PermanentAddress.Pin;
                permAddressRow["UT_AddressType"] = AddressType.Permanent.ToString();

                addressDataTable.Rows.Add(permAddressRow);
            }


            var dataSet = new DataSet();

            dataSet.Tables.Add(prospectDataTable);
            dataSet.Tables.Add(addressDataTable);

            return repository.AddProspectStudent(dataSet);
        }
    }
}
