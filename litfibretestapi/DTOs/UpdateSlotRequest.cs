using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using litfibretestapi.Models;
using litfibretestapi.Interfaces;

public class UpdateSlotRequest : IAppointmentUpdateRequest {
    [Required]
    public Slot slot { get; set; }
}