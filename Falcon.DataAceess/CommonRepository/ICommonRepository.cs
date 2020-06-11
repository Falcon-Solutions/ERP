using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.DataAceess
{
    public interface ICommonRepository
    {
        DataSet GetMasterData();
        DataTable GetPostalCodeBySearchKey(string searchKeyword);
        DataTable GetStateByCountryId(int countryId);
        DataTable GetCityByStateId(int cityId);
    }
}
