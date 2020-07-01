using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration;
using Falcon.DataAceess.DataRepository;
using Falcon.DataAceess.ProspectRepository;
using Falcon.Entity.Master;

namespace Falcon.Service.MasterRepository
{
    public class MasterService : IMasterService
    {
        IMasterRepository repository { get; set; }

        private IAppConfig appConfig;

        public MasterService(IMasterRepository repository, IAppConfig appConfig)
        {
            this.repository = repository;
            this.appConfig = appConfig;
        }

        public MiscConfiguration GetMiscConfigurationData()
        {
            var result = repository.GetMiscConfigurationData();

            var model = new MiscConfiguration();

            model.relationshipList = new List<MasterData>();
            model.occupationList  = new List<MasterData>();
            model.religionList  = new List<MasterData>();
            model.categoryList = new List<MasterData>();
            model.casteList = new List<MasterData>();

            model.relationshipList.AddRange(result.Tables["RelationshipMaster"].AsEnumerable()
                                    .Select(row => new MasterData()
                                    {
                                        Id = Convert.ToInt32(row.Field<int>("myId")),
                                        Name = row.Field<string>("RelationShip")
                                    }));

            model.occupationList.AddRange(result.Tables["occupationMaster"].AsEnumerable()
                                    .Select(row => new MasterData()
                                    {
                                        Id = Convert.ToInt32(row.Field<int>("myId")),
                                        Name = row.Field<string>("Occupation")
                                    }));

            model.religionList.AddRange(result.Tables["ReligionMaster"].AsEnumerable()
                                    .Select(row => new MasterData()
                                    {
                                        Id = Convert.ToInt32(row.Field<int>("myId")),
                                        Name = row.Field<string>("Religion")
                                    }));

            model.categoryList.AddRange(result.Tables["CategoryMaster"].AsEnumerable()
                                    .Select(row => new MasterData()
                                    {
                                        Id = Convert.ToInt32(row.Field<int>("myId")),
                                        Name = row.Field<string>("Category")

                                    }));

            model.casteList.AddRange(result.Tables["CasteMaster"].AsEnumerable()
                                    .Select(row => new MasterData()
                                    {
                                        Id = Convert.ToInt32(row.Field<int>("myId")),
                                        Name = row.Field<string>("Caste")

                                    }));
            return model;
        }

        public ClassConfiguration GetClassConfiguration()
        {
            var result = repository.GetClassesMasterConfiguration();

            var model = new ClassConfiguration();

            model.sessionList = new List<SessionModel>();
            model.classList = new List<ClassModel>();
            model.sectionList = new List<SectionModel>();
            model.ClassXrefList = new List<ClassXref>();

            model.sessionList.AddRange(result.Tables["SessionMaster"].AsEnumerable()
                                    .Select(row => new SessionModel()
                                    {
                                        myId = Convert.ToInt32(row.Field<int>("myId")),
                                        Name = row.Field<string>("SessionName")
                                    }));

            model.classList.AddRange(result.Tables["ClassMaster"].AsEnumerable()
                                    .Select(row => new ClassModel()
                                    {
                                        myId = Convert.ToInt32(row.Field<int>("myId")),
                                        Name = row.Field<string>("ClassName")
                                    }));

            model.sectionList.AddRange(result.Tables["SectionMaster"].AsEnumerable()
                                    .Select(row => new SectionModel()
                                    {
                                        myId = Convert.ToInt32(row.Field<int>("myId")),
                                        Name = row.Field<string>("SectionCode")
                                    }));

            model.ClassXrefList.AddRange(result.Tables["ClassXref"].AsEnumerable()
                                    .Select(row => new ClassXref()
                                    {
                                        myId = Convert.ToInt32(row.Field<int>("myId")),
                                        ClassId = Convert.ToInt32(row.Field<int>("refClassId")),
                                        SectionId = Convert.ToInt32(row.Field<int>("refSecId")),
                                        SessionId = Convert.ToInt32(row.Field<int>("refSessionId")),
                                        Strength = 0/*Convert.ToInt32(row.Field<decimal>("Strength"))*/
                                    }));

            return model;
        }

        public bool UpdateClassConfig(string[] AllKeys)
        {
            DataTable classXrefDataTable = new DataTable("ClassXref");
            classXrefDataTable.Columns.Add(new DataColumn { ColumnName = "UT_CheckedId", DataType = typeof(int) });
            classXrefDataTable.Columns.Add(new DataColumn { ColumnName = "UT_ClassID", DataType = typeof(int) });
            classXrefDataTable.Columns.Add(new DataColumn { ColumnName = "UT_SectionId", DataType = typeof(int) });
            classXrefDataTable.Columns.Add(new DataColumn { ColumnName = "UT_SessionID", DataType = typeof(int) });

            DataRow row;

            foreach (var classX in AllKeys)
            {
                var classArray = classX.Split('-');

                if (classArray[0] == "0")
                {
                    row = classXrefDataTable.NewRow();
                    row["UT_CheckedId"] = Convert.ToDecimal(classArray[0]);
                    row["UT_ClassID"] = Convert.ToDecimal(classArray[2]);
                    row["UT_SectionId"] = Convert.ToDecimal(classArray[3]);
                    row["UT_SessionID"] = Convert.ToDecimal(classArray[1]);

                    classXrefDataTable.Rows.Add(row);
                }
            }

            return repository.UpdateClassesMasterConfiguration(classXrefDataTable);
        }

        public bool AddOcccupation(int id, string occupation)
        {
            return repository.AddOcccupation(id, occupation);
        }

        public bool UpdateOccupation(int id, string occupation)
        {
            return repository.UpdateOccupation(id, occupation);
        }

        public bool DeleteOccupation(int id)
        {
            return repository.DeleteOccupation(id);
        }

        public bool AddRelationship(int id, string relationship)
        {
            return repository.AddRelationship(id, relationship);
        }

        public bool UpdateRelationship(int id, string relationship)
        {
            return repository.UpdateRelationship(id, relationship);
        }

        public bool DeleteRelationship(int id)
        {
            return repository.DeleteRelationship(id);
        }

        public bool AddReligion(int id, string religion)
        {
            return repository.AddReligion(id, religion);
        }

        public bool UpdateReligion(int id, string religion)
        {
            return repository.UpdateReligion(id, religion);
        }

        public bool DeleteReligion(int id)
        {
            return repository.DeleteReligion(id);
        }

        public bool AddCaste(int id, string caste)
        {
            return repository.AddCaste(id, caste);
        }

        public bool UpdateCaste(int id, string caste)
        {
            return repository.UpdateCaste(id, caste);
        }

        public bool DeleteCaste(int id)
        {
            return repository.DeleteCaste(id);
        }

        public bool AddCategory(int id, string category)
        {
            return repository.AddCategory(id, category);
        }

        public bool UpdateCategory(int id, string category)
        {
            return repository.UpdateCategory(id, category);
        }

        public bool DeleteCategory(int id)
        {
            return repository.DeleteCategory(id);
        }
    }
}
