using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTestOfVMC.Models
{
    public class DefectoScopeInfo
    {
        public int DefectoScopeId { get; set; }
        [Required]
        public int SerialNumber { get; set; }
        [Required]
        public DefectoScopeType DefectoScopeType { get; set; }
        public string DefectoScopeName { get; set; }
        public DateTime LastMaintenansProcedure { get; set; }
        public virtual Organisation Organisation { get; set; }
        public virtual ICollection<Operator> Operators { get; set; }
    }
}
