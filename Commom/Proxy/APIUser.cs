using Commom.Dto.Core;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Commom.Proxy
{
    public class APIUser : APIBase<UserDto>
    {
        public APIUser()
        {
            _BaseUrl = "https://localhost:44347";
            _baseEndpoint = "API/User";
        }

        public async Task<UserDto> Login(UserDto Item)
        {
            UserDto user = new UserDto();
            try
            {
                user = await Http.GetFromJsonAsync<UserDto>(_BaseUrl + "/" + _baseEndpoint + "/Login/" + Item.Login + "/" + Item.PassWord);

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
