﻿using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();

    }
}