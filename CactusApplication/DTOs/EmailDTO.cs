using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CactusApplication.DTOs
{
    public class EmailDTO
    {
        public string Subject { get; set; } = "No Subject";
        public string Reciever { get; set; }
        public string message { get; set; } = "No Message";
    }
}
