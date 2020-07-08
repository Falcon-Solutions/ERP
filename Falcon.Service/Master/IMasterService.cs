using Falcon.Entity.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Service.MasterRepository
{
    public interface IMasterService
    {
        MiscConfiguration GetMiscConfigurationData();

        bool AddOcccupation(string occupation);
        bool UpdateOccupation(int id, string occupation);
        bool DeleteOccupation(int id);

        bool AddRelationship(string relationship);
        bool UpdateRelationship(int id, string relationship);
        bool DeleteRelationship(int id);


        bool AddReligion(string religion);
        bool UpdateReligion(int id, string religion);
        bool DeleteReligion(int id);


        bool AddCaste(string caste);
        bool UpdateCaste(int id, string caste);
        bool DeleteCaste(int id);


        bool AddCategory(string category);
        bool UpdateCategory(int id, string category);
        bool DeleteCategory(int id);

        ClassConfiguration GetClassConfiguration();
        bool UpdateClassConfig(string[] AllKeys);
    }
}
