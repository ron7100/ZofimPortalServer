using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            Cadets = new HashSet<Cadet>();
            Workers = new HashSet<Worker>();
        }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [InverseProperty(nameof(Cadet.Role))]
        public virtual ICollection<Cadet> Cadets { get; set; }
        [InverseProperty(nameof(Worker.Role))]
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
