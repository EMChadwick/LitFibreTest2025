using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using litfibretestapi.Models;
using litfibretestapi.Enums;       
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using litfibretestapi.Interfaces;   
using litfibretestapi.DTOs; 



namespace litfibretestapi.Controllers
{
    [ApiController]
    [Route("api/appointment")]
    public class AppointmentController : ControllerBase
    {

        private IMemoryDatabase<Appointment> _appointmentDb;
        public AppointmentController(IMemoryDatabase<Appointment> appointmentDb)
        {
            _appointmentDb = appointmentDb;
        }

        [HttpPost]
        public IActionResult CreateAppointment([FromBody] AppointmentRequest request)
        {
            
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            //Type should have been validated already by the model binding, but we want to check the slot's times.
            if (!isValidTime(request.Slot.Start, request.Slot.End))
            {
                return BadRequest(new ValidationError { Field = "slot.Start", Message = "End time must be after Start time" });
            }
            if (request.Slot.appointmentType != request.AppointmentType)
            {
                return BadRequest(new ValidationError {Field = "slot.appointmentType", Message = "Slot's appointment type must match appointment's type" });
            }

            // Create new Appointment
            Appointment newAppointment = new Appointment(request.Slot, request.AppointmentType, AppointmentStatus.Booked) { Id = Guid.NewGuid().ToString() };
            _appointmentDb.Push(newAppointment);

            return Created(string.Empty, newAppointment);
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointment(string id)
        {
            
            // Retrieve Appointment by id

            Appointment? appointment = _appointmentDb.Read(id);
            if (appointment == null) {
                return new NotFoundResult();
            }
            return new JsonResult(appointment);
        }

        // I separated the update endpoint into two since I couldn't get a polymorphic version to work.

        [HttpPut("{id}/slot")]
        public IActionResult UpdateSlot([FromBody] UpdateSlotRequest request, string id)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            Appointment? appointment = _appointmentDb.Read(id);
            if (appointment == null) {
                return new NotFoundResult();
            }

            appointment.Slot = request.Slot;
            _appointmentDb.Push(appointment);

            return new JsonResult(appointment);
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus([FromBody] UpdateStatusRequest request, string id)
        {
            if (!ModelState.IsValid) {
                return BadRequest(new ValidationError() { });
            }

            Appointment? appointment = _appointmentDb.Read(id);
            if (appointment == null) {
                return new NotFoundResult();
            }

            appointment.Status = request.Status;
            _appointmentDb.Push(appointment);

            return new JsonResult(appointment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(string id)
        {
            Appointment deleteAppointment = _appointmentDb.Read(id);
            if (deleteAppointment == null)
            {
                return NotFound();
            }
            _appointmentDb.Delete(id);
            return NoContent();
        }


        private Boolean isValidTime(DateTime start, DateTime end) {
            return DateTime.Compare(start, end) < 0;
        }


    }
}