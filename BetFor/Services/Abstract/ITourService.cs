using BetFor.Entities;

namespace BetFor.Services
{
    public interface ITourService
    {
        Task<bool> TryCreateTourAsync(Tour item);
        Task<bool> TryUpdateTourAsync(Tour item);
        Task<Tour> GetLastFinishedTourAsync(Tour request);
        Task<GetCurrentTourResponse> GetCurrentTourAsync();
    }
}