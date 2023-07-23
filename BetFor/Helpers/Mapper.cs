using BetFor.Dtos;
using BetFor.Entities;

namespace BetFor.Helpers
{
    public static class BetForMapper
    {
        public static CurrentTourDto CurrentTourMapper(this CurrentTour currentTour)
        {
            return new CurrentTourDto
            {
                FirstNumber = currentTour.FirstNumber,
                SecondNumber = currentTour.SecondNumber,
                TourTime = currentTour.TourTime
            };
        }

        //berrins TourMapper'a gerek var mı zaten Id'si BetForBase den geliyor, [JsonIgnore]
        public static TourDto TourMapper(this Tour tour)
        {
            return new TourDto
            {
                IsWinner = true,
                TourTime = tour.TourTime,
                WinnerId = tour.WinnerId
            };
        }

    }
}