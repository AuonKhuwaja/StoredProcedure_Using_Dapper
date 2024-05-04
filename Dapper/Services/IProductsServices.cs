using DapperTask.Models;

namespace DapperTask.Services
{
    public interface IProductsServices
    {
        Task<List<Products>> GetProducts();

    }
}
