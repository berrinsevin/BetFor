using BetFor.Dtos;
using BetFor.Entities;

namespace BetFor.Services
{
    public interface ITourService
    {
        CurrentTourDto GetTourInfo();
        TourResponse TryBetForCurrentTour(TourRequest request);
        void TryDeleteTour(long id);
    }
}