using InventarioNet.Models;
using InventarioNet.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository repository;

        public ProdutosController(IProdutoRepository _context)
        {
            repository = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await repository.GetAll();

            if (produtos is null)
                return BadRequest();


            return Ok(produtos.ToList());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await repository.GetById(id);

            if (produto is null)
                return NotFound("Produto não encontrado.");


            return Ok(produto);
        }

        // POST api/<controller> 
        [HttpPost]
        public async Task<IActionResult> PostProduto([FromBody] Produto produto)
        {
            if (produto is null)
                return BadRequest("Produto é nulo.");


            await repository.Insert(produto);

            return CreatedAtAction(nameof(GetProduto), new { Id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
                return BadRequest($"Código do produto [{id}] inválido.");

            try
            {
                await repository.Update(id, produto);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok("Produto alterado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> DeleteProduto(int id) 
        {
            var produto = await repository.GetById(id);

            if (produto is null)
                return NotFound($"Produto [{id}] não encontrado.");

            await repository.Delete(id);

            return Ok(produto);
        }

    }
}
