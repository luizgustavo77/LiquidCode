using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Commom.Dto
{
    public class BaseDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}
