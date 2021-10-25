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
        public User Login([FromQuery] string email, [FromQuery] string pass)
        {
            User user = context.Login(email, pass);

            //Check user name and password
            if (user != null)
            {
                HttpContext.Session.SetObject("theUser", user);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!
                return user;
            }
            else
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
    }
}
