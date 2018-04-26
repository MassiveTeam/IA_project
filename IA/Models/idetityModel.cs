using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace IA.Models
{

    public class ApplicationContextDb : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<MemberId> memberIds { get; set; }
        public DbSet<Professior> professiors { get; set; }
        public DbSet<ProfessorLog> professorLogs { get; set; }
        public DbSet<ProfId> profIds { get; set; }
        public DbSet<Student> student { get; set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<Report> reports { get; set; }



        public ApplicationContextDb() : base("DefaultConnection") {
            Database.SetInitializer<ApplicationContextDb>(new CreateDatabaseIfNotExists<ApplicationContextDb>());
        }
       

    }
}

//IdentityDbContext<IdetityModel>