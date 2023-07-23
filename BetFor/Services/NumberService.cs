using System;
using BetFor.Entities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

public class NumberService : BackgroundService
{
    private readonly Random random;
    private int rangeNum;
    private int startNum;
    public int tourNum;
    private readonly object lockObject = new object();

    public NumberService()
    {
        random = new Random();
        rangeNum = GetRandomNumber(10, 50);
        startNum = GetRandomNumber(1, 100);
        GenerateTour();
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            lock (lockObject)
            {
                rangeNum = GetRandomNumber(10, 50);
                startNum = GetRandomNumber(1, 100);
                GenerateTour();
            }

            //await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);
            await Task.Delay(30000, stoppingToken);
        }
    }

    private void GenerateTour()
    {
        int endNum = startNum + rangeNum;
        tourNum = GetRandomNumber(startNum, endNum);
    }

    public CurrentTour GetCurrentTour()
    {
        return new CurrentTour
        {
            TourNumber = tourNum,
            FirstNumber = startNum,
            SecondNumber = startNum + rangeNum,
            TourTime = DateTime.Now
        };
    }

    private int GetRandomNumber(int minValue, int maxValue)
    {
        return random.Next(minValue, maxValue + 1);
    }
}
