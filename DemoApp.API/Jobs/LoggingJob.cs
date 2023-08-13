using Quartz;
using System.Reflection.Metadata.Ecma335;

namespace DemoApp.API.Jobs
{
    public class LoggingJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Logging DateTime: {DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}
