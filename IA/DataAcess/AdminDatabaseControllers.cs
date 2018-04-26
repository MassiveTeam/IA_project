using IA.Models;
using System.Collections.Generic;
using System.Linq;

namespace IA.DataAcess
{
    public class AdminDatabaseControllers : Login
    {
        public void AddProfessor(Professior professior) {
            db.professiors.Add(professior);
            db.SaveChanges();
        }
        public void RemoveProfessor(Professior professior)
        {
            db.professiors.Remove(professior);
            db.SaveChanges();
        }
        public IEnumerable<Report> GetReports() {
            return db.reports.ToList();
        }
        public IEnumerable<Professior> GetProfessiors()
        {
            return db.professiors.ToList();
        }
    }
}