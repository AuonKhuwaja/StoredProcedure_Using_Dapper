using Dapper;
using DapperTask.Models;
using System.Data;
using System.Data.SqlClient;

namespace DapperTask.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IConfiguration _config;
        public string ConnectionString { get; }
        public string ProviderName { get; }
        public IDbConnection Connection
        {
            get { return new  SqlConnection(ConnectionString); }
        }
        public ProductsServices(IConfiguration config)
        {
            _config = config;
            ConnectionString = _config.GetConnectionString("dbcs");
            ProviderName = "System.Data.SqlClient";
        }
        public async Task<List<Products>> GetProducts()
        {
            List<Products> products = new List<Products>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    products = (await Task.Run(() =>
                                dbConnection.Query<Products>("GetAllProducts", commandType: CommandType.StoredProcedure))).ToList();
                    dbConnection.Close();
                    return products;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return products;
            }
        }


    }
}
