using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using litfibretestapi.Enums;
using litfibretestapi.Models.Data;

namespace litfibretestapi.Models {

    public class Slot
{
    [Required]
    public DateTime Start { get; set; }
    
    [Required]
    public DateTime End { get; set; }

    [Required]
    public AppointmentType appointmentType { get; set; }
}
    
}

