using System;
using System.Collections.Generic;
using System.Text;
using IndividueelApp.Interface.DTOs;

namespace IndividueelApp.Interface.Interfaces
{
    public interface IAppointmentDao
    {
        public void AddAppointment(AppointmentDto appointmentDto);
        public List<AppointmentDto> GetAllAppointments();
        public AppointmentDto GetAppointment(int id);
    }
}
