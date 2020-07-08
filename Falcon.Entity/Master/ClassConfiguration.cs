using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Entity.Master
{

    public class ClassConfiguration
    {
        public List<SessionModel> sessionList;
        public List<ClassModel> classList;
        public List<SectionModel> sectionList;
        public List<ClassXref> ClassXrefList;
    }

    
    public class SessionModel 
    {
        [RenderMode(RenderMode.HideModelOnly)]
        public int myId { get; set; }

        [DisplayName("Session Name")]
        public string Name { get; set; }
    }

    public class ClassModel 
    {
        [RenderMode(RenderMode.HideModelOnly)]
        public int myId { get; set; }

        [DisplayName("Class Name")]
        public string Name { get; set; }
    }

    public class SectionModel
    {
        [RenderMode(RenderMode.HideModelOnly)]
        public int myId { get; set; }

        [DisplayName("Section Name")]
        public string Name { get; set; }
    }

    public class ClassXref : DynamicObject
    {
        public int myId { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public int SessionId { get; set; }
        public int Strength { get; set; }


    }

}