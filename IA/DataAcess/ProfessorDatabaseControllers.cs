using System.Collections.Generic;
using System.Linq;
using IA.Models;

namespace IA.DataAcess
{
    public class ProfessorDatabaseControllers : Login
    {
        public IEnumerable<TeamWithIdea> GetPenddingStudent(int profId) {
            List<TeamWithIdea> data = new List<TeamWithIdea>();
            List<Team> AllTeams = new List<Team>();
            List<Team> FinalTeam = new List<Team>();
            List<string> LeaderNames  = new List<string>();

            List<ProfessorLog> professorLogs = new List<ProfessorLog>();
            AllTeams = db.teams.Where(x => x.State == 0).ToList();
            professorLogs = db.professorLogs.Where(x => x.ProfId == profId).ToList();
            int count = professorLogs.Count();
            int countTeams = AllTeams.Count();

            for (int i = 0; i < count; i++) {
                for (int x = 0; x < countTeams; x++) {
                    if (professorLogs[i].ProjectId == AllTeams[x].ProjectId)
                    {
                        FinalTeam.Add(AllTeams[x]);
                    }
                }
                
            }
            for (int i = 0; i < FinalTeam.Count(); i++)
            {
                Student student = new Student();
                student = db.student.Where(x => x.Id == FinalTeam[i].LeaderId).FirstOrDefault();
                LeaderNames.Add(student.UserName);
            }
            for (int i = 0; i < FinalTeam.Count(); i++)
            {
                data[i].TeamLeaderName = LeaderNames[i];
                data[i].LeaderId = FinalTeam[i].LeaderId;
                data[i].ProjectName = FinalTeam[i].ProjectName;
                data[i].Description = FinalTeam[i].Description;
                data[i].Tools = FinalTeam[i].Tools;
                data[i].TeamID = FinalTeam[i].TeamID;
            }
                return data;
           
        }
        public void UpdateProfile(int ProfID , Professior professior) {
            Professior professior1 = new Professior();
            professior1 = db.professiors.Where(x => x.Id == ProfID).FirstOrDefault();
            db.professiors.Remove(professior1);
            db.SaveChanges();
            db.professiors.Add(professior);
            db.SaveChanges();
        }

        
    }
}