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
        bool AddOcccupation(int id, string occupation);
        bool UpdateOccupation(int id, string occupation);
        bool DeleteOccupation(int id);

        bool AddRelationship(int id, string relationship);
        bool UpdateRelationship(int id, string relationship);
        bool DeleteRelationship(int id);


        bool AddReligion(int id, string religion);
        bool UpdateReligion(int id, string religion);
        bool DeleteReligion(int id);


        bool AddCaste(int id, string caste);
        bool UpdateCaste(int id, string caste);
        bool DeleteCaste(int id);


        bool AddCategory(int id, string category);
        bool UpdateCategory(int id, string category);
        bool DeleteCategory(int id);

        DataSet GetClassesMasterConfiguration();

        bool UpdateClassesMasterConfiguration(DataTable classesXRef);
    }
    
}
