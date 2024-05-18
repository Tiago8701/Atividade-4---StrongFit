using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Atividade3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace Atividade3.Controllers
{
    public class SessionController : Controller
    {
        public Contexto contexto;
        public SessionController(Contexto ctx)
        {
            contexto = ctx;
        }
        public IActionResult Index()
        {
            var acesso = HttpContext.Session.GetString("usuario_session");
            if (acesso != null)
                return View(contexto);
            else
                return View("Login");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            contexto.Add(usuario);  
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var confirma = contexto.Usuarios
            .Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
            .FirstOrDefault();
            if (confirma != null)
            {
                HttpContext.Session.SetString("usuario_session", confirma.Nome);
                return RedirectToAction("Correto");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Correto()
        {
            return View();
        }
        
    }
}
