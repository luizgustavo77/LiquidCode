using Commom.Dto.Core;
using Commom.Dto.Sales;
using Commom.Dto.Storage;
using Commom.Proxy;
using LiquidCode.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiquidCode.Controllers
{
    [AutorizacaoSession]
    public class MenuController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<CoffeeDto> coffees = await new APICoffee().GetAll();

            //coffees.Add(new CoffeeDto()
            //{
            //    Id = new Guid(),
            //    Name = "Expresso",
            //    Value = "0,50",
            //    Description = "Quente",
            //    Energy = 10,
            //});
            //coffees.Add(new CoffeeDto()
            //{
            //    Id = new Guid(),
            //    Name = "Capuchino",
            //    Value = "1,00",
            //    Description = "Chocolate",
            //    Energy = 7,
            //});
            //coffees.Add(new CoffeeDto()
            //{
            //    Id = new Guid(),
            //    Name = "Machiato",
            //    Value = "2,00",
            //    Description = "Fescura",
            //    Energy = 5,
            //});

            return View(coffees);
        }

        public async Task<IActionResult> NewOrder(string value)
        {
            CoinsDto coins = new CoinsDto();
            coins.Value = value;

            return View("_NewOrder", coins);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order([Bind("Value,One,Five,Ten,TwentyFive,Fifty,OneHundred")] CoinsDto coins)
        {
            if (ModelState.IsValid)
            {
                double dinheiro = (coins.Ten * 0.1) + (coins.TwentyFive * 0.25) + (coins.Fifty * 0.50) + (coins.OneHundred * 1);
                double preco = double.Parse(coins.Value);
                if (dinheiro >= preco)
                {
                    ViewBag.Troco = (dinheiro - preco).ToString("F");
                    ViewBag.Nome = Session.GetObject<UserDto>("usuario").Name;
                    return View("Invoice");
                }
            }
            return NotFound();
        }
    }
}
