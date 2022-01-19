using System;
using System.Collections.Generic;
using System.Text;
using IndividueelApp.Logic.Models;
using IndividueelApp.Interface.Interfaces;
using IndividueelApp.Interface.DTOs;

namespace IndividueelApp.Logic.Manager
{
    public class AppointmentManager
    {
        private IAppointmentDao appointmentDao { get; set; }

        public AppointmentManager(IAppointmentDao _appointmentDao)
        {
            this.appointmentDao = _appointmentDao;
        }

        public void AddAppointment(Appointment appointment)
        {
            AppointmentDto appointmentDto = new AppointmentDto()
            {
                Type = appointment.Type,
                Note = appointment.Note,
                Date = appointment.Date,
                UserID = appointment.UserID
            };
            appointmentDao.AddAppointment(appointmentDto);
        }

        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            List<AppointmentDto> appointmentDTOs = appointmentDao.GetAllAppointments();
            foreach (var appointment1 in appointmentDTOs)
            {
                Appointment appointment = new Appointment()
                {
                   Type = appointment1.Type,
                   Note = appointment1.Note,
                   Date = appointment1.Date,
                   UserID = appointment1.UserID
                };
                appointments.Add(appointment);
            }
            return appointments;
        }
    }
}
