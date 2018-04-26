using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA.Models
{
    public class Idea
    {
        public List<Professior> professiors { get; set; }
        public List<Student> students { get; set; }
        public string IdeaName { get; set; }
        public string Description { get; set; }
        public string Tools { get; set; }
        public string TeamLeaderName { get; set; }
        public int TeamLeaderId { get; set; }
    }
}