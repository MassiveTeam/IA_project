using IA.Models;
using System.Linq;

namespace IA.DataAcess
{
    public class Login 
    {
        public ApplicationContextDb db = new ApplicationContextDb();

        public Person LoginMethod(string Email , string Password) {
            Person user = null;
            if (db.student.Where(x => x.Password == Password && x.Email == Email).FirstOrDefault() != null) {
                user = new Student();
                user = db.student.Where(x => x.Password == Password && x.Email == Email).FirstOrDefault();
            } else if (db.professiors.Where(x => x.Password == Password && x.Email == Email).FirstOrDefault() !=null) {
                user = new Professior();
                user = db.professiors.Where(x => x.Password == Password && x.Email == Email).FirstOrDefault();
            }else if(db.Admins.Where(x => x.Password == Password && x.Email == Email).FirstOrDefault() !=null) {
                user = new Admin();
                user = db.Admins.Where(x => x.Password == Password && x.Email == Email).FirstOrDefault();
            }

            return user; 
        }

        
    }
}