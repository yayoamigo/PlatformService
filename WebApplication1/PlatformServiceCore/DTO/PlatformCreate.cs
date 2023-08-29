﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformServiceCore.DTO
{
    internal class PlatformCreate
    {
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
    }
}

