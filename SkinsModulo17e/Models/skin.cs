using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkinsModulo17e.Models
{
    public class skin
    {
        [Key]
        public int id { get; set; }
        
        [Required(ErrorMessage = "Tem de indicar a skin que pretende comprar")]
        public string nSkin { get; set; }

        [Required(ErrorMessage = "Tem de indicar a quantidade de skins ")]
        [Range(1, 100, ErrorMessage = "A skin tem de ter quantidade")]
        [UIHint("Insira a quantidade da skin ")]
        [Display(Name = "Quantidade: ")]
        public int quantidade { get; set; }

        [Required(ErrorMessage = "Tem de indicar o custo da skin")]
        [Range(0, 3000, ErrorMessage = "Custo da skin deve estar entre 0 e 1000")]
        [UIHint("Indique o custo da skin")]
        [Display(Name = "Custo da skin")]
        public decimal preco { get; set; }
       
    }
}
