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

        #region שליפת ID
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
        #endregion

        #region שליפת רשימות
        public List<User> GetAllUsers()
        {
            return new List<User>(Users);
        }

        public List<Worker> GetAllWorkers()
        {
            List<Worker> workers = new List<Worker>(Workers);
            List<User> users = new List<User>(Users);
            var workersUsers =
                from user in users
                join worker in workers on user.Id equals worker.UserId
                select new
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    ShevetID = worker.ShevetId,
                    Role = worker.Role,
                    HanhagaID = worker.HanhagaId
                };
            //var workersUsersRole = 
             //   from worker in workersUsers
             //   join role in Roles on worker.RoleID
            List<object> ToReturn = new List<object>();
            foreach(var worker in workersUsers)
            { }
            return new List<Worker>();
        }

        public List<Parent> GetAllParents()
        {
            return new List<Parent>(Parents);
        }

        public List<Cadet> GetAllCadets()
        {
            return new List<Cadet>(Cadets);
        }
        #endregion

        public void SignUp(User user)
        {
            this.Users.Add(user);
            this.SaveChanges();
        }
    }         
}
