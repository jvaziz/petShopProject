using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petShop.Repository
{
    public interface IPetRepository
    {
        PetModel adicionar(PetModel pet);
        List<PetModel> listarPets();
        PetModel buscarId(int Id);
        PetModel atualizar(PetModel pet);
        bool deletar(int id);
    }
}