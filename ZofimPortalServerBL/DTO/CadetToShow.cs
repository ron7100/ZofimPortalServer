using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZofimPortalServerBL.Models;

namespace ZofimPortalServer.DTO
{
    public class CadetToShow
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public string PersonalID { get; set; }
        public string Shevet { get; set; }
        public string Hanhaga { get; set; }
        public string Role { get; set; }
    }
}
