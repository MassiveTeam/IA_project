using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IA.Models
{
    public class ProfessorLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ProfId { get; set; }
        [ForeignKey("ProfId")]
        public Professior professior { get; set; }
        public int statues { get; set; }
        public int ProjectId { get; set; }
        public virtual ICollection<MemberId> memberIds { get; set; }
        public virtual ICollection<ProfId> profIds { get; set; }

    }
}