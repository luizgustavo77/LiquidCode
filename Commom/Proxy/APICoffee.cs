using Commom.Dto.Storage;

namespace Commom.Proxy
{
    public class APICoffee : APIBase<CoffeeDto>
    {
        public APICoffee()
        {
            _BaseUrl = "https://localhost:44348";
            _baseEndpoint = "API/Coffee";
        }
    }
}
