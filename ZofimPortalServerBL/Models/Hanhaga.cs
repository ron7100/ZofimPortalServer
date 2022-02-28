using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    [Table("Hanhaga")]
    public partial class Hanhaga
    {
        public Hanhaga()
        {
            Shevets = new HashSet<Shevet>();
            Workers = new HashSet<Worker>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int ShevetNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string GeneralArea { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [InverseProperty(nameof(Shevet.Hanhaga))]
        public virtual ICollection<Shevet> Shevets { get; set; }
        [InverseProperty(nameof(Worker.Hanhaga))]
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
