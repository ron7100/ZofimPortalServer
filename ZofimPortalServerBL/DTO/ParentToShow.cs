using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZofimPortalServer.DTO
{
    public class ParentToShow
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalID { get; set; }
        public string Shevet { get; set; }
        public string Hanhaga { get; set; }
        public int KidsNumber { get; set; }
    }
}
