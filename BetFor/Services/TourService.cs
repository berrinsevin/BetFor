using BetFor.Dtos;
using BetFor.Helpers;
using BetFor.Entities;
using BetFor.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BetFor.Services
{
    public class TourService : ITourService
    {
        private readonly IBaseRepository<Tour> tourRepository;
        private readonly IBaseRepository<Client> clientRepository;
        public TourService(IBaseRepository<Tour> tourRepository, IBaseRepository<Client> clientRepository)
        {
            this.tourRepository = tourRepository;
            this.clientRepository = clientRepository;
        }

        public CurrentTourDto GetTourInfo()
        {
            var currentTour = tourRepository.Find(x => x.TourStartTime <= DateTime.Now && x.TourEndTime > DateTime.Now).FirstOrDefault();

            if (currentTour != null)
            {
                return currentTour.ToCurrentTourDto();
            }

            return null;
        }

        public TourResponse TryBetForCurrentTour(TourRequest request)
        {
            var tourResponse = new TourResponse();
            var user = clientRepository.GetById(request.UserId);

            if (user != null)
            {
                var currentTour = tourRepository.Find(x => x.TourStartTime <= DateTime.Now && x.TourEndTime > DateTime.Now).FirstOrDefault();

                var isValid = ValidateInputNumber(request.BetNumber);

                if (isValid && currentTour!.TourNumber == request.BetNumber)
                {
                    currentTour.IsWinner = true;
                    currentTour.WinnerId = request.UserId;
                    tourRepository.Update(currentTour);

                    tourResponse.HasWinner = true;
                    tourResponse.Message = "Congratulations! You win.";
                    return tourResponse;
                }
                else
                {
                    tourResponse.HasWinner = false;
                    tourResponse.Message = "Please try again.";
                    return tourResponse;
                }
            }

            tourResponse.HasWinner = false;
            tourResponse.Message = "User not found";
            return tourResponse;
        }

        private bool ValidateInputNumber(long number)
        {
            var currentTour = tourRepository.Find(x => x.TourStartTime <= DateTime.Now && x.TourEndTime > DateTime.Now).FirstOrDefault();

            return number >= currentTour!.StartNumber && number <= currentTour.EndNumber;
        }

        public void TryDeleteTour(long id)
        {
            var tour = tourRepository.GetById(id);
            tourRepository.Delete(tour);
        }
    }
}