using Atividade1;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Atividade1.Controllers
{
    public class ConvidadoController : Controller
    {
        private static List<Convidado> convidados = new List<Convidado>();

        public IActionResult Index()
        {
            return View(convidados);
        }

        public IActionResult Create()
        {
            return View();
        }

        public bool retoronecomparecimento()
        {
            return true;
        }

        [HttpPost]
        public IActionResult Create(Convidado convidado)
        {
            if (ModelState.IsValid)
            {
                convidados.Add(convidado);
                convidado.Id = convidados.Select(cat => cat.Id).Max() + 1;
                return RedirectToAction("Index");
            }
            return View(convidado);
        }

        public IActionResult Details(int id)
        {
            var convidado = convidados.FirstOrDefault(c => c.Id == id);
            if (convidado == null)
            {
                return NotFound();
            }
            return View(convidado);
        }

        public IActionResult Delete(int id)
        {
            var convidado = convidados.FirstOrDefault(c => c.Id == id);
            if (convidado == null)
            {
                return NotFound();
            }
            return View(convidado);
        }
        public IActionResult Edit(int id, Convidado convidado)
        {
            if (id != convidado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingConvidado = convidados.FirstOrDefault(c => c.Id == id);
                if (existingConvidado != null)
                {
                    existingConvidado.Nome = convidado.Nome;
                    existingConvidado.EMail = convidado.EMail;
                    existingConvidado.Telefone = convidado.Telefone;
                    existingConvidado.Comparecimento = convidado.Comparecimento;
                }
                return RedirectToAction("Index");
            }
            return View(convidado);
        }

        public IActionResult comparecimento()
        {
            bool resultado = retoronecomparecimento();

            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var convidado = convidados.FirstOrDefault(c => c.Id == id);
            if (convidado != null)
            {
                convidados.Remove(convidado);
            }
            return RedirectToAction("Index");
        }
    }
}
