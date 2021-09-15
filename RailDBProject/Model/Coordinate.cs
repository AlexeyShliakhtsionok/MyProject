using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailDBProject.Model
{
    [Serializable]
    public class Coordinate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int Kilometer { get; set; }
        public int Pkt { get; set; }
        public virtual LocalSection LocalSection { get; set; }
        public virtual ICollection<Defect> Defects { get; set; }
    }
}
