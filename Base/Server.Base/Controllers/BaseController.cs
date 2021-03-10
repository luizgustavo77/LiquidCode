using Commom.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Server.Storage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, S> : ControllerBase where T : BaseDto
    {
        [HttpGet("{id}")]
        public virtual async Task<T> Get([FromRoute] string id)
        {
            object[] methodArgs = { new Guid(id) };
            var service = (S)Activator.CreateInstance(typeof(S));
            var result = (T)typeof(S).GetMethod("Find").Invoke(service, methodArgs);

            return result;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<T>> Get()
        {
            var service = (S)Activator.CreateInstance(typeof(S));
            var result = (IEnumerable<T>)typeof(S).GetMethod("GetAll").Invoke(service, null);

            return result;
        }

        [HttpGet]
        [Route("ByParentId/{id}")]
        public virtual async Task<IEnumerable<T>> ByParentId([FromRoute] string id)
        {
            object[] methodArgs = { new Guid(id) };
            var service = (S)Activator.CreateInstance(typeof(S));
            var result = (IEnumerable<T>)typeof(S).GetMethod("ByParentId").Invoke(service, methodArgs);

            return result;
        }

        [HttpPost]
        public virtual async Task<RetornaAcaoDto> Post(T item)
        {
            object[] methodArgs = { item };
            var service = (S)Activator.CreateInstance(typeof(S));
            return (RetornaAcaoDto)typeof(S).GetMethod("Add").Invoke(service, methodArgs);
        }

        [HttpPut]
        public virtual async Task<RetornaAcaoDto> Put(T item)
        {
            object[] methodArgs = { item };
            var service = (S)Activator.CreateInstance(typeof(S));

            return (RetornaAcaoDto)typeof(S).GetMethod("Edit").Invoke(service, methodArgs); ;
        }

        [HttpDelete("{id}")]
        public virtual async Task<RetornaAcaoDto> Delete([FromRoute] string id)
        {
            object[] methodArgs = { new Guid(id) };
            var service = (S)Activator.CreateInstance(typeof(S));            

            return (RetornaAcaoDto)typeof(S).GetMethod("Delete").Invoke(service, methodArgs);
        }
    }
}
