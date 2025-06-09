
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using litfibretestapi.Enums;
using litfibretestapi.Models.Data;

namespace litfibretestapi.Models {
    public class Appointment : DatabaseObject {

        public override string Id { get; set; }  = string.Empty;
        [Required]
        public AppointmentType Type { get; set; }
        [Required]
        public AppointmentStatus Status { get; set; }
        [Required]
        public Slot Slot { get; set; }

        public Appointment(Slot _slot, AppointmentType _type, AppointmentStatus _status) {
            Slot = _slot;
            Type = _type;
            Status = _status;
        }
    }
}

