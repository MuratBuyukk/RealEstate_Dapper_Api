using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.CategoryRepository.Abstract;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string querry = "Insert Into Category(CategoryName, CategoryStatus) values (@categoryName, @categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(querry, parameters);
            }

        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string querry = "Select * From Category";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(querry);
                return values.ToList();
            }
        }
    }
}
