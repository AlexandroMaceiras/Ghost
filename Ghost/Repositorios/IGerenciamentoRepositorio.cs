using System;
using Ghost.Models;
using System.Collections.Generic;

namespace Ghost.Repositorios
{
    public interface IGerenciamentoRepositorio : IDisposable
    {
        IEnumerable<SLV_TB_STG_AQUI_DADO_CADASTRAL> Gerenciamento();
        IEnumerable<SLV_TB_STG_AQUI_DADO_CADASTRAL> GerenciamentoFiltro(string cliente, string cpfcnpj, string pessoaJuridica, string numeroContrato, string numeroProcesso, string incluirGrupo, string codOpSolvere, string grupoEconomico, string carteira, string escritorio1);
        SLV_TB_STG_AQUI_DADO_CADASTRAL Details(int? id);
        void Create(SLV_TB_STG_AQUI_DADO_CADASTRAL entidade);
        void Edit(SLV_TB_STG_AQUI_DADO_CADASTRAL entidade);
        void Delete(SLV_TB_STG_AQUI_DADO_CADASTRAL entidade);
    }
}