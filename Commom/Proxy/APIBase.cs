using Commom.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Commom.Proxy
{
    public class APIBase<TInterface> where TInterface : BaseDto
    {
        internal string _baseEndpoint;
        public string _BaseUrl { get; set; }

        internal HttpClient Http;

        internal APIBase()
        {
            Http = new HttpClient();
        }

        public async Task<RetornaAcaoDto> Add(TInterface Item)
        {
            RetornaAcaoDto retorna = new RetornaAcaoDto();
            try
            {
                var result = await Http.PostAsJsonAsync<TInterface>(_BaseUrl + "/" + _baseEndpoint, Item);
                try
                {
                    retorna = await result.Content.ReadFromJsonAsync<RetornaAcaoDto>();
                }
                catch (Exception)
                {

                }

                return retorna;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RetornaAcaoDto> Edit(TInterface Item)
        {
            RetornaAcaoDto retorna = new RetornaAcaoDto();
            try
            {
                var result = await Http.PutAsJsonAsync<TInterface>(_BaseUrl + "/" + _baseEndpoint, Item);

                try
                {
                    retorna = await result.Content.ReadFromJsonAsync<RetornaAcaoDto>();
                }
                catch (Exception)
                {

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorna;
        }


        public async Task<RetornaAcaoDto> Delete(Guid Id)
        {
            RetornaAcaoDto retorna = new RetornaAcaoDto();
            var result = await Http.DeleteAsync(_BaseUrl + "/" + _baseEndpoint + "/" + Id.ToString());
            try
            {
                retorna = await result.Content.ReadFromJsonAsync<RetornaAcaoDto>();
            }
            catch (Exception)
            {

            }
            return retorna;
        }


        public async Task<TInterface> Find(Guid Id)
        {
            var item = await Http.GetFromJsonAsync<TInterface>(_BaseUrl + "/" + _baseEndpoint + "/" + Id.ToString());
            return item;
        }

        public async Task<List<TInterface>> GetAll()
        {
            var list = await Http.GetFromJsonAsync<List<TInterface>>(_BaseUrl + "/" + _baseEndpoint);
            return list;
        }


        public async Task<List<TInterface>> ByParentId(Guid Id)
        {
            var list = await Http.GetFromJsonAsync<List<TInterface>>(_BaseUrl + "/" + _baseEndpoint + "/ByParentId/" + Id.ToString());
            return list;
        }
    }
}
