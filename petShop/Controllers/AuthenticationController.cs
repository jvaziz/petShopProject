using  System.Data;
using  System.Linq;
using  System.Threading.Tasks;
using petShop.Helpers;
namespace petShop.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserRepository user_repository;
    
        private readonly ISessao _sessao;
     
        public AuthenticationController (IUserRepository userRepository, ISessao sessao){
            user_repository = userRepository;
            _sessao = sessao; 
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(UserModel user){
            user_repository.adicionar(user);
            
            return RedirectToAction("Logar");
        }

        public IActionResult Logar(){
            if(_sessao.buscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Deslogar(){
            _sessao.removerSessaoDoUsuario();
            return RedirectToAction("Logar", "Authentication");
        }

        [HttpPost]
        public IActionResult Logar(UserModel user)
        {
            var userLogin = user_repository.buscarEmailSenha(user);

            if(userLogin != null){
                _sessao.criarSessaoDoUsuario(userLogin);
                return RedirectToAction("Index", "Home"); 
            }else {
                TempData["LoginError"] = "Login inválido! Verifique as suas credenciais!";
                return RedirectToAction("Logar");
            }
        }
    }

}