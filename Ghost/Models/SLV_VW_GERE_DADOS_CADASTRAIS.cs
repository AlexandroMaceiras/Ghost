namespace Ghost.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SLV_VW_GERE_DADOS_CADASTRAIS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NR_CARGA { get; set; }

        [StringLength(14)]
        public string CD_CPF_CNPJ { get; set; }

        [StringLength(1)]
        public string SG_TP_PESSOA { get; set; }

        [StringLength(70)]
        public string NM_PESSOA { get; set; }

        [StringLength(40)]
        public string NM_GRUPO_ECONOMICO { get; set; }

        [StringLength(50)]
        public string NM_LOGRADOURO { get; set; }

        [StringLength(5)]
        public string NR_LOGRADOURO { get; set; }

        [StringLength(20)]
        public string NM_COMPLEMENTO { get; set; }

        [StringLength(50)]
        public string NM_BAIRRO { get; set; }

        [StringLength(50)]
        public string NM_CIDADE { get; set; }

        [StringLength(2)]
        public string SG_UF { get; set; }

        [StringLength(8)]
        public string CD_CEP { get; set; }

        [StringLength(15)]
        public string NM_PAIS { get; set; }

        public int? NR_DDD { get; set; }

        public int? NR_TELEFONE { get; set; }

        public int? NR_DDD_CELULAR { get; set; }

        public int? NR_CELULAR { get; set; }

        [StringLength(60)]
        public string NM_EMAIL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DT_NASCIMENTO_OU_FUNDACAO { get; set; }

        [StringLength(30)]
        public string NM_CONTATO { get; set; }

        [StringLength(15)]
        public string NR_RG { get; set; }

        [StringLength(6)]
        public string NM_EMISSOR_RG { get; set; }

        [StringLength(20)]
        public string DS_NATURALIDADE { get; set; }

        [StringLength(25)]
        public string DS_NACIONALIDADE { get; set; }

        [StringLength(70)]
        public string NM_PAI { get; set; }

        [StringLength(70)]
        public string NM_MAE { get; set; }

        [StringLength(70)]
        public string NM_CONJUGE { get; set; }

        [StringLength(1)]
        public string CD_ESTADO_CIVIL { get; set; }

        [StringLength(11)]
        public string DS_ESTADO_CIVIL { get; set; }

        [StringLength(2)]
        public string CD_REGIME_CIVIL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DT_CADASTRO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DT_ATUALIZACAO { get; set; }
    }
}
