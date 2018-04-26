
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace IA.Models
{
    public class ProfId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int  FirstProfId { get; set; }
        public int?  SecondProfId { get; set; }
        public int?  ThridProfId { get; set; }
        
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]

        public ProfessorLog professorlogs { get; set; }

    }

    }