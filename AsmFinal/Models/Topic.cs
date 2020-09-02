using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsmFinal.Models
{
    public class Topic
    {

        [Key]
        public int Id { get; set; }
        
        [Required]
        [Remote("IsProductNameExist", "Topic", AdditionalFields = "Id",
                ErrorMessage = "Topic name already exists")]
        public string Name { get; set; }
        public string Detail { get; set; }
       
        public int CourseId { get; set; }
        public Course Course { get; set; }
        
    }
}