using Commom.Dto.Storage;
using Data.Storage.Entity;
using Services.Core;
using System.Collections.Generic;

namespace Services.Storage
{
    public class CoffeeServices : Base<Coffee, CoffeeDto>
    {
        public override List<CoffeeDto> GetAll()
        {
            return base.GetAll();
        }
    }
}
