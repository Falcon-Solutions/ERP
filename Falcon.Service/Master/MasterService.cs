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
                                        Strength = 0/*Convert.ToInt32(row.Field<int>("Strength"))*/
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
                    row["UT_CheckedId"] = Convert.ToInt32(classArray[0]);
                    row["UT_ClassID"] = Convert.ToInt32(classArray[2]);
                    row["UT_SectionId"] = Convert.ToInt32(classArray[3]);
                    row["UT_SessionID"] = Convert.ToInt32(classArray[1]);

                    classXrefDataTable.Rows.Add(row);
                }
            }

            return repository.UpdateClassesMasterConfiguration(classXrefDataTable);
        }
    }
}
