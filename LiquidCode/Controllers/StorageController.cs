using Commom.Dto.Storage;
using Commom.Proxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiquidCode.Controllers
{
    public class StorageController : Controller
    {
        private readonly ILogger<StorageController> _logger;

        public StorageController(ILogger<StorageController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<CoffeeDto> coffees = await new APICoffee().GetAll();

            return View(coffees);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await new APICoffee().Find(id.Value);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value,Description,Energy")] CoffeeDto coffee)
        {
            if (ModelState.IsValid)
            {
                coffee.Id = Guid.NewGuid();
                await new APICoffee().Add(coffee);
                return RedirectToAction(nameof(Index));
            }
            return View(coffee);
        }

        // GET: Coffee/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await new APICoffee().Find(id.Value);
            if (coffee == null)
            {
                return NotFound();
            }
            return View(coffee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Value,Description,Energy")] CoffeeDto coffee)
        {
            if (id != coffee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await new APICoffee().Edit(coffee);

                return RedirectToAction(nameof(Index));
            }
            return View(coffee);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await new APICoffee().Find(id.Value);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await new APICoffee().Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
