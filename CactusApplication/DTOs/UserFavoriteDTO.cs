using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.DTOs
{
    public class UserFavoriteDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
}
