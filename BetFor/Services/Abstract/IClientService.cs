using BetFor.Entities;

namespace BetFor.Services
{
    public interface IClientService
    {
        Task<bool> TryCreateClientAsync(CreateClientRequest request);
        Task<bool> TryUpdateClientAsync(UpdateClientRequest request);
        Task<bool> TryDeleteClientAsync(DeleteClientRequest request);
        Task<GetClientResponse> GetClientAsync(GetClientRequest request);
        Task<CreateBetResponse> CreateBetAsync(CreateBetRequest request);
        Task<List<ClientTour>> GetClientTourListAsync(long tourId);
        Task<List<GetBetResultResponse>> GetBetResultListAsync(GetBetResultRequest request);
    }
}