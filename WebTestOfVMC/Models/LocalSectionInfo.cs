using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTestOfVMC.Models
{
    public class LocalSectionInfo
    {
        public int LocalSectionId { get; set; }
       
        public string LocaSectionName { get; set; }
        public int LocalWayNumber { get; set; }

        public virtual GlobalSection GlobalSection { get; set; }
        public virtual ICollection<Defect> Defects { get; set; }

        public List<GlobalSection> GlobalSectionCollection { get; set; }
        public List<int> SelectedGlobalSections { get; set; }

        public SelectList SelectList { get; set; }
        public MultiSelectList MultiSelectList { get; set; }
    }
}
