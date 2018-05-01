using IA.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IA.Controllers
{
    public class HoemController : Controller
    {
        DataAcess.StudentDataBaseControllers studentDataBase = new DataAcess.StudentDataBaseControllers();
        DataAcess.AdminDatabaseControllers adminDatabase = new DataAcess.AdminDatabaseControllers();

        // GET: Hoem
        public ActionResult Index()
        {
            return View();
        }
        public void AddStudent() {
            Student student = new Student
            {
                Email = "fsdf"
                 ,
                Gpa = 2
                 ,
                Id = 20150396
                 ,
                level = 23
                 ,
                Password = "fsdf"
                 ,
                Skills = "fsdf"
                 ,
                Transcrip = "fsdf"
                 ,
                UserName = "kero"
            };
            studentDataBase.InsertStudent(student);
        }
        public void Addprof()
        {
            Professior professior = new Professior
            {
                Department = "it",
                Interests = " fdsgdf"
            ,
                Email = "kerop s"
            ,
                Password = "gfdgdf"
            ,
                UserName = "gfdgdfgd"
            ,
                Description = "fsdfgds"
            };
            adminDatabase.AddProfessor(professior);
        }
        public void RemoveProf() {
            adminDatabase.RemoveProfessor(4);
        }
        public void insertReport() {
            Report report = new Report {
              Reports = "ffdfdfsfdsfa"
            , Sender="kero "};
            studentDataBase.InsertReport(report);
        }

        public void login()
        {
            Person user = studentDataBase.LoginMethod("fsdf", "fsdf");
            if (user is Student) {
                    Response.Write(user.UserName);
            }
        }

        public void Addidea()
        {
            List<Student> students = studentDataBase.getStudents().ToList();
            
            List<Professior> prof = new List<Professior>();
            prof = adminDatabase.GetProfessiors().ToList(); 
            Idea idea = new Idea
            {
                Description = "fdfgsdfgdfghdf",
                IdeaName = "project ",
                TeamLeaderId =1 ,
                TeamLeaderName = "kero",
                Tools = "asp.net",
                students = students
                ,professiors = prof 
            };
            studentDataBase.InsertIdea(idea, 0); 
        }

        }
    }