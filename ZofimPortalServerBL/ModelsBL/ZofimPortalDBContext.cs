using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ZofimPortalServer.DTO;

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

        public List<WorkerToShow> GetAllWorkers()
        {
            List<Worker> workers = new List<Worker>(Workers.Include(u=>u.User));

            List<WorkerToShow> ToReturn = new List<WorkerToShow>();
            foreach(var worker in workers)
            { 
                    WorkerToShow workerToShow = new WorkerToShow();
                    workerToShow.FirstName = worker.User.FirstName;
                    workerToShow.LastName = worker.User.LastName;
                    workerToShow.Email = worker.User.Email;
                    workerToShow.PersonalID = worker.User.PersonalId;
                    int roleID = worker.RoleId;
                    workerToShow.Role = Roles.Where(r => r.Id == roleID).FirstOrDefault().RoleName;
                    int? shevetID = worker.ShevetId;
                    if (shevetID != null)
                        workerToShow.Shevet = Shevets.Where(s => s.Id == shevetID).FirstOrDefault().Name;
                    else
                        workerToShow.Shevet = "אין";
                    int? hanhagaID = worker.HanhagaId;
                    if (hanhagaID != null)
                        workerToShow.Hanhaga = Hanhagas.Where(h => h.Id == hanhagaID).FirstOrDefault().Name;
                    else
                        workerToShow.Hanhaga = "אין";
                    ToReturn.Add(workerToShow);

            }
            return ToReturn;
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
            this.Users.Update(user);
            this.SaveChanges();
        }
    }         
}
