using System;

namespace petShop.Repository{
    public class PetRepository : IPetRepository{
        private readonly PetShopContext pet_shopContext;
        public PetRepository(PetShopContext petShopContext){
            pet_shopContext = petShopContext;
        }

        public PetModel adicionar(PetModel pet){
            pet_shopContext.Add(pet);
            pet_shopContext.SaveChanges();
            return pet;
        }
        public List<PetModel> listarPets(){
            return pet_shopContext.Pets.ToList();
        }
        public PetModel buscarId(int Id)
        {
            return pet_shopContext.Pets.FirstOrDefault(x => x.idPet == Id);
        }

        public PetModel atualizar(PetModel pet){
            PetModel petDB = buscarId(pet.idPet);

            if(petDB == null) throw new Exception("Houve um erro:");

            petDB.nome = pet.nome;
            petDB.tipo = pet.tipo;
            petDB.raca = pet.raca;
            petDB.peso = pet.peso;
            petDB.idade = pet.idade;
            petDB.porte = pet.porte;
            petDB.sexo = pet.sexo;
            petDB.tipoSangue = pet.tipoSangue;
            petDB.descricao = pet.descricao;

            pet_shopContext.Pets.Update(petDB);
            pet_shopContext.SaveChanges();
            return petDB;
        }
        public bool deletar(int id){
            PetModel petDB = buscarId(id);

            if(petDB == null) throw new Exception("Houve um erro:");

            pet_shopContext.Pets.Remove(petDB);
            pet_shopContext.SaveChanges();
            return true;
        }

        
    }
}