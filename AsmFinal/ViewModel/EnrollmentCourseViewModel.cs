using AsmFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsmFinal.ViewModel
{
    public class EnrollmentCourseViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}