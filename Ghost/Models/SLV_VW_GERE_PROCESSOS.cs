namespace Ghost.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SLV_VW_GERE_PROCESSOS
    {
        [StringLength(14)]
        public string CD_CPF_CNPJ { get; set; }

        [StringLength(1)]
        public string SG_TP_PESSOA { get; set; }

        [Key]
        public int? CD_SOLVERE_OPER { get; set; }

        [StringLength(70)]
        public string NM_PESSOA { get; set; }

        [StringLength(10)]
        public string CD_CAUSA { get; set; }

        [StringLength(30)]
        public string NR_PROCESSO { get; set; }

        [StringLength(50)]
        public string NR_CONTRATO { get; set; }

        [StringLength(600)]
        public string NM_ESCRITORIO_COBRANCA { get; set; }

        [StringLength(5)]
        public string IC_STATUS_PROCESSUAL { get; set; }

        [StringLength(2)]
        public string IC_STATUS_OPERACIONAL { get; set; }

        [StringLength(50)]
        public string NM_PRODUTO { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DT_CONTRATO { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DT_VENC_DESDE { get; set; }

        [StringLength(50)]
        public string NM_GRUPO_ECONOMICO { get; set; }

        [StringLength(8)]
        public string CD_CARTEIRA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VL_SALDO_CONTABIL_DEVEDOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VL_SALDO_GERENCIAL { get; set; }
    }
}
