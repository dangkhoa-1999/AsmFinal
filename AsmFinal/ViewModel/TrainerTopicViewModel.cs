using AsmFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsmFinal.ViewModel
{
    public class TrainerTopicViewModel
    {
        public IEnumerable<Topic> Topics { get; set; }
        public ApplicationUser Trainer { get; set; }
    }
}