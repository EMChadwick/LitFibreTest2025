using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using litfibretestapi.Enums;
using litfibretestapi.Interfaces;

public class UpdateStatusRequest : IAppointmentUpdateRequest {
    [Required]
    public AppointmentStatus status { get; set; }
}