using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace petShop.ViewComponents
{
    public class Home : ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync(){
            string sessaoUsuario = HttpContext.Session.GetString("usuarioLogado");
            if(string.IsNullOrEmpty(sessaoUsuario)) return null;
            UserModel usuario = JsonConvert.DeserializeObject<UserModel>(sessaoUsuario);
            Console.WriteLine(usuario.nome);

            return View(usuario);
        }
    }
}