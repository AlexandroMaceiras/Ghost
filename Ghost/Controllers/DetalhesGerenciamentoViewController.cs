using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ghost.Models;

namespace Ghost.Controllers
{
    public class DetalhesGerenciamentoViewController : Controller
    {
        private GerenciamentoContexto db = new GerenciamentoContexto();

        // GET: DetalhesGerenciamentoView
        public ActionResult Index()
        {
            return View(db.SLV_VW_GERE_DADOS_CADASTRAIS);
        }

        // GET: DetalhesGerenciamentoView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLV_VW_GERE_DADOS_CADASTRAIS sLV_VW_GERE_DADOS_CADASTRAIS = db.SLV_VW_GERE_DADOS_CADASTRAIS.Find(id);
            if (sLV_VW_GERE_DADOS_CADASTRAIS == null)
            {
                return HttpNotFound();
            }
            return View(sLV_VW_GERE_DADOS_CADASTRAIS);
        }

        // GET: DetalhesGerenciamentoView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalhesGerenciamentoView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NR_CARGA,CD_CPF_CNPJ,SG_TP_PESSOA,NM_PESSOA,NM_GRUPO_ECONOMICO,NM_LOGRADOURO,NR_LOGRADOURO,NM_COMPLEMENTO,NM_BAIRRO,NM_CIDADE,SG_UF,CD_CEP,NM_PAIS,NR_DDD,NR_TELEFONE,NR_DDD_CELULAR,NR_CELULAR,NM_EMAIL,DT_NASCIMENTO_OU_FUNDACAO,NM_CONTATO,NR_RG,NM_EMISSOR_RG,DS_NATURALIDADE,DS_NACIONALIDADE,NM_PAI,NM_MAE,NM_CONJUGE,CD_ESTADO_CIVIL,DS_ESTADO_CIVIL,CD_REGIME_CIVIL,DT_CADASTRO,DT_ATUALIZACAO")] SLV_VW_GERE_DADOS_CADASTRAIS sLV_VW_GERE_DADOS_CADASTRAIS)
        {
            if (ModelState.IsValid)
            {
                db.SLV_VW_GERE_DADOS_CADASTRAIS.Add(sLV_VW_GERE_DADOS_CADASTRAIS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sLV_VW_GERE_DADOS_CADASTRAIS);
        }

        // GET: DetalhesGerenciamentoView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLV_VW_GERE_DADOS_CADASTRAIS sLV_VW_GERE_DADOS_CADASTRAIS = db.SLV_VW_GERE_DADOS_CADASTRAIS.Find(id);
            if (sLV_VW_GERE_DADOS_CADASTRAIS == null)
            {
                return HttpNotFound();
            }
            return View(sLV_VW_GERE_DADOS_CADASTRAIS);
        }

        // POST: DetalhesGerenciamentoView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NR_CARGA,CD_CPF_CNPJ,SG_TP_PESSOA,NM_PESSOA,NM_GRUPO_ECONOMICO,NM_LOGRADOURO,NR_LOGRADOURO,NM_COMPLEMENTO,NM_BAIRRO,NM_CIDADE,SG_UF,CD_CEP,NM_PAIS,NR_DDD,NR_TELEFONE,NR_DDD_CELULAR,NR_CELULAR,NM_EMAIL,DT_NASCIMENTO_OU_FUNDACAO,NM_CONTATO,NR_RG,NM_EMISSOR_RG,DS_NATURALIDADE,DS_NACIONALIDADE,NM_PAI,NM_MAE,NM_CONJUGE,CD_ESTADO_CIVIL,DS_ESTADO_CIVIL,CD_REGIME_CIVIL,DT_CADASTRO,DT_ATUALIZACAO")] SLV_VW_GERE_DADOS_CADASTRAIS sLV_VW_GERE_DADOS_CADASTRAIS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sLV_VW_GERE_DADOS_CADASTRAIS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sLV_VW_GERE_DADOS_CADASTRAIS);
        }

        // GET: DetalhesGerenciamentoView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLV_VW_GERE_DADOS_CADASTRAIS sLV_VW_GERE_DADOS_CADASTRAIS = db.SLV_VW_GERE_DADOS_CADASTRAIS.Find(id);
            if (sLV_VW_GERE_DADOS_CADASTRAIS == null)
            {
                return HttpNotFound();
            }
            return View(sLV_VW_GERE_DADOS_CADASTRAIS);
        }

        // POST: DetalhesGerenciamentoView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SLV_VW_GERE_DADOS_CADASTRAIS sLV_VW_GERE_DADOS_CADASTRAIS = db.SLV_VW_GERE_DADOS_CADASTRAIS.Find(id);
            db.SLV_VW_GERE_DADOS_CADASTRAIS.Remove(sLV_VW_GERE_DADOS_CADASTRAIS);
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
