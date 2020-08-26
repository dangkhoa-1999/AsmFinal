using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsmFinal.Models
{
    public class Trainee
    {
        public string Id { get; set; }
        [Required]
        [DisplayName("Trainee Name")]
        public string TraineeName { get; set; }
        [DisplayName("Trainee Email")]
        public string TraineeEmail { get; set; }
        [DisplayName("Toeic Score")]
        public int TraineeToeicScore { get; set; }
        
        
    }
}