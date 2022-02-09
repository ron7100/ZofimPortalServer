using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZofimPortalServerBL.Models
{
    public partial class ZofimPortalDBContext:DbContext
    {
        //שלוש פעולות שונות שמנסות לחבר לכל סוג של משתמש, שתיים ייכשלו ורק הסוג הנכון יצליח
        //פעולה אחת שמחזירה אובייקט ובודקת לפי המשתמש איזה סוג אובייקט זה
        
        public User Login(string email, string pass)
        {
            User user = this.Users.Where(u => u.Email == email && u.Password == pass).FirstOrDefault();
            return user;
        }
        public bool IsUserExist(string email)
        {
            User user = this.Users.Where(u => u.Email == email).FirstOrDefault();
            return user != null;
        }

        public int GetLastUserID()
        {
            return Users.Where(u => u.Id > 0).OrderBy(user=>user.Id).LastOrDefault().Id;
        }

        public void SignUp(User user)
        {
            this.Users.Add(user);
            this.SaveChanges();
        }
    }         
}
