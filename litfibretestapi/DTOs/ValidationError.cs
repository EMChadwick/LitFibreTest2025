using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using litfibretestapi.Enums;


namespace litfibretestapi.DTOs {
    public class ValidationError {
        [Required]
        public string field { get; set; }
        [Required]
        public string message { get; set; }
        

    }
}