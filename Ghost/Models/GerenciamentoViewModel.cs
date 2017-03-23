using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Ghost.Models
{
    public class GerenciamentoViewModel
    {
        public List<SLV_VW_GERE_PROCESSOS> TSLV_VW_GERE_PROCESSOS { get; set; }
        public List<SLV_VW_GERE_DADOS_CADASTRAIS> TSLV_VW_GERE_DADOS_CADASTRAIS { get; set; }
    }
}