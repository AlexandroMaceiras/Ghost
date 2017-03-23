using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ghost.Models;
using Ghost.Repositorios;

namespace Ghost.Controllers
{
    public class ListaController : Controller
    {
        private ListaContexto db = new ListaContexto();

        private IListaRepositorio _listaRepositorio;

        public ListaController()
        {
            _listaRepositorio = new ListaRepositorio(new ListaContexto());
        }

        // GET: Lista
        public ActionResult Index()
        {
            return View(db.Listas.ToList());
        }

        public ActionResult IndexBootstrap()
        {
            return View(db.Listas.ToList());
        }

        [Authorize, ActionName("Index"), HttpPost]
        public ActionResult Index2(string cliente, string cpfcnpj, string pessoaJuridica, string numeroContrato, string numeroProcesso, string incluirGrupo, string codOpSolvere, string grupoEconomico, string carteira, string escritorio1, string escritorio2)
        {

            var listas = _listaRepositorio.ListasFiltro(cliente, cpfcnpj, pessoaJuridica, numeroContrato, numeroProcesso, incluirGrupo, codOpSolvere, grupoEconomico, carteira, escritorio1, escritorio2);


            ViewBag.Proxima = false;
            ViewBag.Anterior = false;

            if (cliente != "" || cpfcnpj != "" || numeroContrato != "" || numeroProcesso != "" || codOpSolvere != "" || grupoEconomico != "" || carteira != "" || escritorio1 != "" || escritorio2 != "")
                {
                if (cliente != "") ViewBag.Introducao = "Resultados de Busca";
                else ViewBag.Introducao = "Todas as Listas Existentes";

                if (listas.Count() < 1)
                    ViewBag.Erro = cliente;

                return View("Index", listas);
            }
            return RedirectToAction("Index");
        }

        // GET: Lista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            return View(lista);
        }

        // GET: Lista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListaId,Nome,Cpf,Rg,Ativo")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                db.Listas.Add(lista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lista);
        }

        // GET: Lista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            return View(lista);
        }

        // POST: Lista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListaId,Nome,Cpf,Rg,Ativo")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lista);
        }

        // GET: Lista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            return View(lista);
        }

        // POST: Lista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lista lista = db.Listas.Find(id);
            db.Listas.Remove(lista);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
