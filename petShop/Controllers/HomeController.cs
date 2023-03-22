using System.Diagnostics;
using petShop.Filters;
using petShop.Helpers;
namespace petShop.Controllers;


// Filtro para não acessar a rota home se não hover usuário logado
[PaginaParaUsuarioLogado]
public class HomeController : Controller
{
    private readonly IProductRepository prod_Repository;
    private readonly ISessao _sessao;
    public HomeController ( ISessao sessao, IProductRepository productRepository){
            _sessao = sessao; 
            prod_Repository = productRepository;
    }

    public IActionResult Index()
    {
        List<ProductModel> produtos = prod_Repository.listarProdutos();
        return View(produtos);
    }


    public IActionResult Pets(){
        return RedirectToAction("Index","Pets");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
