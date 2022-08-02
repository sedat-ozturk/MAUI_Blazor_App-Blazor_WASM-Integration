using Dapper;
using ListForm.Domain.Interfaces;
using ListForm.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ListForm.Domain.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration configuration;
        public ProductRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<List<Product>> GetAllAsync(int skip = 0, int take = 10, string sort = "")
        {
            var sql = "SELECT * FROM Products";

            //Eğer sorting boş ise
            sort = string.IsNullOrEmpty(sort) ? "[ { \"name\": \"Id\", \"desc\" : 0 }]" : sort;

            sql = sql + " ORDER BY ";

            var lstSorts = JsonConvert.DeserializeObject<List<RepositorySortJson>>(sort);

            for (int i = 0; i < lstSorts.Count; i++)
            {
                var selector = lstSorts[i].name;
                var desc = lstSorts[i].desc ? " DESC" : "";
                var ayrac = i == 0 ? "" : ", ";

                sql = sql + ayrac + selector + desc;
            }

            sql = sql + " OFFSET " + skip.ToString() + " ROWS";
            sql = sql + " FETCH NEXT " + take.ToString() + " ROWS ONLY";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Product>(sql);
                return result.ToList();
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> AddAsync(Product entity)
        {
            entity.AddedOn = DateTime.Now;
            var sql = "Insert into Products (Name,Description,Barcode,Rate,AddedOn) VALUES (@Name,@Description,@Barcode,@Rate,@AddedOn)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Barcode = @Barcode, Rate = @Rate, ModifiedOn = @ModifiedOn  WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
