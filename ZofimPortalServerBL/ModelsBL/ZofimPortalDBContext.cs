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
            User us = Users.Where(u => u.Id > 0).OrderByDescending(user => user.Id).FirstOrDefault();
            if (us == null)
                return 0;
            return us.Id;
        }
        public int GetLastWorkerID()
        {
            Worker wo = Workers.Where(w => w.Id > 0).OrderByDescending(worker => worker.Id).FirstOrDefault();
            if (wo == null)
                return 0;
            return wo.Id;
        }
        public int GetLastParentID()
        {
            Parent pa = Parents.Where(p => p.Id > 0).OrderByDescending(parent => parent.Id).FirstOrDefault();
            if (pa == null)
                return 0;
            return pa.Id;
        }

        public List<User> GetAllUsers()
        {
            return new List<User>(Users);
        }

        public List<Worker> GetAllWorkers()
        {
            return new List<Worker>(Workers);
        }

        public List<Parent> GetAllParents()
        {
            return new List<Parent>(Parents);
        }

        public List<Cadet> GetAllCadets()
        {
            return new List<Cadet>(Cadets);
        }

        public void SignUp(User user)
        {
            this.Users.Add(user);
            this.SaveChanges();
        }
    }         
}
