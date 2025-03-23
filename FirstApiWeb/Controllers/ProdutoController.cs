using FirstApiWeb.Data;
using FirstApiWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<ProdutoModel>> BuscarProdutos()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }
        [HttpGet]
        
        [Route("{id}")]
        public ActionResult<ProdutoModel> BuscarProdutosPorId(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
                return NotFound("Registro não localizado!");

            return Ok(produto);
        }
        
    }
}
