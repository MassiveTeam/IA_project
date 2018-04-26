using IA.Models;
using System.Linq;

namespace IA.DataAcess
{
    public class Login 
    {
        public ApplicationContextDb db = new ApplicationContextDb();

        public Person LoginMethod(string Email , string Password , string TabeName) {
            Person user = new Person();
            switch (TabeName) {
                case "Student":
                    user = db.student.Where(x => x.Password == Password && x.Email == Email).FirstOrDefault();
                    break;
                case "Professior":
                    user = db.professiors.Where(x => x.Password == Password && x.Email == Email).FirstOrDefault();
                    break;
                case "Admin":
                    user = db.Admins.Where(x => x.Password == Password && x.Email == Email).FirstOrDefault();
                    break;
            }

            return user; 
        }

        
    }
}