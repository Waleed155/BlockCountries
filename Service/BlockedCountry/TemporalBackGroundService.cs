using BlockCountries.Repository.BlockCountryRepository;

namespace BlockCountries.Service.BlockedCountry
{
    public class TemporalBackGroundService:BackgroundService
    {
        IBlockCountryRepository _blockCountryRepository;
        private readonly ILogger<TemporalBackGroundService> _logger;
        private readonly TimeSpan _period = TimeSpan.FromMinutes(5);
        public TemporalBackGroundService(
            IBlockCountryRepository blockCountryRepository,
            ILogger<TemporalBackGroundService> logger)
        {
            _logger = logger;
            _blockCountryRepository = blockCountryRepository;

        }
  

       

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new(_period);

            while (!stoppingToken.IsCancellationRequested &&
                   await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    await DoWorkAsync();
                    _logger.LogInformation("Executed periodic task");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error executing periodic task");
                }
            }
        }

        private async Task DoWorkAsync()
        {
            CheckExpiration();
            Console.WriteLine($"Task executed at {DateTime.Now}");
            await Task.CompletedTask;
        }
        public void CheckExpiration()
        {
            var temporalBlockList = _blockCountryRepository.GetAllTemporal();

            foreach (var item in temporalBlockList)
            {
                if (_blockCountryRepository.Check(item))
                {
                    _blockCountryRepository.Remove(item);
                    _blockCountryRepository.RemoveTemporal(item);


                }
            }
        }

    }


}
