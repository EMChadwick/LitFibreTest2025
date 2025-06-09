using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System;
using System.Collections.Generic;
using litfibretestapi.Models;       
using litfibretestapi.Enums;         



namespace litfibretestapi.Controllers
{
    [ApiController]
    [Route("api/slots")]
    public class SlotController : ControllerBase
    {


        [HttpGet, Route("{type}")]
        public IActionResult GetSlots(string type)
        {
            // Check the type exists and get it as a value if so
            if (!Enum.TryParse<AppointmentType>(type, true, out var appointmentType))
            {
                return NotFound("Appointment type not found");
            }
            List<Slot> returnSlots = this.generateSlots(appointmentType);


            return new JsonResult(returnSlots);
        }

        // Generate slots for 30 days starting from tomorrow.
        // 2 slots per day.
        private List<Slot> generateSlots(AppointmentType type)
        {
            int totalDays = 30;
            List<Slot> slots = new List<Slot>();
            DateTime startDate = DateTime.Today.AddDays(1); // Start from tomorrow

            for (int i = 0; i < totalDays; i++)
            {
                var date = startDate.AddDays(i);

                // Skip weekends
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    continue;

                // 9am – 1pm
                var firstStart = date.AddHours(9);
                slots.Add(new Slot { Start = firstStart, End = firstStart.AddHours(4), appointmentType = type });

                // 1pm - 5pm
                var secondStart = date.AddHours(13);
                slots.Add(new Slot { Start = secondStart, End = secondStart.AddHours(4), appointmentType = type });
            }

            return slots;
        }
    }
}