using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTestOfVMC.Models
{
    public class LocalSectionInfo
    {
        public int LocalSectionId { get; set; }
        [Display(Name = "Наименование перегона")]
        public string LocaSectionName { get; set; }
        [Display(Name = "Путь")]
        public int LocalWayNumber { get; set; }
        [Display(Name = "Участок")]
        public virtual GlobalSection GlobalSection { get; set; }
        public virtual ICollection<Defect> Defects { get; set; }

        public List<GlobalSection> GlobalSectionCollection { get; set; }
        public List<int> SelectedGlobalSections { get; set; }

        public SelectList SelectList { get; set; }
        public MultiSelectList MultiSelectList { get; set; }
    }
}
