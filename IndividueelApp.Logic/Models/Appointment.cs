using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IndividueelApp.Logic.Models
{
    public class Appointment
    {
        [Key]
        public string Type { get; set; }
        public string Note { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
    }
}
