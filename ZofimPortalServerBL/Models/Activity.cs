using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    [Table("Activity")]
    public partial class Activity
    {
        public Activity()
        {
            ActivitiesHistories = new HashSet<ActivitiesHistory>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        public int RelevantClass { get; set; }
        public int Price { get; set; }
        public int? DiscountPercent { get; set; }
        public int IsOpen { get; set; }
        [Column("ShevetID")]
        public int ShevetId { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey(nameof(ShevetId))]
        [InverseProperty("Activities")]
        public virtual Shevet Shevet { get; set; }
        [InverseProperty(nameof(ActivitiesHistory.Activity))]
        public virtual ICollection<ActivitiesHistory> ActivitiesHistories { get; set; }
    }
}
