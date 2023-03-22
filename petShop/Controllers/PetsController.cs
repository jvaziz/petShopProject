using petShop.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using petShop.Repository;
using petShop.Models;


namespace petShop.Controllers{    
[PaginaParaUsuarioLogado]
    public class PetsController : Controller{
        private readonly IPetRepository pet_repository;
        public PetsController(IPetRepository petRepository){
            pet_repository = petRepository;
        }

        public IActionResult Index(){
            List<PetModel> pets = pet_repository.listarPets();
            return View(pets);
        }
        public IActionResult Criar(){
            return View();
        }
        [HttpPost]
        public IActionResult Criar(PetModel pet){
            pet_repository.adicionar(pet);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id){
            PetModel pet = pet_repository.buscarId(id);
            return View(pet);
        }
        [HttpPost]
        public IActionResult Atualizar(PetModel pet){
            pet_repository.atualizar(pet);
            return RedirectToAction("Index");
        }
        public IActionResult VerDeletar(int id){
            var pet = pet_repository.buscarId(id);
            return View(pet);
        }
        public IActionResult Deletar(int id){
            pet_repository.deletar(id);
            return RedirectToAction("Index");
        }


    }
}