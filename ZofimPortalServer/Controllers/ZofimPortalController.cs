using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZofimPortalServerBL.Models;
using ZofimPortalServer.DTO;

namespace ZofimPortalServer.Controllers
{
    [Route("ZofimPortalAPI")]
    [ApiController]
    public class ZofimPortalController : ControllerBase
    {
        #region Add connection to the db context using dependency injection
        ZofimPortalDBContext context;
        public ZofimPortalController(ZofimPortalDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region הרשמה והתחברות
        [Route("Login")]
        [HttpGet]
        public User Login([FromQuery] string email, [FromQuery] string pass)
        {
            User user = context.Login(email, pass);

            if (user != null) //בודק האם ההתחברות הצליחה
            {
                HttpContext.Session.SetObject("theUser", user);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                //Important! Due to the Lazy Loading, the user will be returned with all of its contents!!
                return user;
            }
            else //אם לא הצליח להתחבר
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }

        }

        [Route("IsUserExist")]
        [HttpGet]
        public bool IsUserExist([FromQuery] string email)
        {
            return context.IsUserExist(email);
        }

        [Route("IsIdExist")]
        [HttpGet]
        public bool IsIdExist([FromQuery] string id)
        {
            return context.IsIdExist(id);
        }


        [Route("SignUp")]
        [HttpPost]
        public User SignUp([FromBody] User user)
        {
            if (user == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return null;
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            context.SignUp(user);
            return user;
        }
        #endregion

        #region שמירת שינויים
        [Route("SaveUserChanges")]
        [HttpPost]
        public void SaveUserChanges([FromBody] User u)
        {
            context.SaveUserChanges(u);
        }

        [Route("SaveWorkerChanges")]
        [HttpPost]
        public void SaveWorkerChanges([FromBody] WorkerToShow w)
        {
            context.SaveWorkerChanges(w);
        }

        [Route("SaveParentChanges")]
        [HttpPost]
        public void SaveParentChanges([FromBody] ParentToShow p)
        {
            context.SaveParentChanges(p);
        }

        [Route("SaveCadetChanges")]
        [HttpPost]
        public void SaveCadetChanges([FromBody] CadetToShow c)
        {
            context.SaveCadetChanges(c);
        }

        [Route("AddCadet")]
        [HttpPost]
        public Cadet AddCadet([FromBody] Cadet c)
        {
            Cadet cadet = context.AddCadet(c);
            return cadet;
        }

        [Route("ConnectCadetParent")]
        [HttpPost]
        public void ConnectCadetParent([FromBody] CadetParent cadetParent)
        {
            context.ConnectCadetParent(cadetParent);
        }
        #endregion

        #region שליפת ID
        [Route("GetLastUserID")]
        [HttpGet]
        public int GetLastUserID()
        {
            return context.GetLastUserID();
        }

        [Route("GetLastWorkerID")]
        [HttpGet]
        public int GetLastWorkerID()
        {
            return context.GetLastWorkerID();
        }

        [Route("GetLastParentID")]
        [HttpGet]
        public int GetLastParentID()
        {
            return context.GetLastParentID();
        }
        #endregion

        #region שליפת רשימות
        [Route("GetAllUsers")]
        [HttpGet]
        public List<User> GetAllUsers()
        {
            return context.GetAllUsers();
        }

        [Route("GetAllWorkers")]
        [HttpGet]
        public List<WorkerToShow> GetAllWorkers()
        {
            return context.GetAllWorkers();
        }

        [Route("GetAllParents")]
        [HttpGet]
        public List<ParentToShow> GetParents()
        {
            return context.GetAllParents();
        }

        [Route("GetAllCadets")]
        [HttpGet]
        public List<CadetToShow> GetAllCadets()
        {
            return context.GetAllCadets();
        }

        [Route("GetAllRoles")]
        [HttpGet]
        public List<Role> GetAllRoles()
        {
            return context.GetAllRoles();
        }

        [Route("GetAllHanhagas")]
        [HttpGet]
        public List<Hanhaga> GetAllHanhagas()
        {
            return context.GetAllHanhagas();
        }

        [Route("GetAllShevets")]
        [HttpGet]
        public List<Shevet> GetAllShevets()
        {
            return context.GetAllShevets();
        }

        [Route("GetAllShevetsToShow")]
        [HttpGet]
        public List<ShevetToShow> GetAllShevetsToShow()
        {
            return context.GetAllShevetsToShow();
        }

        [Route("GetShevetsForHanhaga")]
        [HttpGet]
        public List<ShevetToShow> GetShevetsForHanhaga([FromQuery] string hanhaga)
        {
            return context.GetShevetsForHanhaga(hanhaga);
        }
        #endregion

        #region קבלת נתוני משתמש
        [Route("GetPermissionLevel")]
        [HttpGet]
        public int GetPermissionLevel([FromQuery] int id)
        {
            //1 -> admin, can see all
            //2 -> can see only from his hanhaga
            //3 -> can see only parents and cadets from his shevet
            return context.GetPermissionLevel(id);
        }

        [Route("GetHanhaga")]
        [HttpGet]
        public string GetHanhaga([FromQuery] int id)
        {
            return context.GetHanhaga(id);
        }

        [Route("GetShevet")]
        [HttpGet]
        public string GetShevet([FromQuery] int id)
        {
            return context.GetShevet(id);
        }
        #endregion
    }
}
