using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Entity.Prospect;

namespace Falcon.Service.Prospect
{
    public interface IProspectStudentService
    {
        List<AppliedProspectModel> GetProspectStudentList();
        ProspectModel GetProspectStudentDetailsById(int Id);
        bool DeleteProspectStudent(int ProspectStudentId);
        bool AddProspectStudent(ProspectModel prospectStudentModel);
    }
}