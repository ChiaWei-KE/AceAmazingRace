using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AceAmazingRace.Models
{
    public class PitStopOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Team Team { get; set; }

        [Required]
        public virtual PitStop PitStop { get; set; }

        [Required]
        public int Order { get; set; }
    }
}