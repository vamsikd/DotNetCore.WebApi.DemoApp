using DemoApp.API.Jobs;
using Quartz;

namespace DemoApp.API
{
    public static class QuartzSchedulerConfig
    {
        public static void AddQuartzScheduler(this IServiceCollection services)
        {
            services.AddQuartz(opts =>
            {
                opts.UseMicrosoftDependencyInjectionJobFactory();
                var jobkey = JobKey.Create(nameof(LoggingJob));
                opts
                    .AddJob<LoggingJob>(jobkey)
                    .AddTrigger(trigger =>
                        trigger
                            .ForJob(jobkey)
                            .WithSimpleSchedule(schedule =>
                                schedule.WithIntervalInSeconds(10).RepeatForever()));
            });
            services.AddQuartzHostedService();
        }
    }
}
