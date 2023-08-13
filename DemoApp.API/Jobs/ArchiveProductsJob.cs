using DemoApp.API.Services.Interfaces;
using Quartz;

namespace DemoApp.API.Jobs
{
    public class ArchiveProductsJob : IJob
    {
        private readonly IProductService _productSvc;
        private ILogger<ArchiveProductsJob> _logger { get; }

        public ArchiveProductsJob(IProductService productSvc, ILogger<ArchiveProductsJob> logger)
        {   _productSvc = productSvc;
            _logger = logger;
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation($"Job Scheduled: {DateTime.Now}");
            var inActiveProducts = _productSvc.ArchiveInActiveProducts();
            _logger.LogInformation($"Archived Product Count : {inActiveProducts}");
            return Task.CompletedTask;
        }
    }
}
