﻿using RealEstate_Dapper_Api.Dtos.CategoryDtos;
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
            string query = "Insert Into Category(CategoryName, CategoryStatus) values (@categoryName, @categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryId = @categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryId = @categoryId";
            var paramaters = new DynamicParameters();
            paramaters.Add("CategoryId", id);

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, paramaters);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set CategoryName = @categoryName, CategoryStatus = @categoryStatus where CategoryId = @categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("categoryName", categoryDto.CategoryName);
            parameters.Add("categoryStatus", categoryDto.CategoryStatus);
            parameters.Add("categoryId", categoryDto.CategoryId);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }
    }
}
