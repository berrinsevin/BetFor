using BetFor.Entities;

namespace BetFor.Services
{
    public class NumberService : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public NumberService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                long tourTimeSpan;
                long tourCooldown;

                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var configurationService = scope.ServiceProvider.GetRequiredService<IConfigurationService>();
                    var clientService = scope.ServiceProvider.GetRequiredService<IClientService>();
                    var tourService = scope.ServiceProvider.GetRequiredService<ITourService>();

                    var tourMinNumber = await configurationService.GetConfigurationValueAsync(new GetConfigurationValueRequest { KeyWord = "TourMinNumber" });
                    var tourMaxNumber = await configurationService.GetConfigurationValueAsync(new GetConfigurationValueRequest { KeyWord = "TourMaxNumber" });
                    tourTimeSpan = await configurationService.GetConfigurationValueAsync(new GetConfigurationValueRequest { KeyWord = "TourTimeSpan" });
                    tourCooldown = await configurationService.GetConfigurationValueAsync(new GetConfigurationValueRequest { KeyWord = "TourCooldown" });

                    var tour = new Tour
                    {
                        IsWinner = false,
                        StartNumber = tourMinNumber,
                        EndNumber = tourMaxNumber,
                        TourNumber = 0,
                        TourStartTime = DateTime.Now,
                        TourEndTime = DateTime.Now.AddMinutes(tourTimeSpan)
                    };

                    await tourService.TryCreateTourAsync(tour);

                    await Task.Delay(TimeSpan.FromMinutes(tourTimeSpan + tourCooldown), stoppingToken);

                    var tourNumber = new Random().Next((int)tourMinNumber, (int)tourMaxNumber);
                    var lastFinishedTour = await tourService.GetLastFinishedTourAsync(tour);
                    var clientTourList = await clientService.GetClientTourListAsync(lastFinishedTour.Id);

                    tour.TourNumber = tourNumber;
                    if (clientTourList != null)
                    {
                        tour.IsWinner = clientTourList.Any(x => x.BetNumber == tourNumber);
                    }
                    else
                    {
                        Console.WriteLine("Error: clientTourList is null.");
                    }

                    await tourService.TryUpdateTourAsync(tour);
                }
            }
        }
    }
}