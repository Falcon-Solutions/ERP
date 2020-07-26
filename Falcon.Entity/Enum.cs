using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Entity
{
    public enum AddressType
    {
        Permanent = 1,
        Current = 2,
    }

    public enum AdmissionStatus
    {
        Applied = 1,
        Pending = 2,
        Denied = 3,
        Hold = 4,
        Confirmed = 5,
        Draft = 6,
    }

    public enum FormAction
    {
        Add = 1,
        Edit = 2,
        Delete = 3,
        Get = 4,
        List = 5,
    }
}
