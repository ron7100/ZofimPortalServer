using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    [Table("Shevet")]
    public partial class Shevet
    {
        public Shevet()
        {
            Activities = new HashSet<Activity>();
            Cadets = new HashSet<Cadet>();
            Parents = new HashSet<Parent>();
            Workers = new HashSet<Worker>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("HanhagaID")]
        public int HanhagaId { get; set; }
        public int MembersAmount { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey(nameof(HanhagaId))]
        [InverseProperty("Shevets")]
        public virtual Hanhaga Hanhaga { get; set; }
        [InverseProperty(nameof(Activity.Shevet))]
        public virtual ICollection<Activity> Activities { get; set; }
        [InverseProperty(nameof(Cadet.Shevet))]
        public virtual ICollection<Cadet> Cadets { get; set; }
        [InverseProperty(nameof(Parent.Shevet))]
        public virtual ICollection<Parent> Parents { get; set; }
        [InverseProperty(nameof(Worker.Shevet))]
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
