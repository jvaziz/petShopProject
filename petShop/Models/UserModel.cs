using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace petShop.Models{
    public class UserModel{

        [Key]
        public int idUser {get; set;}

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string nome{get; set;}
        
        [Required(ErrorMessage = "Email é obrigatório.")]
        [StringLength(450)]
        public string email {get;set;}

        [Required(ErrorMessage = "Senha é obrigatória.")]
        public string senha{get;set;}
        
    }
}