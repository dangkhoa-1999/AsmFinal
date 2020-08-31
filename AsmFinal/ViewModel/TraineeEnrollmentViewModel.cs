using AsmFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsmFinal.ViewModel
{
    public class TraineeEnrollmentViewModel
    {
        public TraineeEnrollment TraineeEnrollment { get; set; }
        public IEnumerable<ApplicationUser> Trainees { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}