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
    public class GerenciamentoController : Controller
    {
        //Chamada direta ao modelo do banco de dados através do Contexto
        private GerenciamentoViewContexto db = new GerenciamentoViewContexto();

        //Chamada ao modelo do banco de dados através de um simples gereciador que separa as ações comuns deste código aqui.
        //private IGerenciamentoRepositorio _gerenciamentoRepositorio;

        //public GerenciamentoController()
        //{
        //    _gerenciamentoRepositorio = new GerenciamentoRepositorio(new GerenciamentoContexto());
        //}

        //Chamada ao modelo do banco de dados através de um gereciador genérico (serve para todos) que separa as ações comuns deste código aqui.
        private readonly GerenciamentoGenericRepository _gerenciamentoGenericRepository = new GerenciamentoGenericRepository();

        // GET: SLV_TB_STG_AQUI_DADO_CADASTRAL
        public ActionResult Index_old()
        {
            return View(_gerenciamentoGenericRepository.PegaTudo());
        }

        public ActionResult Index()
        {
            return View(_gerenciamentoGenericRepository.PegaTudo());
        }


        public ActionResult Aviewsql(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLV_VW_GERE_DADOS_CADASTRAIS sSLV_VW_GERE_DADOS_CADASTRAIS = db.SLV_VW_GERE_DADOS_CADASTRAIS.Find(id);
            if (sSLV_VW_GERE_DADOS_CADASTRAIS == null)
            {
                return HttpNotFound();
            }
            return View(sSLV_VW_GERE_DADOS_CADASTRAIS);
        }

        [Authorize, ActionName("Index"), HttpPost]
        public ActionResult Index2(string cliente, string cpfcnpj, string pessoaJuridica, string numeroContrato, string numeroProcesso, string incluirGrupo, string codOpSolvere, string grupoEconomico, string carteira, string escritorio1, string escritorio2)
        {

            var listas = _gerenciamentoGenericRepository.PegaTudo().Where(x => x.NM_PESSOA.Contains(cliente)).Where(x=>x.DT_CADASTRO.Contains(cpfcnpj));
                //x => x. cliente, cpfcnpj, pessoaJuridica, numeroContrato, numeroProcesso, incluirGrupo, codOpSolvere, grupoEconomico, carteira, escritorio1);


            ViewBag.Proxima = false;
            ViewBag.Anterior = false;

            if (cliente != "" || cpfcnpj != "" || numeroContrato != "" || numeroProcesso != "" || codOpSolvere != "" || grupoEconomico != "" || carteira != "" || escritorio1 != "" || escritorio2 != "")
            {
                //if (cliente != "") ViewBag.Introducao = "Resultados de Busca";
                //else ViewBag.Introducao = "Todas as Listas Existentes";

                //if (listas.Count() < 1)
                //    ViewBag.Erro = cliente;

                return View("Index", listas);
            }
            return RedirectToAction("Index");
        }

        // GET: SLV_TB_STG_AQUI_DADO_CADASTRAL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLV_TB_STG_AQUI_DADO_CADASTRAL sLV_TB_STG_AQUI_DADO_CADASTRAL = _gerenciamentoGenericRepository.Procura(id);
            if (sLV_TB_STG_AQUI_DADO_CADASTRAL == null)
            {
                return HttpNotFound();
            }
            return View(sLV_TB_STG_AQUI_DADO_CADASTRAL);
        }

        // GET: SLV_TB_STG_AQUI_DADO_CADASTRAL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SLV_TB_STG_AQUI_DADO_CADASTRAL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NR_CARGA,SG_TP_PESSOA,CD_CPF_CNPJ,NM_PESSOA,CD_CEP,NM_LOGRADOURO,NR_LOGRADOURO,NM_COMPLEMENTO,NM_BAIRRO,NM_CIDADE,SG_UF,NM_PAIS,NR_DDD,NR_TELEFONE,NR_DDD_CELULAR,NR_CELULAR,NM_EMAIL,NM_CONTATO,CD_GRUPO_ECONOMICO,NM_GRUPO_ECONOMICO,NR_RG,NM_EMISSOR_RG,DT_NASCIMENTO,DS_NATURALIDADE,DS_NACIONALIDADE,NM_PAI,NM_MAE,NM_CONJUGE,CD_ESTADO_CIVIL,CD_REGIAO_CIVIL,DT_CADASTRO,DT_ATUALIZACAO,DT_CARGA,CD_LOTE_CESSAO")] SLV_TB_STG_AQUI_DADO_CADASTRAL sLV_TB_STG_AQUI_DADO_CADASTRAL)
        {
            if (ModelState.IsValid)
            {
                _gerenciamentoGenericRepository.Criar(sLV_TB_STG_AQUI_DADO_CADASTRAL);
                _gerenciamentoGenericRepository.SalvarMudanca();
                return RedirectToAction("Index");
            }

            return View(sLV_TB_STG_AQUI_DADO_CADASTRAL);
        }

        // GET: SLV_TB_STG_AQUI_DADO_CADASTRAL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLV_TB_STG_AQUI_DADO_CADASTRAL sLV_TB_STG_AQUI_DADO_CADASTRAL = _gerenciamentoGenericRepository.Procura(id);
            if (sLV_TB_STG_AQUI_DADO_CADASTRAL == null)
            {
                return HttpNotFound();
            }
            return View(sLV_TB_STG_AQUI_DADO_CADASTRAL);
        }


        //[Authorize]
        //public ActionResult EditBootstrap(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SLV_TB_STG_AQUI_DADO_CADASTRAL sLV_TB_STG_AQUI_DADO_CADASTRAL = _gerenciamentoGenericRepository.Procura(id);
        //    if (sLV_TB_STG_AQUI_DADO_CADASTRAL == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    //Preenche o combo Usuário (Email) com os emails dos usuários ativos existêntes e mantem o que já havia sido selecionado.
        //    //ViewBag.UsuarioId = new SelectList(_db.Usuarios.Where(x => x.Ativo == true), "UsuarioId", "Email", lista.UsuarioId);
        //    return View(sLV_TB_STG_AQUI_DADO_CADASTRAL);
        //}


        //// POST: SLV_TB_STG_AQUI_DADO_CADASTRAL/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditBootstrap([Bind(Include = "NR_CARGA,SG_TP_PESSOA,CD_CPF_CNPJ,NM_PESSOA,CD_CEP,NM_LOGRADOURO,NR_LOGRADOURO,NM_COMPLEMENTO,NM_BAIRRO,NM_CIDADE,SG_UF,NM_PAIS,NR_DDD,NR_TELEFONE,NR_DDD_CELULAR,NR_CELULAR,NM_EMAIL,NM_CONTATO,CD_GRUPO_ECONOMICO,NM_GRUPO_ECONOMICO,NR_RG,NM_EMISSOR_RG,DT_NASCIMENTO,DS_NATURALIDADE,DS_NACIONALIDADE,NM_PAI,NM_MAE,NM_CONJUGE,CD_ESTADO_CIVIL,CD_REGIAO_CIVIL,DT_CADASTRO,DT_ATUALIZACAO,DT_CARGA,CD_LOTE_CESSAO")] SLV_TB_STG_AQUI_DADO_CADASTRAL sLV_TB_STG_AQUI_DADO_CADASTRAL)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _gerenciamentoGenericRepository.Atualizar(sLV_TB_STG_AQUI_DADO_CADASTRAL);
        //        _gerenciamentoGenericRepository.SalvarMudanca();
        //        return RedirectToAction("Index");
        //    }
        //    return View(sLV_TB_STG_AQUI_DADO_CADASTRAL);
        //}

        // POST: SLV_TB_STG_AQUI_DADO_CADASTRAL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NR_CARGA,SG_TP_PESSOA,CD_CPF_CNPJ,NM_PESSOA,CD_CEP,NM_LOGRADOURO,NR_LOGRADOURO,NM_COMPLEMENTO,NM_BAIRRO,NM_CIDADE,SG_UF,NM_PAIS,NR_DDD,NR_TELEFONE,NR_DDD_CELULAR,NR_CELULAR,NM_EMAIL,NM_CONTATO,CD_GRUPO_ECONOMICO,NM_GRUPO_ECONOMICO,NR_RG,NM_EMISSOR_RG,DT_NASCIMENTO,DS_NATURALIDADE,DS_NACIONALIDADE,NM_PAI,NM_MAE,NM_CONJUGE,CD_ESTADO_CIVIL,CD_REGIAO_CIVIL,DT_CADASTRO,DT_ATUALIZACAO,DT_CARGA,CD_LOTE_CESSAO")] SLV_TB_STG_AQUI_DADO_CADASTRAL sLV_TB_STG_AQUI_DADO_CADASTRAL)
        {
            if (ModelState.IsValid)
            {
                _gerenciamentoGenericRepository.Atualizar(sLV_TB_STG_AQUI_DADO_CADASTRAL);
                _gerenciamentoGenericRepository.SalvarMudanca();
                return RedirectToAction("Index");
            }
            return View(sLV_TB_STG_AQUI_DADO_CADASTRAL);
        }

        // GET: SLV_TB_STG_AQUI_DADO_CADASTRAL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLV_TB_STG_AQUI_DADO_CADASTRAL sLV_TB_STG_AQUI_DADO_CADASTRAL = _gerenciamentoGenericRepository.Procura(id);
            if (sLV_TB_STG_AQUI_DADO_CADASTRAL == null)
            {
                return HttpNotFound();
            }
            return View(sLV_TB_STG_AQUI_DADO_CADASTRAL);
        }

        // POST: SLV_TB_STG_AQUI_DADO_CADASTRAL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SLV_TB_STG_AQUI_DADO_CADASTRAL sLV_TB_STG_AQUI_DADO_CADASTRAL = _gerenciamentoGenericRepository.Procura(id);
            _gerenciamentoGenericRepository.Deletar(x => x == sLV_TB_STG_AQUI_DADO_CADASTRAL);
            _gerenciamentoGenericRepository.SalvarMudanca();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _gerenciamentoGenericRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
