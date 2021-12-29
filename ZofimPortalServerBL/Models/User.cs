using System;
using System.Collections.Generic;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    public partial class User
    {
        public User()
        {
            Parents = new HashSet<Parent>();
            Workers = new HashSet<Worker>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Parent> Parents { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
