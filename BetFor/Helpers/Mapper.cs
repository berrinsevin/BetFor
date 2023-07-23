using BetFor.Dtos;
using BetFor.Entities;

namespace BetFor.Helpers
{
    public static class BetForMapper
    {
        public static CurrentTourDto ToCurrentTourDto(this Tour tour)
        {
            return new CurrentTourDto
            {
                StartNumber = tour.StartNumber,
                EndNumber = tour.EndNumber
            };
        }
    }
}