using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ghost.Repositorios;
using Ghost.Models;
using System.Data.Entity;

namespace Ghost.Models
{
    public class ListaRepositorio : IListaRepositorio
    {
        //Assim é tendo um construtor.
        private ListaContexto _db;

        //Assim é sem precisar de um contrutor.
        //private TarefaContexto _db = new TarefaContexto();

        private bool disposed = false;

        public ListaRepositorio(ListaContexto db)
        {
            _db = db;
        }

        public void Create(Lista entidade)
        {
            if (entidade != null)
            {
                _db.Listas.Add(entidade);
                _db.SaveChanges();
            }
        }

        public void Delete(Lista entidade)
        {
            if (entidade != null)
            {
                var id = Details(entidade.ListaId);
                if (id != null)
                {
                    _db.Listas.Remove(id);
                    _db.SaveChanges();
                }
            }
        }

        public Lista Details(int? id)
        {
            var lista = _db.Listas.Find(id);
            return lista;
        }


        public void Edit(Lista entidade)
        {
            if (entidade != null)
            {
                _db.Entry(entidade).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public IEnumerable<Lista> Listas()
        {
            var listas = _db.Listas.AsParallel().ToList();
            return listas;
        }


        public IEnumerable<Lista> ListasFiltro(string cliente, string cpfcnpj, string pessoaJuridica, string numeroContrato, string numeroProcesso, string incluirGrupo, string codOpSolvere, string grupoEconomico, string carteira, string escritorio1, string escritorio2)
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

            var listas = _db.Listas.Where(x => x.Nome.Contains(cliente)).Where(x => x.Cpf.Contains(cpfcnpj)).Where(x => x.Rg.Contains(numeroContrato)).Where(x => x.Ativo == numero).ToList();
            return listas;
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
        ~ListaRepositorio()
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