using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ghost.Models
{
    public class Lista
    {
        [Key]
        public int          ListaId { get; set; }
        [Required]
        public string       Nome    { get; set; }
        [Required]
        public string       Cpf     { get; set; }
        [Required]
        public string       Rg      { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime?    Data    { get; set; }
        public int          Ativo   { get; set; }
    }
}