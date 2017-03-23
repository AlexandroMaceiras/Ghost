using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ghost.Repositorios;
using Ghost.Models;
using System.Data.Entity;

namespace Ghost.Repositorios
{
    public class GerenciamentoRepositorio : IGerenciamentoRepositorio
    {
        //Assim é tendo um construtor.
        private GerenciamentoContexto _db;

        //Assim é sem precisar de um contrutor.
        //private TarefaContexto _db = new TarefaContexto();

        private bool disposed = false;

        public GerenciamentoRepositorio(GerenciamentoContexto db)
        {
            _db = db;
        }

        public void Create(SLV_TB_STG_AQUI_DADO_CADASTRAL entidade)
        {
            if (entidade != null)
            {
                _db.SLV_TB_STG_AQUI_DADO_CADASTRAL.Add(entidade);
                _db.SaveChanges();
            }
        }

        public void Delete(SLV_TB_STG_AQUI_DADO_CADASTRAL entidade)
        {
            if (entidade != null)
            {
                var id = Details(entidade.NR_CARGA);
                if (id != null)
                {
                    _db.SLV_TB_STG_AQUI_DADO_CADASTRAL.Remove(id);
                    _db.SaveChanges();
                }
            }
        }

        public SLV_TB_STG_AQUI_DADO_CADASTRAL Details(int? id)
        {
            var Gerenciamento = _db.SLV_TB_STG_AQUI_DADO_CADASTRAL.Find(id);
            return Gerenciamento;
        }


        public void Edit(SLV_TB_STG_AQUI_DADO_CADASTRAL entidade)
        {
            if (entidade != null)
            {
                _db.Entry(entidade).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public IEnumerable<SLV_TB_STG_AQUI_DADO_CADASTRAL> Gerenciamento()
        {
            var Gerenciamento = _db.SLV_TB_STG_AQUI_DADO_CADASTRAL.AsParallel().ToList();
            return Gerenciamento;
        }


        public IEnumerable<SLV_TB_STG_AQUI_DADO_CADASTRAL> GerenciamentoFiltro(string cliente, string cpfcnpj, string pessoaJuridica, string numeroContrato, string numeroProcesso, string incluirGrupo, string codOpSolvere, string grupoEconomico, string carteira, string escritorio1)
        {
            int numero = 0;
            if (pessoaJuridica == "1")
            {
                numero = 1;
            }
            else
            {
                numero = 0;
            }

            var Gerenciamento = _db.SLV_TB_STG_AQUI_DADO_CADASTRAL.Where(x => x.NM_PESSOA.Contains(cliente)).Where(x => x.DT_CADASTRO.Contains(cpfcnpj)).ToList(); //.Where(x => x.Rg.Contains(numeroContrato)).Where(x => x.Ativo == numero).ToList();
            return Gerenciamento;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (_db != null)
                    {
                        _db.Dispose();
                        _db = null;
                    }
                }
            }
            disposed = true;
        }

        /// <summary>
        /// Destrutor. O destrutor é chamado quando a CLR verifica que não existem mais referências para o objeto, e então vai chamá-lo.
        /// </summary>
        ~GerenciamentoRepositorio()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}