using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsmFinal.Models
{
    public class TrainerTopic
    {
        [Key]
        public int Id { get; set; }
        
        public string TrainerId { get; set; }
        
        [Remote("IsTrainerTopicNameExist", "TrainerTopic", AdditionalFields = "Id",
 ErrorMessage = "Trainer name and topic already exists")]
        
        public int TopicId { get; set; }
        public ApplicationUser Trainer { get; set; }
        public Topic Topic { get; set; }
    }
}