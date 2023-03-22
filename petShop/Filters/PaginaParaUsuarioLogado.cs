using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace petShop.Filters
{
    public class PaginaParaUsuarioLogado : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("usuarioLogado");
            if(string.IsNullOrEmpty(sessaoUsuario)) 
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary{{"controller", "Authentication"}, {"action", "Logar"}});
            }else {
                UserModel usuario = JsonConvert.DeserializeObject<UserModel>(sessaoUsuario);
                if(usuario  == null) {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary{{"controller", "Authentication"}, {"action", "Logar"}});
                } 
            }
            base.OnActionExecuting(context);
        }
    }
}