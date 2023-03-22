using System;

namespace petShop.Repository{
    public class UserRepository : IUserRepository{
        private readonly PetShopContext pet_shopContext;
        public UserRepository(PetShopContext petShopContext){
            pet_shopContext = petShopContext;
        }

        public UserModel adicionar(UserModel user){
            pet_shopContext.Add(user);
            pet_shopContext.SaveChanges();
            return user;
        }
        public UserModel buscarId(int id) {
            return pet_shopContext.Users.FirstOrDefault(x => x.idUser == id);
        }
        public UserModel buscarEmailSenha(UserModel user)
        {
            return pet_shopContext.Users.FirstOrDefault(x => x.email == user.email && x.senha == user.senha);
        }

        public UserModel atualizar(UserModel user){
            UserModel userDB = buscarId(user.idUser);

            if(userDB == null) throw new Exception("Houve um erro:");

            userDB.email = user.email;
            userDB.senha = user.senha;
            userDB.nome = user.nome;
 

            pet_shopContext.Users.Update(userDB);
            pet_shopContext.SaveChanges();
            return userDB;
        }
        public bool deletar(int id){
            UserModel userDB = buscarId(id);

            //User not found
            if(userDB == null) throw new Exception("Houve um erro:");

            pet_shopContext.Users.Remove(userDB);
            pet_shopContext.SaveChanges();
            return true;
        }

        
    }
}