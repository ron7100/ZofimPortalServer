using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    [Table("ActivitiesHistory")]
    public partial class ActivitiesHistory
    {
        [Key]
        [Column("CadetID")]
        public int CadetId { get; set; }
        [Key]
        [StringLength(50)]
        public string Activity { get; set; }

        [ForeignKey(nameof(CadetId))]
        [InverseProperty("ActivitiesHistories")]
        public virtual Cadet Cadet { get; set; }
    }
}
