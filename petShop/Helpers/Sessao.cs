using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace petShop.Helpers
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _HttpContext;
        private readonly string sessionName = "usuarioLogado";

        public Sessao(IHttpContextAccessor httpContextAccessor){
            _HttpContext = httpContextAccessor;
        }

        public void criarSessaoDoUsuario(UserModel usuario){
            string userJson = JsonConvert.SerializeObject(usuario);  
            _HttpContext.HttpContext.Session.SetString(sessionName, userJson);
         }
        public void removerSessaoDoUsuario(){
            _HttpContext.HttpContext.Session.Remove(sessionName);
         }
        public UserModel buscarSessaoDoUsuario(){
            string userJson = _HttpContext.HttpContext.Session.GetString(sessionName);
            if(string.IsNullOrEmpty(userJson)) return null;
            return JsonConvert.DeserializeObject<UserModel>(userJson);
         }
    }
}