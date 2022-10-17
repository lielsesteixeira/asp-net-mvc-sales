using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp.Models
{
  public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        
        [Required(ErrorMessage ="Este campo é obrigatório")]
        [MaxLength(100)]
        [DisplayName("Produto")]
        public string DscProduto { get; set; }
        
        [Required(ErrorMessage="Deve ser contábil")]
        [DisplayName("Valor unitário")]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public float VlrUnitario { get; set; }
    }
}