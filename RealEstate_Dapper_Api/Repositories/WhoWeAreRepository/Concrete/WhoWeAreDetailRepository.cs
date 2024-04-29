using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository.Abstract;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository.Concrete
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "INSERT INTO WhoWeAreDetail (Title, Subtitle, Description1, Description2) values (@title, @subtitle, @description1, @description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetailDto.Title);
            parameters.Add("@subtitle", createWhoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", createWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", createWhoWeAreDetailDto.Description2);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "DELETE FROM WhoWeAreDetail WHERE WhoWeAreDetailId = @WhoWeAreDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@WhoWeAreDetailId", id);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "SELECT * FROM WhoWeAreDetail";
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = "SELECT * FROM WhoWeAreDetail WHERE WhoWeAreDetailId = @WhoWeAreDetailId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@WhoWeAreDetailId", id);
            using (var connections = _context.CreateConnection())
            {
                var value = await connections.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto> (query, paramaters);
                return value;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "UPDATE WhoWeAreDetail SET Title = @title, Subtitle = @subtitle, Description1 = @description1, Description2 = @description2 WHERE WhoWeAreDetailId = @whoWeAreDetailId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@title", updateWhoWeAreDetailDto.Title);
            paramaters.Add("@subtitle", updateWhoWeAreDetailDto.Subtitle);
            paramaters.Add("@description1", updateWhoWeAreDetailDto.Description1);
            paramaters.Add("@description2", updateWhoWeAreDetailDto.Description2);
            paramaters.Add("@whoWeAreDetailId", updateWhoWeAreDetailDto.WhoWeAreDetailId);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, paramaters);
            }
        }
    }
}
