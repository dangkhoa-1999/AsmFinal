using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsmFinal.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [Remote("IsProductNameExist", "Enrollment", AdditionalFields = "Id",
                ErrorMessage = "Enrollment name already exists")]
        public string Name { get; set; }
        public DateTime EnrollmentDateStarted { get; set; }
        public DateTime EnrollmentDateExpired { get; set; }
        
        public int CourseId { get; set; }
        public Course Course { get; set; }
        
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        

    }
}