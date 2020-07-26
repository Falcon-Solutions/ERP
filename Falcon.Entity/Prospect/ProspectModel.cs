using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Entity.Address;

namespace Falcon.Entity.Prospect
{
    ///List prospect students Type:Xo
    public class AppliedProspectModel
    {
        public int Id { get; set; }

        public string ApplicationNumber { get; set; }

        public string Name { get; set; }

        public DateTime ApplicationDate { get; set; }

        public string AdmissionStatus { get; set; }
    }

    /// Add prospect student Type:Xi
    public class ProspectModel
    {
        public int Id { get; set; }
        public string ApplicationNumber { get; set; }
        public DateTime ApplicationDate { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName); }
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        
        public int ClassId { get; set; }
        public int GenderId { get; set; }

        public DateTime DoB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public AddressDetails CurrentAddress { get; set; }
        public AddressDetails PermanentAddress { get; set; }
        public bool IsPermanentSameAsCurrent { get; set; }

        public int ReligionId { get; set; }
        public int CasteId { get; set; }
        public int CategoryId { get; set; }
        public int BloodGrpId { get; set; }
        public string AadharId { get; set; }

        public string ParentName { get; set; }
        public string ParentPhone { get; set; }
        public string ParentEmailId { get; set; }
        public int ParentRelationshipId { get; set; }
        public int ParentOccupationId { get; set; }

        public int AdmissionStatusId { get; set; }
        public string Notes { get; set; }

        public FormAction ActionType { get; set; }
    }
}
