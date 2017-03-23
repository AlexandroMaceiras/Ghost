using System;
using Ghost.Models;
using System.Collections.Generic;

namespace Ghost.Repositorios
{
    public interface IListaRepositorio : IDisposable
    {
        IEnumerable<Lista> Listas();
        IEnumerable<Lista> ListasFiltro(string cliente, string cpfcnpj, string pessoaJuridica, string numeroContrato, string numeroProcesso, string incluirGrupo, string codOpSolvere, string grupoEconomico, string carteira, string escritorio1, string escritorio2);
        Lista Details(int? id);
        void Create(Lista entidade);
        void Edit(Lista entidade);
        void Delete(Lista entidade);
    }
}