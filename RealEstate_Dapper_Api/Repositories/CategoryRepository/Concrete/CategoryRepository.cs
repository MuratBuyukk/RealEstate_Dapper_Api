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

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string querry = "Select * From Category";
            using(var connection= _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(querry);
                return values.ToList();
            }
        }
    }
}
