using Microsoft.AspNetCore.Mvc;
using MonoRepo.Web.Models;
using MonoRepo.Web.Services.IServices;
using System.Diagnostics;

namespace MonoRepo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _produtoServices;

        public HomeController(ILogger<HomeController> logger,
                              IProductServices productServices)
        {
            _logger = logger;
            _produtoServices = productServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Produto()
        {
            var produtos = await _produtoServices.ObterTodosProdutos();
            return View(produtos);
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
}
