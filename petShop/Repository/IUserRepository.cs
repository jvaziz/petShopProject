using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petShop.Repository
{
    public interface IUserRepository
    {
        UserModel adicionar(UserModel pet);
        UserModel buscarEmailSenha (UserModel user);
        UserModel buscarId(int id);
        UserModel atualizar(UserModel pet);
        bool deletar(int id);
    }
}