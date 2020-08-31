using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsmFinal.Models
{
    public class TraineeEnrollment
    {
        [Key]
        public int Id { get; set; }
        public string TraineeId { get; set; }
        public int EnrollmentId { get; set; }
        public ApplicationUser Trainee { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}