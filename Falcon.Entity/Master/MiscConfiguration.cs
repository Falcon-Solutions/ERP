using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Entity.Master
{
    public class MiscConfigurationViewModel
    {
        public List<MiscConfigurationModel> ViewModel { get; set; }
    }

        public class MiscConfigurationModel
    {
        public string ControllerName { get; set; }
        public List<MasterData> ModelData { get; set; }
    }

    public class MiscConfiguration
    {
        public List<MasterData> relationshipList { get; set; }
        public List<MasterData> occupationList { get; set; }
        public List<MasterData> religionList { get; set; }
        public List<MasterData> categoryList { get; set; }
        public List<MasterData> casteList { get; set; }
    }

    public class MasterData
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
