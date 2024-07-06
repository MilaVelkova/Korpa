﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Integration
{
    public class Car
    {
        public Guid Id { get; set; }
        [Required]
        public string? CarModel { get; set; }
        [Required]
        public string? CarManufacturer { get; set; }
        [Required]
        public string? CarImage { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Rating { get; set; }
    }
}
