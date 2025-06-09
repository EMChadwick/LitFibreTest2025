using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using litfibretestapi.Enums;
using litfibretestapi.Models;

public class AppointmentRequest {
    [Required]
    public AppointmentType appointmentType { get; set; }


    [Required]
    public Slot slot { get; set; }
}