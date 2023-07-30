using BetFor.Entities;

namespace BetFor.Helpers.TourMapper
{
    public static class TourMapper
    {
        public static GetCurrentTourResponse ToGetCurrentTourResponseFromTour(this Tour request)
        {
            return new GetCurrentTourResponse
            {
                StartNumber = request.StartNumber,
                EndNumber = request.EndNumber,
                TourStartTime = request.TourStartTime,
                TourEndTime = request.TourEndTime
            };
        }
    }
}