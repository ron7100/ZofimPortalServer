using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZofimPortalServerBL.Models;

namespace ZofimPortalServer.Controllers
{
    [Route("ZofimPortalAPI")]
    [ApiController]
    public class BackGammonController : ControllerBase
    {
        ZofimPortalDBContext context;
        public BackGammonController(ZofimPortalDBContext context)
        {
            this.context = context;
        }
    }
}
