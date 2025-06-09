using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using litfibretestapi.Enums;
using litfibretestapi.Models;

public class AppointmentRequest {
    [Required]
    public AppointmentType AppointmentType { get; set; }


    [Required]
    public Slot Slot { get; set; }
}