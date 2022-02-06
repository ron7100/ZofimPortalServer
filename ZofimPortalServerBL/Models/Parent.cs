using System;
using System.Collections.Generic;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    public partial class Parent
    {
        public int ShevetId { get; set; }
        public int UserId { get; set; }
        public int Id { get; set; }

        public virtual Shevet Shevet { get; set; }
        public virtual User User { get; set; }
    }
}
