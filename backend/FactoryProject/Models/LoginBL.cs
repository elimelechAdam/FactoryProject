using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryProject.Models
{
    public class LoginBL
    {
        FactoryProjectEntities db = new FactoryProjectEntities();

        public List<Users> getAllUsers()
        {
            return db.Users.ToList();
        }
        public Users getUser(int id)
        {
            return db.Users.Where(x=> x.ID == id).First();
        }
        public string UpdateUserActions(int id, Users user)
        {
            var result = db.Users.Where(x => x.ID == id).First();
            result.NumOfActions = user.NumOfActions;
            db.SaveChanges();
            return "User actions updated";
        }
    }
}