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
        public User Login(string uName, string pass)
        {
            User user = this.Users.Where(u => u.Username == uName && u.Password == pass).FirstOrDefault();
            if (user.UserType == "Worker")
                this.Users.Include(us => us.Workers).Where(u => u.Username == uName && u.Password == pass).FirstOrDefault();
            else if (user.UserType == "Parent")
                this.Users.Include(us => us.Parents).Where(u => u.Username == uName && u.Password == pass).FirstOrDefault();
            else if (user.UserType == "Cadet")
                this.Users.Include(us => us.Cadets).Where(u => u.Username == uName && u.Password == pass).FirstOrDefault();
            return user;
        }
    }
}
