using AsmFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsmFinal.ViewModel
{
    public class TopicTrainerViewModel
    {
        public Trainer Trainer { get; set; }
        public IEnumerable<Topic> topics { get; set; }
    }
}