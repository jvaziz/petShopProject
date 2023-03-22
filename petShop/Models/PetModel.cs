using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace petShop.Models{
    public class PetModel{
        [Key]
        public int idPet {get; set;}
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string nome{get; set;}
        [Required(ErrorMessage = "Tipo é obrigatório.")]
        public string tipo {get;set;}
        [Column("raça")]
        [Required(ErrorMessage = "Raça é obrigatória.")]
        public string raca{get;set;}
        [Required(ErrorMessage = "Peso é obrigatório.")]
        public float peso{get;set;}
        [Column(TypeName = "DateTime")]
        [Required(ErrorMessage = "Idade é obrigatório.")]
        public DateTime idade{get;set;}
        [Required(ErrorMessage = "Porte é obrigatório.")]
        public string porte{get;set;}
        [Required(ErrorMessage = "Sexo é obrigatório.")]
        public string sexo{get;set;}
        [Required(ErrorMessage = "Tipo sanguineo é obrigatório.")]
        public string tipoSangue{get;set;}
        [Column("descrição")]
        public string? descricao{get;set;}
        
    }
}