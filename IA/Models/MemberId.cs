
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace IA.Models
{
    public class MemberId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FirstMemberId { get; set; }
        public int SecondMemberId { get; set; }
        public int? ThridMemberId { get; set; }
        public int? FourthMemberId { get; set; }
        public int? FifthMemberId { get; set; }

        public int ProjectId { get; set; }
       // [ForeignKey("ProjectId")]

        //public ProfessorLog ProfessorLog { get; set; }

    }
}