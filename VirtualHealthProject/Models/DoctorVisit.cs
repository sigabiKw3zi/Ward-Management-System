using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VirtualHealthProject.Models
{
    public class DoctorVisit
    {
        [Key]
        public int VisitId { get; set; }

        [StringLength(500)]
        public string ChronicConditions { get; set; }
        public string ScheduleVMedication { get; set; }
        public string ChronicConditionsStatus { get; set; }
        public string ScheduleIVMedication { get; set; }
        public string ScheduledMedication { get; set; }

    }
}
