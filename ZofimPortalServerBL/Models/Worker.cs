using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    [Table("Worker")]
    public partial class Worker
    {
        [Column("ShevetID")]
        public int? ShevetId { get; set; }
        [Column("RoleID")]
        public int RoleId { get; set; }
        [Column("HanhagaID")]
        public int? HanhagaId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey(nameof(HanhagaId))]
        [InverseProperty("Workers")]
        public virtual Hanhaga Hanhaga { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Workers")]
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(ShevetId))]
        [InverseProperty("Workers")]
        public virtual Shevet Shevet { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Workers")]
        public virtual User User { get; set; }
    }
}
