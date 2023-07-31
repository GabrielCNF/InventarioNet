using InventarioNet.Models;
using InventarioNet.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace InventarioNet.Repositories
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
