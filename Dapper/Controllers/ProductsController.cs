using Dapper;
using DapperTask.Models;
using DapperTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IProductsServices _studentServices;

        public ProductsController(IConfiguration config, IProductsServices studentServices)
        {
            _config = config;
            _studentServices = studentServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetAllProducts()
        {
          var products = await _studentServices.GetProducts();
            return Ok(products);
        }
    }
}
