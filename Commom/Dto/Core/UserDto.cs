using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Commom.Dto.Core
{
    public class UserDto : BaseDto
    {
        [Required]
        [DisplayName("Usuário")]
        public string Login { get; set; }

        [Required]
        [DisplayName("Senha")]
        public string PassWord { get; set; }

        [Required]
        [DisplayName("Confirmar a senha")]
        public string PassWordConfirm { get; set; }


        [Required]
        public int Perfil { get; set; }
    }
}
