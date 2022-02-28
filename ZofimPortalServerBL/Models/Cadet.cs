using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    [Table("Cadet")]
    public partial class Cadet
    {
        public Cadet()
        {
            ActivitiesHistories = new HashSet<ActivitiesHistory>();
        }

        [Required]
        [Column("fName")]
        [StringLength(50)]
        public string FName { get; set; }
        [Required]
        [Column("lName")]
        [StringLength(50)]
        public string LName { get; set; }
        [Required]
        [Column("PersonalID")]
        [StringLength(50)]
        public string PersonalId { get; set; }
        [Column("ShevetID")]
        public int ShevetId { get; set; }
        [Column("RoleID")]
        public int RoleId { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Cadets")]
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(ShevetId))]
        [InverseProperty("Cadets")]
        public virtual Shevet Shevet { get; set; }
        [InverseProperty(nameof(ActivitiesHistory.Cadet))]
        public virtual ICollection<ActivitiesHistory> ActivitiesHistories { get; set; }
    }
}
