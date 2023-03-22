namespace petShop.Helpers
{
    public interface ISessao
    {
         void criarSessaoDoUsuario(UserModel usuario);
         void removerSessaoDoUsuario();
         UserModel buscarSessaoDoUsuario();
    }
}