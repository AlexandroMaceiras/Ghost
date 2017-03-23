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
    public class GerenciamentoViewController : Controller
    {
        private GerenciamentoViewContexto db = new GerenciamentoViewContexto();

        private readonly GerenciamentoViewGenericRepository _gerenciamentoViewGenericRepository = new GerenciamentoViewGenericRepository();
        private readonly GerenciamentoViewDCGenericRepository _gerenciamentoViewDCGenericRepository = new GerenciamentoViewDCGenericRepository();
        private readonly GerenciamentoViewAviewsqlGenericRepository _gerenciamentoViewAviewsqlGenericRepository = new GerenciamentoViewAviewsqlGenericRepository();

        // GET: GerenciamentoView
        public ActionResult Index()
        {
            //List<string> lista = new List<string>();

            //var result = from t in db.SLV_VW_GERE_PROCESSOS
            //             select t;
            //foreach (SLV_VW_GERE_PROCESSOS t in result)
            //{

            //    //Eu estava testando a view do sql, fazendo um laço pra trazer valores ao invés de chamar direto por lambda.
            //    lista.Add(t.CD_SOLVERE_OPER.ToString());

            //}

            IEnumerable<DetalhesGerenciamentoViewModel> model = null;

            model = (from e in db.SLV_VW_GERE_PROCESSOS
                     join j in db.SLV_VW_GERE_DADOS_CADASTRAIS
                     on e.CD_CPF_CNPJ equals j.CD_CPF_CNPJ
                     select new DetalhesGerenciamentoViewModel
                     {
                         CD_CPF_CNPJ = e.CD_CPF_CNPJ,
                         SG_TP_PESSOA = e.SG_TP_PESSOA,

                         CD_SOLVERE_OPER = e.CD_SOLVERE_OPER,
                         NM_PESSOA = e.NM_PESSOA,
                         CD_CAUSA = e.CD_CAUSA,
                         NR_PROCESSO = e.NR_PROCESSO,
                         NR_CONTRATO = e.NR_CONTRATO,
                         NM_ESCRITORIO_COBRANCA = e.NM_ESCRITORIO_COBRANCA,
                         IC_STATUS_PROCESSUAL = e.IC_STATUS_PROCESSUAL,
                         IC_STATUS_OPERACIONAL = e.IC_STATUS_OPERACIONAL,
                         NM_PRODUTO = e.NM_PRODUTO,
                         DT_CONTRATO = e.DT_CONTRATO,
                         DT_VENC_DESDE = e.DT_VENC_DESDE,
                         NM_GRUPO_ECONOMICO = e.NM_GRUPO_ECONOMICO,
                         CD_CARTEIRA = e.CD_CARTEIRA,
                         VL_SALDO_CONTABIL_DEVEDOR = e.VL_SALDO_CONTABIL_DEVEDOR,
                         VL_SALDO_GERENCIAL = e.VL_SALDO_GERENCIAL,

                         NR_CARGA = j.NR_CARGA
                     }).ToList();


            return View(model);

            //return View(_gerenciamentoViewGenericRepository.PegaTudo());
        }

        [Authorize, ActionName("Index"), HttpPost]
        public ActionResult Index2( string cliente,         string cpfcnpj,         string numeroContrato, 
                                    string pessoaJuridica1, string pessoaJuridica2,  string numeroProcesso, string incluirGrupo,
                                    string grupoEconomico,  string carteira,        string codOpSolvere, 
                                    string escritorio) //,  string gestorSolvere)
        {
            var pessoaJuridica = "";
            if(pessoaJuridica1 != null && pessoaJuridica2 == null)
            {
                pessoaJuridica = "J";
            }
            else if (pessoaJuridica2 != null && pessoaJuridica1 == null)
            { 
                pessoaJuridica = "F";
            }
            else
            {
                pessoaJuridica = "";
            }

            IEnumerable<DetalhesGerenciamentoViewModel> model = null;

            if (incluirGrupo == "on")
            {
                model =
                (from d in db.SLV_VW_GERE_PROCESSOS
                 where
                       (from z in db.SLV_VW_GERE_PROCESSOS
                       where z.NM_GRUPO_ECONOMICO.Contains(grupoEconomico)
                       where z.NM_PESSOA.Contains(cliente)
                       where z.CD_CPF_CNPJ.Contains(cpfcnpj)
                       where z.NR_CONTRATO.Contains(numeroContrato)
                       where z.NR_PROCESSO.Contains(numeroProcesso)
                       where z.CD_CARTEIRA.Contains(carteira)
                       where z.CD_SOLVERE_OPER.ToString().Contains(codOpSolvere)
                       where z.NM_ESCRITORIO_COBRANCA.Contains(escritorio)
                       select new
                       { z.NM_GRUPO_ECONOMICO }).Contains(new { NM_GRUPO_ECONOMICO = d.NM_GRUPO_ECONOMICO })
                 join j in db.SLV_VW_GERE_DADOS_CADASTRAIS
                     on d.CD_CPF_CNPJ equals j.CD_CPF_CNPJ
                 select new DetalhesGerenciamentoViewModel
                 {
                     CD_CPF_CNPJ = d.CD_CPF_CNPJ,
                     SG_TP_PESSOA = d.SG_TP_PESSOA,

                     CD_SOLVERE_OPER = d.CD_SOLVERE_OPER,
                     NM_PESSOA = d.NM_PESSOA,
                     CD_CAUSA = d.CD_CAUSA,
                     NR_PROCESSO = d.NR_PROCESSO,
                     NR_CONTRATO = d.NR_CONTRATO,
                     NM_ESCRITORIO_COBRANCA = d.NM_ESCRITORIO_COBRANCA,
                     IC_STATUS_PROCESSUAL = d.IC_STATUS_PROCESSUAL,
                     IC_STATUS_OPERACIONAL = d.IC_STATUS_OPERACIONAL,
                     NM_PRODUTO = d.NM_PRODUTO,
                     DT_CONTRATO = d.DT_CONTRATO,
                     DT_VENC_DESDE = d.DT_VENC_DESDE,
                     NM_GRUPO_ECONOMICO = d.NM_GRUPO_ECONOMICO,
                     CD_CARTEIRA = d.CD_CARTEIRA,
                     VL_SALDO_CONTABIL_DEVEDOR = d.VL_SALDO_CONTABIL_DEVEDOR,
                     VL_SALDO_GERENCIAL = d.VL_SALDO_GERENCIAL,

                     NR_CARGA = j.NR_CARGA
                 }).ToList();
            }
            else
            {
                model = (from e in db.SLV_VW_GERE_PROCESSOS
                         join j in db.SLV_VW_GERE_DADOS_CADASTRAIS
                         on e.CD_CPF_CNPJ equals j.CD_CPF_CNPJ
                         select new DetalhesGerenciamentoViewModel
                         {
                             CD_CPF_CNPJ = e.CD_CPF_CNPJ,
                             SG_TP_PESSOA = e.SG_TP_PESSOA,

                             CD_SOLVERE_OPER = e.CD_SOLVERE_OPER,
                             NM_PESSOA = e.NM_PESSOA,
                             CD_CAUSA = e.CD_CAUSA,
                             NR_PROCESSO = e.NR_PROCESSO,
                             NR_CONTRATO = e.NR_CONTRATO,
                             NM_ESCRITORIO_COBRANCA = e.NM_ESCRITORIO_COBRANCA,
                             IC_STATUS_PROCESSUAL = e.IC_STATUS_PROCESSUAL,
                             IC_STATUS_OPERACIONAL = e.IC_STATUS_OPERACIONAL,
                             NM_PRODUTO = e.NM_PRODUTO,
                             DT_CONTRATO = e.DT_CONTRATO,
                             DT_VENC_DESDE = e.DT_VENC_DESDE,
                             NM_GRUPO_ECONOMICO = e.NM_GRUPO_ECONOMICO,
                             CD_CARTEIRA = e.CD_CARTEIRA,
                             VL_SALDO_CONTABIL_DEVEDOR = e.VL_SALDO_CONTABIL_DEVEDOR,
                             VL_SALDO_GERENCIAL = e.VL_SALDO_GERENCIAL,

                             NR_CARGA = j.NR_CARGA
                         }).ToList()

                .Where(x => x.NM_PESSOA.Contains(cliente))
                .Where(x => x.CD_CPF_CNPJ.Contains(cpfcnpj))
                .Where(x => x.NR_CONTRATO.Contains(numeroContrato))

                .Where(x => x.SG_TP_PESSOA.Contains(pessoaJuridica))
                .Where(x => x.NR_PROCESSO.Contains(numeroProcesso))
                //incluirGrupo é um campo só usado na decisão acima.

                .Where(x => x.NM_GRUPO_ECONOMICO.Contains(grupoEconomico))
                .Where(x => x.CD_CARTEIRA.Contains(carteira))
                .Where(x => x.CD_SOLVERE_OPER.ToString().Contains(codOpSolvere))

                .Where(x => x.NM_ESCRITORIO_COBRANCA.Contains(escritorio));
                // GESTOR SOLVERE ??????     .Where(x => x.CD_GESTOR.Contains(gestorSolvere))
            }
            ViewBag.Proxima = false;
            ViewBag.Anterior = false;

            if (cliente         != "" || cpfcnpj        != "" || numeroContrato != "" ||
                pessoaJuridica  != "" || numeroProcesso != "" || incluirGrupo   != "" ||
                grupoEconomico  != "" || carteira       != "" || codOpSolvere   != "" ||
                escritorio      != "") //gestorsolve    !="")
            {
                //if (cliente != "") ViewBag.Introducao = "Resultados de Busca";
                //else ViewBag.Introducao = "Todas as Listas Existentes";

                //if (listas.Count() < 1)
                //    ViewBag.Erro = cliente;

                return View("Index", model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Aviewsql(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLV_VW_GERE_DADOS_CADASTRAIS sLV_VW_GERE_DADOS_CADASTRAIS = _gerenciamentoViewAviewsqlGenericRepository.Procura(id);
            if (sLV_VW_GERE_DADOS_CADASTRAIS == null)
            {
                return HttpNotFound();
            }
            return View(sLV_VW_GERE_DADOS_CADASTRAIS);
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
