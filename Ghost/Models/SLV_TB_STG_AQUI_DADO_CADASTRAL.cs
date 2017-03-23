namespace Ghost.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SLV_TB_STG_AQUI_DADO_CADASTRAL
    {
        [StringLength(2)]
        public string SG_TP_PESSOA { get; set; }

        [StringLength(15)]
        public string CD_CPF_CNPJ { get; set; }

        [StringLength(40)]
        [DisplayName("Cliente")]
        public string NM_PESSOA { get; set; }

        [StringLength(8)]
        public string CD_CEP { get; set; }

        [StringLength(40)]
        public string NM_LOGRADOURO { get; set; }

        [StringLength(5)]
        public string NR_LOGRADOURO { get; set; }

        [StringLength(20)]
        public string NM_COMPLEMENTO { get; set; }

        [StringLength(20)]
        public string NM_BAIRRO { get; set; }

        [StringLength(30)]
        public string NM_CIDADE { get; set; }

        [StringLength(2)]
        public string SG_UF { get; set; }

        [StringLength(15)]
        public string NM_PAIS { get; set; }

        [StringLength(4)]
        public string NR_DDD { get; set; }

        [StringLength(9)]
        public string NR_TELEFONE { get; set; }

        [StringLength(4)]
        public string NR_DDD_CELULAR { get; set; }

        [StringLength(9)]
        public string NR_CELULAR { get; set; }

        [StringLength(60)]
        public string NM_EMAIL { get; set; }

        [StringLength(30)]
        public string NM_CONTATO { get; set; }

        [StringLength(9)]
        public string CD_GRUPO_ECONOMICO { get; set; }

        [StringLength(40)]
        public string NM_GRUPO_ECONOMICO { get; set; }

        [StringLength(15)]
        public string NR_RG { get; set; }

        [StringLength(6)]
        public string NM_EMISSOR_RG { get; set; }

        [StringLength(8)]
        public string DT_NASCIMENTO { get; set; }

        [StringLength(20)]
        public string DS_NATURALIDADE { get; set; }

        [StringLength(25)]
        public string DS_NACIONALIDADE { get; set; }

        [StringLength(70)]
        public string NM_PAI { get; set; }

        [StringLength(70)]
        public string NM_MAE { get; set; }

        [StringLength(40)]
        public string NM_CONJUGE { get; set; }

        [StringLength(1)]
        public string CD_ESTADO_CIVIL { get; set; }

        [StringLength(2)]
        public string CD_REGIME_CIVIL { get; set; }

        [StringLength(10)]
        [DisplayName("Data Contrato")]
        public string DT_CADASTRO { get; set; }

        [StringLength(10)]
        public string DT_ATUALIZACAO { get; set; }

        [Key]
        public int NR_CARGA { get; set; }

        public DateTime? DT_CARGA { get; set; }

        public int? CD_LOTE_CESSAO { get; set; }
    }
}
