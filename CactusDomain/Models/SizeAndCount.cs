using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusDomain.Models
{
    public class SizeAndCount
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
        public int Count { get; set; }

    }
}
