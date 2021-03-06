using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ZofimPortalServer.DTO;
using ZofimPortalServerBL.DTO;

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

        public bool IsIdExist(string id)
        {
            User user = this.Users.Where(u => u.PersonalId == id).FirstOrDefault();
            if (user != null)
                return true;
            Cadet cadet = this.Cadets.Where(c => c.PersonalId == id).FirstOrDefault();
            return cadet != null;
        }

        public void SignUp(User user)
        {
            this.Users.Update(user);
            this.SaveChanges();
        }
        #endregion

        #region שמירת שינויים
        public void SaveUserChanges(User us)
        {
            User u = Users.Where(u => u.Id == us.Id).FirstOrDefault();
            u.Email = us.Email;
            u.FirstName = us.FirstName;
            u.LastName = us.LastName;
            u.PersonalId = us.PersonalId;
            u.Password = us.Password;
            SaveChanges();
        }

        public void SaveWorkerChanges(WorkerToShow wo)
        {
            Worker w = Workers.Where(w => w.Id == wo.ID).FirstOrDefault();
            User u = Users.Where(u => u.Id == w.UserId).FirstOrDefault();
            u.Email = wo.Email;
            u.FirstName = wo.FirstName;
            u.LastName = wo.LastName;
            u.PersonalId = wo.PersonalID;
            w.RoleId = Roles.Where(r => r.RoleName == wo.Role).FirstOrDefault().Id;
            if (wo.Hanhaga != "אין")
            {
                w.HanhagaId = Hanhagas.Where(h => h.Name == wo.Hanhaga).FirstOrDefault().Id;
                if (wo.Shevet != "אין")
                    w.ShevetId = Shevets.Where(s => s.Name == wo.Shevet && s.HanhagaId == w.HanhagaId).FirstOrDefault().Id;
                else
                    w.ShevetId = null;
            }
            else
            {
                w.HanhagaId = null;
                w.ShevetId = null;
            }
            SaveChanges();
        }

        public void SaveParentChanges(ParentToShow pa)
        {
            Parent p = Parents.Where(p => p.Id == pa.ID).FirstOrDefault();
            User u = Users.Where(u => u.Id == p.UserId).FirstOrDefault();
            u.Email = pa.Email;
            u.FirstName = pa.FirstName;
            u.LastName = pa.LastName;
            u.PersonalId = pa.PersonalID;
            Hanhaga hanhaga = Hanhagas.Where(h => h.Name == pa.Hanhaga).FirstOrDefault();
            p.ShevetId = Shevets.Where(s => s.Name == pa.Shevet&&s.HanhagaId==hanhaga.Id).FirstOrDefault().Id;
            SaveChanges();
        }

        public void SaveCadetChanges(CadetToShow ca)
        {
            Cadet c = Cadets.Where(c => c.Id == ca.ID).FirstOrDefault();
            c.FName = ca.FirstName;
            c.LName = ca.LastName;
            c.Class = ca.Class;
            c.PersonalId = ca.PersonalID;
            c.RoleId = Roles.Where(r => r.RoleName == ca.Role).FirstOrDefault().Id;
            Hanhaga hanhaga = Hanhagas.Where(h => h.Name == ca.Hanhaga).FirstOrDefault();
            c.ShevetId = Shevets.Where(s => s.Name == ca.Shevet && s.HanhagaId == hanhaga.Id).FirstOrDefault().Id;
            SaveChanges();
        }

        public void SaveShevetChanges(ShevetToShow sh)
        {
            Shevet s = Shevets.Where(s => s.Id == sh.ID).FirstOrDefault();
            s.Name = sh.Name;
            s.MembersAmount = sh.MembersAmount;
            Hanhaga hanhaga = Hanhagas.Where(h => h.Name == sh.Hanhaga).FirstOrDefault();
            s.HanhagaId = hanhaga.Id;
            SaveChanges();
        }

        public void SaveHanhagaChanges(Hanhaga ha)
        {
            Hanhaga h = Hanhagas.Where(h => h.Id == ha.Id).FirstOrDefault();
            h.Name = ha.Name;
            h.GeneralArea = ha.GeneralArea;
            int count = 0;
            foreach(Shevet s in ha.Shevets)
            {
                count++;
                Shevet ezer = Shevets.Where(sh => sh.Id == s.Id).FirstOrDefault();
                h.Shevets.Add(ezer);
            }
            h.ShevetNumber = count;
            SaveChanges();
        }

        public void SaveActivityChanges(ActivityToShow ac)
        {
            Activity a = Activities.Where(a => a.Id == ac.ID).FirstOrDefault();
            a.Name = ac.Name;
            a.StartDate = ac.StartDate.ConvertToDateTime();
            a.EndDate = ac.EndDate.ConvertToDateTime();
            a.RelevantClass = GetRelevantClassInt(ac.RelevantClass);
            a.CadetsAmount = ac.CadetsAmount;
            a.DiscountPercent = ac.DiscountPercent;
            if (ac.IsOpen == "Green")
                a.IsOpen = 1;
            else
                a.IsOpen = 0;
            a.ShevetId = ac.ShevetID;
            a.HanhagaId = ac.HanhagaID;
            SaveChanges();
        }

        private int GetRelevantClassInt(string relevantClass)
        {

            if (relevantClass == "כל השבט")
                return 0;
            else if (relevantClass == "צעירה")
                return 1;
            else if (relevantClass == "בוגרת")
                return 2;
            else if (relevantClass == "שכבג")
                return 3;
            else if (relevantClass == "ד")
                return 4;
            else if (relevantClass == "ה")
                return 5;
            else if (relevantClass == "ו")
                return 6;
            else if (relevantClass == "ז")
                return 7;
            else if (relevantClass == "ח")
                return 8;
            else if (relevantClass == "ט")
                return 9;
            else if (relevantClass == "י")
                return 10;
            else if (relevantClass == "יא")
                return 11;
            else if (relevantClass == "יב")
                return 12;
            return 13;
        }

        public Cadet AddCadet(Cadet c)
        {
            c.Id = GetLastCadetID() + 1;
            Cadets.Add(c);
            SaveChanges();
            return c;
        }

        public void ConnectCadetParent(CadetParent cadetParent)
        {
            CadetParents.Add(cadetParent);
            SaveChanges();
        }

        public Activity AddActivity(ActivityToShow ats)
        {
            Activity a = new Activity
            {
                Name = ats.Name,
                StartDate = ats.StartDate.ConvertToDateTime(),
                EndDate = ats.EndDate.ConvertToDateTime(),
                RelevantClass = GetRelevantClassInt(ats.RelevantClass),
                CadetsAmount = ats.CadetsAmount,
                Price = ats.Price,
                DiscountPercent = ats.DiscountPercent,
                ShevetId = ats.ShevetID,
                HanhagaId = ats.HanhagaID,
                Id = GetLastActivityID() + 1
            };
            if (ats.IsOpen == "Green")
                a.IsOpen = 1;
            else
                a.IsOpen = 0;
            Activities.Add(a);
            SaveChanges();
            return a;
        }

        public void SignUpToActivities(List<ActivitiesHistory> activitiesHistories)
        {
            foreach(ActivitiesHistory ah in activitiesHistories)
            {
                ActivitiesHistories.Add(ah);
                Activity activity = Activities.Where(a => a.Id == ah.ActivityId).FirstOrDefault();
                activity.CadetsAmount++;
                if (activity.Name == "מיסי חבר")
                    Shevets.Where(s => s.Id == activity.ShevetId).FirstOrDefault().MembersAmount++;
            }
            SaveChanges();
        }

        public Shevet AddShevet(Shevet s)
        {
            s.Id = GetLastShevetID() + 1;
            Shevets.Add(s);
            Hanhagas.Where(h => h.Id == s.HanhagaId).FirstOrDefault().ShevetNumber++;   
            SaveChanges();
            return s;
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
        public int GetLastCadetID()
        {
            Cadet ca = Cadets.Where(c => c.Id > 0).OrderByDescending(cadet => cadet.Id).FirstOrDefault();
            if (ca == null)
                return 0;
            return ca.Id;
        }

        public int GetLastShevetID()
        {
            Shevet sh = Shevets.Where(s => s.Id > 0).OrderByDescending(shevet => shevet.Id).FirstOrDefault();
            if (sh == null)
                return 0;
            return sh.Id;
        }

        public int GetLastActivityID()
        {
            Activity ac = Activities.Where(a => a.Id > 0).OrderByDescending(activity => activity.Id).FirstOrDefault();
            if (ac == null)
                return 0;
            return ac.Id;
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
            foreach (var worker in workers)
            {
                WorkerToShow workerToShow = new WorkerToShow
                {
                    ID = worker.Id,
                    FirstName = worker.User.FirstName,
                    LastName = worker.User.LastName,
                    Email = worker.User.Email,
                    PersonalID = worker.User.PersonalId
                };
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
                ParentToShow parentToShow = new ParentToShow
                {
                    ID = parent.Id,
                    FirstName = parent.User.FirstName,
                    LastName = parent.User.LastName,
                    Email = parent.User.Email,
                    PersonalID = parent.User.PersonalId
                };
                int? shevetID = parent.ShevetId;
                parentToShow.Shevet = Shevets.Where(s => s.Id == shevetID).FirstOrDefault().Name;
                int? hanhagaID = Shevets.Where(s => s.Id == shevetID).FirstOrDefault().HanhagaId;
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
                CadetToShow cadetToShow = new CadetToShow
                {
                    ID = cadet.Id,
                    FirstName = cadet.FName,
                    LastName = cadet.LName,
                    Class = cadet.Class,
                    PersonalID = cadet.PersonalId
                };
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

        public List<Role> GetAllRoles()
        {
            return new List<Role>(Roles);
        }

        public List<Hanhaga> GetAllHanhagas()
        {
            return new List<Hanhaga>(Hanhagas);
        }

        public List<Shevet> GetAllShevets()
        {
            return new List<Shevet>(Shevets);
        }

        public List<ShevetToShow> GetAllShevetsToShow()
        {
            List<ShevetToShow> toReturn = new List<ShevetToShow>();
            List<Shevet> shevetsEzer = new List<Shevet>(Shevets);
            foreach(Shevet s in shevetsEzer)
            {
                ShevetToShow sts = new ShevetToShow();
                sts.ID = s.Id;
                sts.Name = s.Name;
                sts.MembersAmount = s.MembersAmount;
                sts.Hanhaga = Hanhagas.Where(h => h.Id == s.HanhagaId).FirstOrDefault().Name;
                toReturn.Add(sts);
            }
            return toReturn;
        }

        public List<Shevet> GetShevetsObjectsForHanhaga(string hanhaga)
        {
            int hanhagaId = Hanhagas.Where(h => h.Name == hanhaga).FirstOrDefault().Id;
            List<Shevet> toReturn = new List<Shevet>();
            foreach (Shevet s in Shevets)
            {
                if (s.HanhagaId == hanhagaId)
                    toReturn.Add(s);
            }
            return toReturn;
        }

        public List<ShevetToShow> GetShevetsForHanhaga(string hanhaga)
        {
            int hanhagaId = Hanhagas.Where(h => h.Name == hanhaga).FirstOrDefault().Id;
            string hanhagaName = Hanhagas.Where(h => h.Id == hanhagaId).FirstOrDefault().Name;
            List<ShevetToShow> toReturn = new List<ShevetToShow>();
            foreach(Shevet s in Shevets)
            {
                if (s.HanhagaId == hanhagaId)
                {
                    ShevetToShow sts = new ShevetToShow();
                    sts.ID = s.Id;
                    sts.Name = s.Name;
                    sts.MembersAmount = s.MembersAmount;
                    sts.Hanhaga = hanhagaName;
                    toReturn.Add(sts);
                }
            }
            return toReturn;
        }

        public List<ActivityToShow> GetAllActivities()
        {
            List<ActivityToShow> toReturn = new List<ActivityToShow>();
            List<Activity> activitiesEzer = new List<Activity>(Activities);
            foreach(Activity a in activitiesEzer)
            {
                ActivityToShow ats = new ActivityToShow();
                ats.ID = a.Id;
                ats.Name = a.Name;
                ats.StartDate = new Date(a.StartDate);
                ats.EndDate = new Date(a.EndDate);
                ats.RelevantClass = GetRelevantClassString(a.RelevantClass);
                ats.CadetsAmount = a.CadetsAmount;
                ats.Price = a.Price;
                ats.DiscountPercent = a.DiscountPercent;
                if (a.IsOpen == 0)
                    ats.IsOpen = "Red";
                else
                    ats.IsOpen = "Green";
                ats.ShevetID = a.ShevetId;
                ats.Shevet = Shevets.Where(s => s.Id == a.ShevetId).FirstOrDefault().Name;
                ats.HanhagaID = Shevets.Where(s => s.Id == a.ShevetId).FirstOrDefault().HanhagaId;
                ats.Hanhaga = Hanhagas.Where(h => h.Id == ats.HanhagaID).FirstOrDefault().Name;
                toReturn.Add(ats);
            }
            return toReturn;
        }

        public List<ActivityToShow> GetActivitiesForHanhaga(string hanhaga)
        {
            int hanhagaID = Hanhagas.Where(h => h.Name == hanhaga).FirstOrDefault().Id;
            List<ActivityToShow> toReturn = new List<ActivityToShow>();
            List<Activity> activitiesEzer = new List<Activity>(Activities);
            foreach (Activity a in activitiesEzer)
            {
                if (a.HanhagaId == hanhagaID)
                {
                    ActivityToShow ats = new ActivityToShow();
                    ats.ID = a.Id;
                    ats.Name = a.Name;
                    ats.StartDate = new Date(a.StartDate);
                    ats.EndDate = new Date(a.EndDate);
                    ats.RelevantClass = GetRelevantClassString(a.RelevantClass);
                    ats.CadetsAmount = a.CadetsAmount;
                    ats.Price = a.Price;
                    ats.DiscountPercent = a.DiscountPercent;
                    if (a.IsOpen == 0)
                        ats.IsOpen = "Red";
                    else
                        ats.IsOpen = "Green";
                    ats.ShevetID = a.ShevetId;
                    ats.Shevet = Shevets.Where(s => s.Id == a.ShevetId).FirstOrDefault().Name;
                    ats.HanhagaID = hanhagaID;
                    ats.Hanhaga = Hanhagas.Where(h => h.Id == hanhagaID).FirstOrDefault().Name;
                    toReturn.Add(ats);
                }
            }
            return toReturn;
        }

        public List<ActivityToShow> GetActivitiesForShevet(string shevet, string hanhaga)
        {
            int hanhagaID = Hanhagas.Where(h => h.Name == hanhaga).FirstOrDefault().Id;
            int shevetID = Shevets.Where(s => s.Name == shevet && s.HanhagaId == hanhagaID).FirstOrDefault().Id;
            List<ActivityToShow> toReturn = new List<ActivityToShow>();
            List<Activity> activitiesEzer = new List<Activity>(Activities);
            foreach (Activity a in activitiesEzer)
            {
                if (a.ShevetId == shevetID)
                {
                    ActivityToShow ats = new ActivityToShow();
                    ats.ID = a.Id;
                    ats.Name = a.Name;
                    ats.StartDate = new Date(a.StartDate);
                    ats.EndDate = new Date(a.EndDate);
                    ats.RelevantClass = GetRelevantClassString(a.RelevantClass);
                    ats.CadetsAmount = a.CadetsAmount;
                    ats.Price = a.Price;
                    ats.DiscountPercent = a.DiscountPercent;
                    if (a.IsOpen == 0)
                        ats.IsOpen = "Red";
                    else
                        ats.IsOpen = "Green";
                    ats.ShevetID = a.ShevetId;
                    ats.Shevet = Shevets.Where(s => s.Id == a.ShevetId).FirstOrDefault().Name;
                    ats.HanhagaID = hanhagaID;
                    ats.Hanhaga = Hanhagas.Where(h => h.Id == hanhagaID).FirstOrDefault().Name;
                    toReturn.Add(ats);
                }
            }
            return toReturn;
        }

        private string GetRelevantClassString(int relevantClass)
        {
            switch(relevantClass)
            {
                case 0: return "כל השבט";
                case 1: return "צעירה";
                case 2: return "בוגרת";
                case 3: return "שכבג";
                case 4: return "ד";
                case 5: return "ה";
                case 6: return "ו";
                case 7: return "ז";
                case 8: return "ח";
                case 9: return "ט";
                case 10: return "י";
                case 11: return "יא";
                case 12: return "יב";
                case 13: return "פעילים";
            }
            return " ";
        }

        public List<CadetToShow> GetCadetsForActivity(int activityID)
        {
            List<ActivitiesHistory> activitiesHistories = new List<ActivitiesHistory>(ActivitiesHistories);
            List<CadetToShow> toReturn = new List<CadetToShow>();
            foreach(ActivitiesHistory ah in activitiesHistories)
            {
                if (ah.ActivityId == activityID)
                {
                    CadetToShow cts = new CadetToShow();
                    Cadet cadet = Cadets.Where(c => c.Id == ah.CadetId).FirstOrDefault();
                    cts.ID = cadet.Id;
                    cts.FirstName = cadet.FName;
                    cts.LastName = cadet.LName;
                    cts.Class = cadet.Class;
                    cts.PersonalID = cadet.PersonalId;
                    Shevet shevet = Shevets.Where(s => s.Id == cadet.ShevetId).FirstOrDefault();
                    cts.Shevet = shevet.Name;
                    Hanhaga hanhaga = Hanhagas.Where(h => h.Id == shevet.HanhagaId).FirstOrDefault();
                    cts.Hanhaga = hanhaga.Name;
                    Role role = Roles.Where(r => r.Id == cadet.RoleId).FirstOrDefault();
                    cts.Role = role.RoleName;
                    toReturn.Add(cts);
                }
            }
            return toReturn;
        }

        public List<ActivityToShow> GetActivitiesForCadet(int cadetID)
        {
            List<ActivitiesHistory> activitiesHistories = new List<ActivitiesHistory>(ActivitiesHistories);
            List<ActivityToShow> toReturn = new List<ActivityToShow>();
            foreach(ActivitiesHistory ah in activitiesHistories)
            {
                if(ah.CadetId==cadetID)
                {
                    ActivityToShow ats = new ActivityToShow();
                    Activity activity = Activities.Where(a => a.Id == ah.ActivityId).FirstOrDefault();
                    ats.Name = activity.Name;
                    ats.StartDate = new Date(activity.StartDate);
                    ats.EndDate = new Date(activity.EndDate);
                    ats.RelevantClass = GetRelevantClassString(activity.RelevantClass);
                    ats.CadetsAmount = activity.CadetsAmount;
                    ats.Price = activity.Price;
                    ats.DiscountPercent = activity.DiscountPercent;
                    if (activity.IsOpen == 1)
                        ats.IsOpen = "Green";
                    else
                        ats.IsOpen = "Red";
                    ats.ShevetID = activity.ShevetId;
                    ats.Shevet = Shevets.Where(s => s.Id == ats.ShevetID).FirstOrDefault().Name;
                    ats.HanhagaID = activity.HanhagaId;
                    ats.Hanhaga = Hanhagas.Where(h => h.Id == ats.HanhagaID).FirstOrDefault().Name;
                    ats.ID = activity.Id;
                    toReturn.Add(ats);
                }
            }
            return toReturn;
        }

        public List<CadetToShow> GetCadetsForParent(int parentID)
        {
            List<CadetToShow> cadets = GetAllCadets();
            List<CadetToShow> toReturn = new List<CadetToShow>();
            foreach (CadetToShow c in cadets)
            {
                if (IsChildOf(c.ID, parentID))
                {
                    toReturn.Add(c);
                }
            }
            return toReturn;
        }

        private bool IsChildOf(int cadetID, int parentID)
        {
            List<CadetParent> cadetParents = new List<CadetParent>(CadetParents);
            foreach(CadetParent cp in cadetParents)
            {
                if (cp.CadetId == cadetID && cp.ParentId == parentID)
                    return true;
            }
            return false;
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
                if (role == "אדמין")
                    return 1;
                if (role == "ראש הנהגה")
                    return 2;
                if (role == "ראש שבט")
                    return 3;
            }
            return 0;
        }

        public string GetHanhaga(int id)
        {
            Worker worker = Workers.Where(w => w.UserId == id).FirstOrDefault();
            Parent parent = Parents.Where(p => p.UserId == id).FirstOrDefault();
            if (worker != null)
            {
                int? wHanhagaId = worker.HanhagaId;
                if (wHanhagaId != null)
                    return Hanhagas.Where(h => h.Id == wHanhagaId).FirstOrDefault().Name;
                return "";
            }
            if (parent == null)
                return "";
            int? pShevetId = parent.ShevetId;
            int? pHanhagaId = Shevets.Where(s => s.Id == pShevetId).FirstOrDefault().HanhagaId;
            return Hanhagas.Where(h => h.Id == pHanhagaId).FirstOrDefault().Name;
        }

        public int GetHanhagaID(int id)
        {
            Worker w = Workers.Where(w => w.UserId == id).FirstOrDefault();
            Parent p = Parents.Where(p => p.UserId == id).FirstOrDefault();
            if (w != null)
            {
                int? wHanhagaId = w.HanhagaId;
                if (wHanhagaId != null)
                    return Hanhagas.Where(h => h.Id == wHanhagaId).FirstOrDefault().Id;
                return -2;
            }
            int? pShevetId = p.ShevetId;
            int? pHanhagaId = Shevets.Where(s => s.Id == pShevetId).FirstOrDefault().HanhagaId;
            return Hanhagas.Where(h => h.Id == pHanhagaId).FirstOrDefault().Id;
        }

        public string GetShevet(int id)
        {
            Worker w = Workers.Where(w => w.UserId == id).FirstOrDefault();
            Parent p = Parents.Where(p => p.UserId == id).FirstOrDefault();
            if (w != null)
            {
                int? wShevetId = w.ShevetId;
                if(wShevetId!=null)
                    return Shevets.Where(h => h.Id == wShevetId).FirstOrDefault().Name;
                return "";
            }
            int? pShevetId = p.ShevetId;
            return Shevets.Where(h => h.Id == pShevetId).FirstOrDefault().Name;
        }

        public int GetShevetID(int id)
        {
            Worker w = Workers.Where(w => w.UserId == id).FirstOrDefault();
            Parent p = Parents.Where(p => p.UserId == id).FirstOrDefault();
            if (w != null)
            {
                int? wShevetId = w.ShevetId;
                if (wShevetId != null)
                    return Shevets.Where(h => h.Id == wShevetId).FirstOrDefault().Id;
                return -2;
            }
            int? pShevetId = p.ShevetId;
            return Shevets.Where(h => h.Id == pShevetId).FirstOrDefault().Id;
        }

        public string GetRole(int cadetId)
        {
            int roleId = Cadets.Where(c => c.Id == cadetId).FirstOrDefault().Id;
            return Roles.Where(r => r.Id == roleId).FirstOrDefault().RoleName;
        }

        public bool IsInRelevantClass(string relevantClass, string @class, string role)
        {
            string roleClass = GetClassForRole(role);
            if (relevantClass == "כל השבט")
                return true;
            if (relevantClass == @class || relevantClass == roleClass)
                return true;
            if (relevantClass == "צעירה")
                return @class == "ד" || roleClass == "ד" || @class == "ה" || roleClass == "ה";
            if (relevantClass == "בוגרת")
                return @class == "ו" || roleClass == "ו" || @class == "ז" || roleClass == "ז" || @class == "ח" || roleClass == "ח";
            if (relevantClass == "שכבג")
                return @class == "י" || @class == "יא" || @class == "יב";
            return false;
        }

        public bool IsRegistered(int cadetID, int activityID)
        {
            List<CadetToShow> cadetsForActivity = GetCadetsForActivity(activityID);
            foreach(CadetToShow c in cadetsForActivity)
            {
                if (c.ID == cadetID)
                    return true;
            }
            return false;
        }

        public Parent GetParent(int id)
        {
            return Parents.Where(p => p.UserId == id).FirstOrDefault();
        }

        private string GetClassForRole(string role)
        {
            if (role == "חניך ד" || role == "מדריך ד" || role == "רשגד ד")
                return "ד";
            if (role == "חניך ה" || role == "מדריך ה" || role == "רשגד ה")
                return "ה";
            if (role == "חניך ו" || role == "מדריך ו" || role == "רשגד ו")
                return "ו";
            if (role == "חניך ז" || role == "מדריך ז" || role == "רשגד ז")
                return "ז";
            if (role == "חניך ח" || role == "מדריך ח" || role == "רשגד ח")
                return "ח";
            if (role == "חניך ט" || role == "מדריך ט")
                return "ט";
            return "פעילים";
        }
        #endregion
    }         
}