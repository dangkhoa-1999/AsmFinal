using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsmFinal.Models
{
    public class Topic
    {

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Detail { get; set; }
       
        public int CourseId { get; set; }
        public Course Course { get; set; }
        
    }
}