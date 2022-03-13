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
        #region הרשמה והתחברות
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

        public void SignUp(User user)
        {
            this.Users.Update(user);
            this.SaveChanges();
        }
        #endregion

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

        public List<ParentToShow> GetAllParents()
        {
            List<Parent> parents = new List<Parent>(Parents.Include(u => u.User));

            List<ParentToShow> ToReturn = new List<ParentToShow>();
            foreach (var parent in parents)
            {
                ParentToShow parentToShow = new ParentToShow();
                parentToShow.FirstName = parent.User.FirstName;
                parentToShow.LastName = parent.User.LastName;
                parentToShow.Email = parent.User.Email;
                parentToShow.PersonalID = parent.User.PersonalId;
                int? shevetID = parent.ShevetId;
                parentToShow.Shevet = Shevets.Where(s => s.Id == shevetID).FirstOrDefault().Name;
                int? hanhagaID = Shevets.Where(s=>s.Id==shevetID).FirstOrDefault().HanhagaId;
                parentToShow.Hanhaga = Hanhagas.Where(h => h.Id == hanhagaID).FirstOrDefault().Name;
                parentToShow.KidsNumber = CadetParents.Where(cp => cp.ParentId == parent.Id).Count();
                ToReturn.Add(parentToShow);

            }
            return ToReturn;
        }

        public List<CadetToShow> GetAllCadets()
        {
            List<Cadet> cadets = new List<Cadet>(Cadets);

            List<CadetToShow> ToReturn = new List<CadetToShow>();
            foreach (var cadet in cadets)
            {
                CadetToShow cadetToShow = new CadetToShow();
                cadetToShow.FirstName = cadet.FName;
                cadetToShow.LastName = cadet.LName;
                cadetToShow.PersonalID = cadet.PersonalId;
                int shevetID = cadet.ShevetId;
                cadetToShow.Shevet = Shevets.Where(s => s.Id == shevetID).FirstOrDefault().Name;
                int hanhagaID = Shevets.Where(s => s.Id == shevetID).FirstOrDefault().HanhagaId;
                cadetToShow.Hanhaga = Hanhagas.Where(h => h.Id == hanhagaID).FirstOrDefault().Name;
                int roleID = cadet.RoleId;
                cadetToShow.Role = Roles.Where(r => r.Id == roleID).FirstOrDefault().RoleName;
                ToReturn.Add(cadetToShow);

            }
            return ToReturn;
        }
        #endregion

        #region קבלת נתוני משתמש
        public int GetPermissionLevel(int id)
        {
            //1 -> admin, can see all
            //2 -> can see only from his hanhaga
            //3 -> can see only parents and cadets from his shevet
            Worker w = Workers.Where(w => w.UserId == id).FirstOrDefault();
            if(w!=null)
            {
                int roleID = w.RoleId;
                string role = Roles.Where(r => r.Id == roleID).FirstOrDefault().RoleName;
                if (role == "admin")
                    return 1;
                if (role == "rosh hanhaga")
                    return 2;
                if (role == "rosh shevet")
                    return 3;
            }
            return 0;
        }

        public string GetHanhaga(int id)
        {
            Worker w = Workers.Where(w => w.UserId == id).FirstOrDefault();
            Parent p = Parents.Where(p => p.UserId == id).FirstOrDefault();
            if (w != null)
            {
                int? wHanhagaId = w.HanhagaId;
                return Hanhagas.Where(h => h.Id == wHanhagaId).FirstOrDefault().Name;
            }
            int? pShevetId = p.ShevetId;
            int? pHanhagaId = Shevets.Where(s => s.Id == pShevetId).FirstOrDefault().HanhagaId;
            return Hanhagas.Where(h => h.Id == pHanhagaId).FirstOrDefault().Name;
        }

        public string GetShevet(int id)
        {
            Worker w = Workers.Where(w => w.UserId == id).FirstOrDefault();
            Parent p = Parents.Where(p => p.UserId == id).FirstOrDefault();
            if (w != null)
            {
                int? wShevetId = w.ShevetId;
                return Shevets.Where(h => h.Id == wShevetId).FirstOrDefault().Name;
            }
            int? pShevetId = p.ShevetId;
            return Shevets.Where(h => h.Id == pShevetId).FirstOrDefault().Name;
        }
        #endregion
    }         
}
