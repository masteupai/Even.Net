using Event.Net.Models;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Event.Net.Controllers
{
    public class HomeController : Controller
    {
        static public List<EventoCreateVM> Eventos { get; set; } = new List<EventoCreateVM>();

        public HomeController()
        {
        }
        public IActionResult Index()
        {
            return View(Eventos);
        }
        public IActionResult Details(Guid id)
        {
            var retorno = Eventos.Where(x => x.Id == id).FirstOrDefault();

            return View(retorno);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EventoCreateVM evento)
        {
            evento.Id = Guid.NewGuid();
            Eventos.Add(evento);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var retorno = Eventos.Where(x => x.Id == id).FirstOrDefault();

            return View(retorno);
        }
        [HttpPost]
        public IActionResult Edit(EventoCreateVM evento)
        {
            Eventos.RemoveAll(x => x.Id == evento.Id);
            Eventos.Add(evento);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Guid id, string oi)
        {
            var retorno = Eventos.Where(x => x.Id == id).FirstOrDefault();

            return View(retorno);
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            Eventos.RemoveAll(x => x.Id == id);

            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
