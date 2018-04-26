using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace IA.Models
{
    public class Professior : Person
    {
        
        public string Department { get; set; }
        public string Description { get; set; }
        public string Interests { get; set; }


        public virtual ICollection<ProfessorLog> professorLogs { get; set; }
        public virtual ICollection<ProfId> profIds { get; set; }

    }
}