using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsmFinal.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Trainer Name")]
        public string TrainerName { get; set; }
        [DisplayName("Trainer Email")]
        public string TrainerEmail { get; set; }
        [DisplayName("Trainer Major")]
        public string TrainerMajor { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string TrainerId { get; set; }
    }
}