using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Commom.Dto.Storage
{
    public class CoffeeDto : BaseDto
    {
        //[Required(ErrorMessage ="Obrigatorio")]
        public Guid FileId { get; set; }

        public string Value { get; set; }

        [Required(ErrorMessage = "Obrigatorio")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Obrigatorio")]
        public int Energy { get; set; }
    }
}
