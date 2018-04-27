using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IA.Models
{
    public class Team
    {
        [ForeignKey("LeaderId")]
        public Student student { get; set; }
        public int LeaderId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamID { get; set; }
        public int ProjectId { get; set; }  
        public string Description { get; set; }  
        public string Tools { get; set; }
        [DefaultValue(0)]
        public int State { get; set; }  
        public string ProjectName { get; set; }
        [ForeignKey("ProjectId")]
        public ProfessorLog professor { get; set; }

    }
}