using Commom.Dto;
using Commom.Dto.Core;
using Commom.Proxy;
using LiquidCode.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiquidCode.Controllers
{
    public class CoreController : Controller
    {
        private readonly ILogger<CoreController> _logger;

        public CoreController(ILogger<CoreController> logger)
        {
            _logger = logger;
        }
            
        [AutorizacaoSessionAdmin]
        public async Task<IActionResult> Index()
        {
            List<UserDto> users = await new APIUser().GetAll();

            return View(users);
        }

        [AutorizacaoSessionAdmin]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await new APIUser().Find(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [AutorizacaoSessionAdmin]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await new APIUser().Find(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [AutorizacaoSessionAdmin]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Login,PassWord,PassWordConfirm,Perfil")] UserDto user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await new APIUser().Edit(user);

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [AutorizacaoSessionAdmin]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await new APIUser().Find(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [AutorizacaoSessionAdmin]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await new APIUser().Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro([Bind("Id,Name,Login,PassWord,PassWordConfirm,Perfil")] UserDto user)
        {
            if (user == null || string.IsNullOrEmpty(user.PassWord) || !user.PassWord.Equals(user.PassWordConfirm))
            {
                ModelState.AddModelError("PassWordConfirm", "Senhas diferentes!");
            }

            else if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                RetornaAcaoDto result = await new APIUser().Add(user);
                if (result.Retorno)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ModelState.AddModelError("Login", result.Mensagem);
                }
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Login,PassWord")] UserDto user)
        {
            try
            {
                UserDto login = await new APIUser().Login(user);

                if (login != null && login.Id != Guid.Empty)
                {
                    Session.Create<UserDto>("usuario", login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PassWord", ex.Message);
            }

            return View(user);
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            Session.CleanObject();
            return RedirectToAction("Index", "Home");
        }
    }
}
