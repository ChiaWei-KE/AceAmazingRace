using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AceAmazingRace.Models
{
    public class PitStop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public RaceEvent RaceEvent { get; set; }
        [Required]
        public Location Location { get; set; }

        public int Order { get; set; } = 0;
        public int Remark { get; set; }
    }
}