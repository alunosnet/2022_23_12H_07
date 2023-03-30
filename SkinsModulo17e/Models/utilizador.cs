using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkinsModulo17e.Models
{
    public class utilizador
    {

        [Key]
        public int utilizadorId { get; set; }

        [Required(ErrorMessage = "Tem de indicar o nome do cliente")]
        [StringLength(80)]
        [MinLength(3, ErrorMessage = "Nome muito pequeno. Tem de ter pelo menos 3 letras")]
        [UIHint("Insira o nome do cliente, deve ter pelo menos 3 letras")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Tem de indicar um email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Tem de indicar o nick do cliente")]
        [StringLength(80)]
        [MinLength(2, ErrorMessage = "Nick muito pequeno. Tem de ter pelo menos 2 letras")]
        [UIHint("Insira o nome do cliente, deve ter pelo menos 2 letras")]
        public string nick { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Indique o perfil do utilizador")]
        public int Perfil { get; set; }
        
        //dropdown perfil
        public IEnumerable<System.Web.Mvc.SelectListItem> Perfis { get; set; }

        //lista das compras
        public virtual List<compra> listaCompras { get; set; }
    }
}