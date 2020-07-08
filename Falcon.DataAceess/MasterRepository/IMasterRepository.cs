using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Falcon.DataAceess.DataRepository
{
    public interface IMasterRepository
    {
        DataSet GetMiscConfigurationData();
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

        DataSet GetClassesMasterConfiguration();

        bool UpdateClassesMasterConfiguration(DataTable classesXRef);
    }
    
}
