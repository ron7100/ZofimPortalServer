using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    [Keyless]
    [Table("Cadet_Parent")]
    public partial class CadetParent
    {
        [Column("ParentID")]
        public int ParentId { get; set; }
        [Column("CadetID")]
        public int CadetId { get; set; }

        [ForeignKey(nameof(CadetId))]
        public virtual Cadet Cadet { get; set; }
        [ForeignKey(nameof(ParentId))]
        public virtual Parent Parent { get; set; }
    }
}
