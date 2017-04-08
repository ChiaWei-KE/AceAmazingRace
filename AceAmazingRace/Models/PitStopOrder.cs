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
        public Team Team { get; set; }

        [Required]
        public PitStop PitStop { get; set; }

        [Required]
        public int Order { get; set; }
    }
}