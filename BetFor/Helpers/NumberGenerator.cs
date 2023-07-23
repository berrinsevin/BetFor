namespace BetFor.Helpers
{
    public class NumberGenerator
    {
        private static Random random = new Random();

        public async Task<int> StartGeneratingNumbersAsync(int rangeStart, int rangeEnd)
        {
            bool isRunning = true;

            while (isRunning)
            {
                CancellationTokenSource cancellationToken = new CancellationTokenSource();
                Task<int> numberGeneratorTask = GenerateNumberAndSleepAsync(cancellationToken.Token, rangeStart, rangeEnd);

                await Task.Delay(120000);

                if (!numberGeneratorTask.IsCompleted)
                {
                    cancellationToken.Cancel();
                }

                await Task.Delay(30000);

                return numberGeneratorTask.Result;
            }

            return 0;
        }

        private async Task<int> GenerateNumberAndSleepAsync(CancellationToken cancellationToken, int rangeStart, int rangeEnd)
        {
            try
            {
                int randomNumber = random.Next(rangeStart, rangeEnd);

                await Task.Delay(120000, cancellationToken);

                return randomNumber;
            }
            catch (TaskCanceledException)
            {
                throw new Exception();
            }
        }
    }

}