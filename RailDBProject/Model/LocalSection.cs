using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailDBProject.Model
{
    [Serializable]
    public class LocalSection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LocalSectoionId { get; set; }
        [Required]
        [MaxLength(50)]
        public string LocalSectionName { get; set; }
        [Required]
        public int LocalWayNumber { get; set; }

        public virtual GlobalSection GlobalSection { get; set; }
        public virtual ICollection<Defect> Defects  { get; set; }
    }
}
