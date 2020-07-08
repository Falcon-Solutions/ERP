using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Entity.Address;

namespace Falcon.Entity.Prospect
{
    ///List prospect students Type:Xo
    public class ProspectStudentModel
    {
        [RenderMode(RenderMode.HideModelOnly)]
        public int Id { get; set; }

        [DisplayName("Application Number")]
        public string ApplicationNumber { get; set; }

        [DisplayName("Student Name")]
        public string Name { get; set; }

        [DisplayName("Application Date")]
        public DateTime ApplicationDate { get; set; }

        [DisplayName("Admission Status")]
        public string AdmissionStatus { get; set; }
    }

    public class ProspectStudentListModel
    {
        public List<ProspectStudentModel> ProspectStudentList { get; set; }
    }

    /// Add prospect student Type:Xi
    public class AddProspectStudentModel
    {
        public string ApplicationNumber { get; set; }
        public DateTime ApplicationDate { get; set; }

        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public int ClassId { get; set; }
        public int GenderId { get; set; }

        public DateTime DoB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string CurrentAddress { get; set; }
        public string PeremenantAddress { get; set; }
        public AddressDetails CurrAddress { get; set; }
        public AddressDetails PerAddress { get; set; }

        public int ReligionId { get; set; }
        public int CasteId { get; set; }
        public int CategoryId { get; set; }
        public int BloodGrpId { get; set; }
        public string AadharId { get; set; }

        public string ParentName { get; set; }
        public string ParentPhone { get; set; }
        public string ParentEmailId { get; set; }
        public string ParentRelationship { get; set; }
        public string ParentOccupation { get; set; }

        public int AdmissionStatusId { get; set; }
        public string Notes { get; set; }
    }

    /// Update prospect student Type:Xi
    public class UpdateProspectStudentModel : AddProspectStudentModel
    {
        public int Id { get; set; }
    }

    ///View prospect student by Application Id Type:Xo
    public class ViewProspectStudentModel : AddProspectStudentModel
    {
        public int Id { get; set; }
        public string AdmissionStatus { get; set; }
        public string ClassName { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string Category { get; set; }
        public string BloodGrp { get; set; }
    }
}
