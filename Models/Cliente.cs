using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace csharp.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        
        [Column(TypeName="nvarchar(250)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Nome")]
        public string NnCliente { get; set; }
        
        [Column(TypeName="nvarchar(100)")]
        public string Cidade { get; set; } 
        
    }
}