using BetFor.Dtos;
using BetFor.Helpers;
using BetFor.Entities;
using BetFor.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BetFor.Services
{
    public class TourService : ITourService
    {
        private readonly IBaseRepository<Tour> repository;
        private readonly NumberService numberService;
        public TourService(IBaseRepository<Tour> repository, NumberService numberService)
        {
            this.repository = repository;
            this.numberService = numberService;
        }

        public CurrentTourDto GetTour()
        {
            return numberService.GetCurrentTour().CurrentTourMapper();
        }

        public CurrentTour GetTourWithId()
        {
            return numberService.GetCurrentTour();
        }

        public TourDto TryGetTourByDate(DateTime date)
        {
            var tour = repository.Find(x => x.TourTime == date).FirstOrDefault();
            return tour.TourMapper();
        }

        public bool TryBetForCurrentTour(TourRequest request, out string message)
        {
            //berrins Client aradığımı nasıl belirtebilirim
            var user = repository.GetById(request.UserId);

            if (user != null)
            {
                var currentTour = GetTourWithId();
                if (currentTour.TourNumber == request.UserId)
                {
                    var winnedTour = new Tour
                    {
                        IsWinner = true,
                        WinnerId = request.UserId,
                        TourTime = DateTime.Now
                    };

                    repository.Add(winnedTour);

                    message = "Congratulations! You win :)";
                    return true;
                }
                else
                {
                    message = "Please try again";
                    return true;
                }
            }

            message = "User is not found!";
            return false;
        }

        public void TryDeleteTour(long id)
        {
            var tour = repository.GetById(id);
            repository.Delete(tour);
        }
    }
}