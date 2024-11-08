﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class CurrentMedication
    {
        [Key]
        public int CurrentMedicationID { get; set; }
        public int PatientID { get; set; }
        public string Description { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
