﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AceAmazingRace.Models
{
    public class SupportStop
    {
        [Key]
        public int Id { get; set; }
		[Required]
        public string Code { get; set; }
        [Required]
        public virtual Location Location { get; set; }
		[Required]
        public virtual RaceEvent RaceEvent { get; set; }
    }
}