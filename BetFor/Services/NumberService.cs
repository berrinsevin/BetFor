using BetFor.Entities;
using BetFor.Repositories;

namespace BetFor.Services
{
    public class NumberService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public NumberService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var tourRepository = scope.ServiceProvider.GetRequiredService<IBaseRepository<Tour>>();
                    Random random = new Random();
                    var startNumber = random.Next(1, 50);
                    var endNumber = random.Next(100, 150);
                    var tourNumber = random.Next(startNumber, endNumber);

                    var tour = new Tour
                    {
                        IsWinner = false,
                        StartNumber = startNumber,
                        EndNumber = endNumber,
                        TourNumber = tourNumber,
                        TourStartTime = DateTime.Now.AddMinutes(5),
                        TourEndTime = DateTime.Now.AddMinutes(10)
                    };

                    tourRepository.Add(tour);
                }

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}