﻿using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository.Abstract
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        void CreateService(CreateServiceDto createServiceDto);

        void DeleteService(int id);
        void UpdateService(UpdateServiceDto updateServiceDto);

        Task<GetByIdServiceDto> GetService(int id);
    }
}
