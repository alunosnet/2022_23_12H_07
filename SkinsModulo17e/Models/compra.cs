using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SkinsModulo17e.Models
{
    public class compra
    {

        [Key]
        public int compraId { get; set; }

        [Display(Name = "Data de compra")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Tem de indicar a data de compra")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime data_aquisicao { get; set; }


        [DataType(DataType.Currency)]
        public decimal preco { get; set; }

        ///////////////////////////////Chave estrangeira
        [ForeignKey("utilizador")]
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Tem de indicar o cliente")]
        public int utilizadorId { get; set; }
        public utilizador utilizador { get; set; }

        ///////////////////////////////Chave estrangeira
        [ForeignKey("skin")]
        [Display(Name = "skin")]
        [Required(ErrorMessage = "Tem de indicar uma skin")]
        public int skinId { get; set; }

        public skin skin { get; set; }

        //Valor defaul para data de aquisicao
        public compra()
        {
            data_aquisicao = DateTime.Now;
        }
    }
}

