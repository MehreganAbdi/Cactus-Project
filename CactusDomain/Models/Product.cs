﻿using CactusDomain.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusDomain.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public string Size { get; set; }
        public int Cost { get; set; }
        public Brand Brand{ get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Image{ get; set; }
        public int? Off { get; set; }
    }
}
