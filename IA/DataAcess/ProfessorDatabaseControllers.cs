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
                var id = FinalTeam[i].LeaderId;
                student = db.student.Where(x => x.Id == id).First();
                LeaderNames.Add(student.UserName);
            }
            TeamWithIdea teamWithIdea; 
            for (int i = 0; i < FinalTeam.Count(); i++)
            {
                teamWithIdea = new TeamWithIdea()
                {
                    TeamLeaderName = LeaderNames[i],
                    LeaderId = FinalTeam[i].LeaderId,
                    ProjectName = FinalTeam[i].ProjectName,
                    Description = FinalTeam[i].Description,
                    Tools = FinalTeam[i].Tools,
                    TeamID = FinalTeam[i].TeamID
                };

                data.Add(teamWithIdea);
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