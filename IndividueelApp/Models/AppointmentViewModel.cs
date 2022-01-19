using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndividueelApp.Models
{
    public class AppointmentViewModel
    {
        [Key]
        public string Type { get; set; }
        public string Note { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
    }
}
