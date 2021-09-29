using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTestOfVMC.Models
{
    public class GlobalSectionInfo
    {
        public int GlobalSectId { get; set; }
        public string GlobaSectionName { get; set; }
        public int GlobalWayNumber { get; set; }
        public int OrganisationId { get; set; }
        public int? SubOrgId { get; set; }
        public virtual ICollection<Organisation> Organisations { get; set; }
        public virtual ICollection<LocalSection> LocalSections { get; set; }


        public List<GlobalSection> GlobalSectionCollection { get; set; }
        public List<int> SelectedGlobalSection { get; set; }
        public SelectList SelectList { get; set; }
        public MultiSelectList MultiSelectList { get; set; }
    }
}
