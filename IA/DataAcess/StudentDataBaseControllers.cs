
using IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IA.DataAcess
{
    public class StudentDataBaseControllers : Login
    {
        public void InsertStudent(Student student) {
            db.student.Add(student);
            db.SaveChanges();
        }

        public IEnumerable<Student> getStudents() => db.student?.ToList();

        public void InsertReport(Report report)
        {
            db.reports.Add(report);
            db.SaveChanges();
        }

        //Maybe will be error here call me if so @Kero 
        public void InsertIdea(Idea idea , int State)
        {
            Team team = new Team();
            MemberId memberId = new MemberId();
            ProfId ProfId = new ProfId();
            List<int> StudentsIds = new List<int>();
            List<int> professiorsIds = new List<int>();

            team.Description = idea.Description;
            team.LeaderId = idea.TeamLeaderId;
            team.ProjectId = idea.TeamLeaderId + 2015 ;
            team.Tools = idea.Tools;
            team.ProjectName = idea.IdeaName;
            team.State = State;
            
            foreach(Student x in idea.students)
            {
                StudentsIds.Add(x.Id);
            }
            foreach (Professior x in idea.professiors)
            {
                professiorsIds.Add(x.Id);
            }
            memberId.ProjectId = team.ProjectId;
            memberId.FirstMemberId = StudentsIds[0];
            memberId.SecondMemberId = StudentsIds[1];
            memberId.ThridMemberId = StudentsIds[2];
            try
            {
                memberId.FourthMemberId = StudentsIds[3];
                memberId.FifthMemberId = StudentsIds[4];
            }
            catch (Exception e ) { }
            ProfId.FirstProfId = professiorsIds[0];
            ProfId.ProjectId = team.ProjectId;
            try
            {
                ProfId.SecondProfId = professiorsIds[1];
                ProfId.ThridProfId = professiorsIds[2];
            }
            catch (Exception e) { }


            ProfessorLog professorLog = new ProfessorLog();

            professorLog.statues = State; 
            professorLog.ProfId = professiorsIds[0]; 
            professorLog.ProjectId = team.ProjectId;

            db.professorLogs.Add(professorLog);
            db.memberIds.Add(memberId);
            db.profIds.Add(ProfId);
            db.teams.Add(team);

            db.SaveChanges();
        }


    }
}