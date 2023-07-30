using BetFor.Entities;
using BetFor.Repositories;
using BetFor.Helpers.TourMapper;

namespace BetFor.Services
{
    public class TourService : ITourService
    {
        private readonly IBaseRepository<Tour> tourRepository;
        public TourService(IBaseRepository<Tour> tourRepository, IBaseRepository<Client> clientRepository)
        {
            this.tourRepository = tourRepository;
        }

        public async Task<bool> TryCreateTourAsync(Tour request)
        {
            return await tourRepository.TryInsertItemAsync(request);
        }

        public async Task<bool> TryUpdateTourAsync(Tour request)
        {
            return await tourRepository.TryUpdateItemAsync(request);
        }

        public async Task<Tour> GetLastFinishedTourAsync(Tour request)
        {
            return (await tourRepository.GetFilteredItemsAsync(x => x.TourStartTime < DateTime.Now)).OrderByDescending(x => x.TourEndTime).First();
        }

        public async Task<GetCurrentTourResponse> GetCurrentTourAsync()
        {
            var result = await tourRepository.GetItemAsync(x => x.TourStartTime <= DateTime.Now && x.TourEndTime >= DateTime.Now);

            return result.ToGetCurrentTourResponseFromTour();
        }
    }
}