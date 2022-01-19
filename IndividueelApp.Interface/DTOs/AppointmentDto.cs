using System;
using System.Collections.Generic;
using System.Text;

namespace IndividueelApp.Interface.DTOs
{
    public class AppointmentDto
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
