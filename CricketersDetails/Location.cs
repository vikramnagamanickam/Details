﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CricketersDetails
{
    public class Location
    {
        [Key]
        public long LocationId { get; set; }

        public string Name { get; set; }

        public string DistrictName { get; set; }

        public string Description { get; set; }
    }
}
