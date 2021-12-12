using Microsoft.AspNetCore.Mvc;
using ZofimPortalServerBL.Models;

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

        [Route("Login")]
        [HttpGet]
        public object Login([FromQuery] string uName, [FromQuery] string pass)
        {
            object user = context.Login(uName, pass);

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
        public bool IsUserExist([FromQuery] string uName)
        {
            return context.IsUserExist(uName);
        }
    }
}
