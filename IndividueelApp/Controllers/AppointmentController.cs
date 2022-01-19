using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividueelApp.Models;
using IndividueelApp.Logic.Manager;
using IndividueelApp.Logic.Models;
using IndividueelApp.Interface.Interfaces;

namespace IndividueelApp.Controllers
{
    public class AppointmentController : Controller
    {
        AppointmentManager appointmentManager; 

        public AppointmentController(AppointmentManager appointment)
        {
            this.appointmentManager = appointment;
        }

        public IActionResult Index()
        {
            AllAppointmentsViewModel Allappointments = new AllAppointmentsViewModel();
            List<Appointment> appointments = appointmentManager.GetAllAppointments();
            foreach (var appointment in appointments)
            {
                AppointmentViewModel viewModel = new AppointmentViewModel()
                {
                    Type = appointment.Type,
                    Note = appointment.Note,
                    Date = appointment.Date,
                    UserID = appointment.UserID
                };
                Allappointments.appointments.Add(viewModel);
            }
            return View(Allappointments.appointments);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] AppointmentViewModel viewModel)
        {
            try
            {
                appointmentManager.AddAppointment(new Appointment() { Type = viewModel.Type, Note = viewModel.Note, Date = viewModel.Date, UserID = viewModel.UserID });
                return RedirectToAction("Index", "Appointment");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
