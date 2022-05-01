using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    [Table("Cadet_Parent")]
    public partial class CadetParent
    {
        [Key]
        [Column("ParentID")]
        public int ParentId { get; set; }
        [Key]
        [Column("CadetID")]
        public int CadetId { get; set; }

        [ForeignKey(nameof(CadetId))]
        [InverseProperty("CadetParents")]
        public virtual Cadet Cadet { get; set; }
        [ForeignKey(nameof(ParentId))]
        [InverseProperty("CadetParents")]
        public virtual Parent Parent { get; set; }
    }
}
