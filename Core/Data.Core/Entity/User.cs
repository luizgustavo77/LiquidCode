using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Core.Entity
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string PassWord { get; set; }
        [Required]
        public int Perfil { get; set; }
    }
}
