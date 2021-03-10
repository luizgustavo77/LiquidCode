using Commom.Dto;
using Commom.Dto.Core;
using Data.Core.Entity;
using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Core
{
    public class UserServices : Base<User, UserDto>
    {
        public UserDto Login(string login, string password)
        {
            UserDto result = new UserDto();
            try
            {
                result = dbContext.Users.Where(x => x.Login == login)
                                        .Where(x => x.PassWord == password)
                                        .Select(x => Mapping.Mapper.Map<UserDto>(x)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public override RetornaAcaoDto Add(UserDto item)
        {
            RetornaAcaoDto retorna = new RetornaAcaoDto();

            try
            {
                if (dbContext.Users.Any(x => x.Login == item.Login))
                {
                    retorna.Mensagem = "Login já existe.";
                }
                else
                {
                    base.Add(item);
                }
            }
            catch { }

            return retorna;
        }
    }
}
