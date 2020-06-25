using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Entity.Master
{
    public class MiscConfiguration
    {
        public List<RelationshipModel> relationshipList { get; set; }
        public List<OccupationModel> occupationList { get; set; }
        public List<ReligionModel> religionList { get; set; }
        public List<CategoryModel> categoryList { get; set; }
        public List<CasteModel> casteList { get; set; }
    }

    public class RelationshipModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class OccupationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class ReligionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class CasteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}
