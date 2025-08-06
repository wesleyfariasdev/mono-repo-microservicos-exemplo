using Microsoft.AspNetCore.Mvc;
using MonoRepo.Shared.Data.ValueObjects;
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

        public async Task<IActionResult> ProdutoDetalhe(int id)
        {
            var produto = await _produtoServices.ObterProdutoPorId(id);
            return View(produto);
        }

        [HttpGet]
        public async Task<IActionResult> CriarProduto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto(ProdutoVo produtoVo)
        {
            if (ModelState.IsValid)
            {
                var produto = await _produtoServices.CriarProduto(produtoVo);
                if (produto != null)
                    return RedirectToAction(nameof(ProdutoDetalhe), new { id = produto.Id });

            }
            return View();
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
