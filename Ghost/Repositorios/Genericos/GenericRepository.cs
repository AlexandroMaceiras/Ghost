using Ghost.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ghost.Repositorios.Genericos
{
    public abstract class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {

        private GerenciamentoContexto _db = new GerenciamentoContexto();

        public void Atualizar(T entidade)
        {
            _db.Entry(entidade).State = EntityState.Modified;
        }

        public void Criar(T entidade)
        {
            _db.Set<T>().Add(entidade);
            this.SalvarMudanca();
        }

        public void Deletar(Func<T, bool> predicate)
        {
            _db.Set<T>()
                .Where(predicate).ToList()
                .ForEach(x => _db.Set<T>().Remove(x));
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<T> PegaTudo()
        {
            return _db.Set<T>().ToList();
        }

        public IEnumerable<T> PegaTudoComGrupos(string nomeGrupo, string cliente, string cpfcnpj, string numeroContrato, string numeroProcesso, string carteira, string codOpSolvere, string escritorio)
        {
            var linq =
                (from d in _db.SLV_VW_GERE_PROCESSOS
                where
                      (
                      from z in _db.SLV_VW_GERE_PROCESSOS
                      where z.NM_GRUPO_ECONOMICO.Contains(nomeGrupo) || z.NM_PESSOA.Contains(cliente) || z.CD_CPF_CNPJ.Contains(cpfcnpj) || z.NR_CONTRATO.Contains(numeroContrato) || z.NR_PROCESSO.Contains(numeroProcesso) || z.CD_CARTEIRA.Contains(carteira) || z.CD_SOLVERE_OPER.ToString().Contains(codOpSolvere) || z.NM_ESCRITORIO_COBRANCA.Contains(escritorio)
                      select new
                      {
                          z.NM_GRUPO_ECONOMICO
                      }).Contains(new { NM_GRUPO_ECONOMICO = d.NM_GRUPO_ECONOMICO })
                select d).ToList();

            return (IEnumerable<T>)linq;
        }

        //public IEnumerable<T> PassaLinq(Func<T, bool> predicate, string nomeGrupo)
        //{
        //    var teste = pre;
        //        //(from d in _db.SLV_VW_GERE_PROCESSOS
        //        // where
        //        //       (
        //        //       from z in _db.SLV_VW_GERE_PROCESSOS
        //        //       where z.NM_GRUPO_ECONOMICO.Contains(nomeGrupo)
        //        //       select new
        //        //       {
        //        //           z.NM_GRUPO_ECONOMICO
        //        //       }).Contains(new { NM_GRUPO_ECONOMICO = d.NM_GRUPO_ECONOMICO })
        //        // select d).ToList();

        //    return (IEnumerable<T>) teste;
        //}

        public T Procura(params object[] key)
        {
            return _db.Set<T>().Find(key);
        }

        public void SalvarMudanca()
        {
            _db.SaveChanges();
        }
    }
}