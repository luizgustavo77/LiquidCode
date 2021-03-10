using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Storage.Entity
{
    public class Coffee
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid FileId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Energy { get; set; }
    }
}
