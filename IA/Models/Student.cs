using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IA.Models
{
    public class Student : Person
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<MemberId> memberIds { get; set; }
        public virtual ICollection<Team> Team { get; set; }

        public int level { get; set; }
        public float Gpa { get; set; }
        public string Skills { get; set; }
        public string Transcrip  { get; set; }
    }
}