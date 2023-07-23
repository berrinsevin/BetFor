using BetFor.Dtos;
using BetFor.Entities;

namespace BetFor.Services
{
    public interface ITourService
    {
        CurrentTourDto GetTour();
        bool TryBetForCurrentTour(TourRequest request, out string message);
        TourDto TryGetTourByDate(DateTime date);
        void TryDeleteTour(long id);
    }
}