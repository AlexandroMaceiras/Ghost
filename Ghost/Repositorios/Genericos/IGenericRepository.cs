using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ghost.Repositorios.Genericos
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> PegaTudo();
        T Procura(params object[] key);
        void Criar(T entidade);
        void Atualizar(T entidade);
        void Deletar(Func<T, bool> predicate);
        void SalvarMudanca();
    }
}