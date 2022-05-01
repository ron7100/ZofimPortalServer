using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    [Table("Parent")]
    public partial class Parent
    {
        public Parent()
        {
            CadetParents = new HashSet<CadetParent>();
        }

        [Column("ShevetID")]
        public int? ShevetId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey(nameof(ShevetId))]
        [InverseProperty("Parents")]
        public virtual Shevet Shevet { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Parents")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(CadetParent.Parent))]
        public virtual ICollection<CadetParent> CadetParents { get; set; }
    }
}
