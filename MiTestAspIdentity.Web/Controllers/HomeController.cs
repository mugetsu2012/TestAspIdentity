using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiTestAspIdentity.Web.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await Task.Delay(1);

            return View();
        }

        [Authorize]
        public IActionResult Privado()
        {
            return View();
        }
    }
}
