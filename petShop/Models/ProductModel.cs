using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace petShop.Models{
    public class ProductModel{
        [Key]
        public int idProduct {get;set;}
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string nomeProd{get; set;}
        [Required(ErrorMessage = "Texto alternativo é obrigatório.")]
        public string altText {get;set;}
        [Required(ErrorMessage = "Caminho é obrigatório.")]
        public string camProd{get; set;}
        
    }
}