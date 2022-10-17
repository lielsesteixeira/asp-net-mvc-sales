using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using csharp.Context;

namespace csharp.Models
{
    public class Venda
    {
        [Key]
        public int IdVenda { get; set; }
        
        [ForeignKey("Cliente")]
        [DisplayName("Cliente")]
        [Required(ErrorMessage ="Campo obrigatório")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente{ get; set; }
        
        [ForeignKey("Produto")]
        [Required(ErrorMessage ="Campo obrigatório")]
        [DisplayName("Produto")]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }
        
        [Required]
        [DisplayName("Quantidade")]
        public int QtdVenda { get; set; }

        [Required]
        [DisplayName("Preço unitário")]
          [DataType(DataType.Currency)]
        public float VlrUnitarioVenda { get; set; }
        
        
        [DisplayName("Data")]
        public DateTime DthVenda { get; set; } = DateTime.Now;
        
        [DisplayName("Total")]
        [DataType(DataType.Currency)]
        public float VlrTotalVenda { get; set; } 
  
        public float VlrTotal(){
            VlrTotalVenda = VlrUnitarioVenda * QtdVenda;
            return VlrTotalVenda; 
        }
    }
}