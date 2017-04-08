﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AceAmazingRace.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public RaceEvent RaceEvent { get; set; }
		[Required]
        public string Profile { get; set; }

        public byte[] Photo { get; set; }
    }
}