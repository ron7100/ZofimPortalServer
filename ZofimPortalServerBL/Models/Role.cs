using System;
using System.Collections.Generic;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    public partial class Role
    {
        public Role()
        {
            Cadets = new HashSet<Cadet>();
        }

        public string RoleName { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Cadet> Cadets { get; set; }
    }
}
