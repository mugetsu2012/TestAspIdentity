using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiTestAspIdentity.SQL.Model;
using MiTestAspIdentity.Web.Model;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace MiTestAspIdentity.Web.Controllers
{
    public class CuentaController:Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public CuentaController(UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ingresar(LoginDto loginDto)
        {
            SignInResult resultLogin =
                await _signInManager.PasswordSignInAsync(loginDto.Usuario, loginDto.Password, true, false);

            if (resultLogin.Succeeded)
            {
                return RedirectToAction("Privado", "Home");
            }
            else
            {
                TempData["error"] = "login invalido";

                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GuardarUsuario(GuardarUsuarioDto guardarUsuario)
        {
            Usuario usuario = new Usuario()
            {
                Nombre = guardarUsuario.Nombre,
                Apellido = guardarUsuario.Apellido,
                Email = guardarUsuario.Email,
                UserName = guardarUsuario.UserName,
                Id = guardarUsuario.UserName
            };


            await _userManager.CreateAsync(usuario, guardarUsuario.Password);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role,"rol1"));
            claims.Add(new Claim(ClaimTypes.Surname,usuario.Apellido));
            claims.Add(new Claim(ClaimTypes.GivenName,usuario.Nombre));
            claims.Add(new Claim(ClaimTypes.Email,usuario.Email));
            claims.Add(new Claim("cuenta","fd54f5d"));
            await _userManager.AddClaimsAsync(usuario, claims);

            return RedirectToAction("Login");

        }


    }
}
