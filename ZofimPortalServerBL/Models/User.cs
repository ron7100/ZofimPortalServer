using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ZofimPortalServerBL.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Parents = new HashSet<Parent>();
            Workers = new HashSet<Worker>();
        }

        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("firstName")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Column("lastName")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Column("personalID")]
        [StringLength(10)]
        public string PersonalId { get; set; }
        [Required]
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [InverseProperty(nameof(Parent.User))]
        public virtual ICollection<Parent> Parents { get; set; }
        [InverseProperty(nameof(Worker.User))]
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
