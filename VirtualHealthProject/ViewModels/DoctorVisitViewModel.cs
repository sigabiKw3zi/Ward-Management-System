﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualHealthProject.Models;

namespace VirtualHealthProject.ViewModels
{
    public class DoctorVisitViewModel
    {
        // The actual DoctorVisit entity to hold the form data
        public int VisitId { get; set; }

        [Display(Name = "Visit Date")]
        [DataType(DataType.Date)]
        public DateTime VisitDateTime { get; set; }

        public string Note { get; set; } = null!;

        [Display(Name = "Patient")]
        public int PatientID { get; set; }

        [Display(Name = "User")]
        public string? UserId { get; set; }

        public string PatientFullName { get; set; } = null!;
        public string UserFullName { get; set; } = null!;

        // For displaying dropdowns of Patients and Users
        public SelectList? Patients { get; set; } = new SelectList(new List<Patient>(), "Id", "FullName");

        public SelectList Users { get; set; } = new SelectList(new List<User>(), "Id", "FullName");
    }
}
