﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHeroes.Models
{
    public class Heroes
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name="Alter Ego")]
        public string AlterEgo { get; set; }
        public string PrimaryAbility { get; set; }
        public string SecondaryAbility{ get; set; }
        public string Catchphrase{ get; set; }
        
    }
}