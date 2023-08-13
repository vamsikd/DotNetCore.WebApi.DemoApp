using DemoApp.API.Jobs;
using Quartz;

namespace DemoApp.API
{
    public static class QuartzSchedulerConfig
    {
        public static void AddScheduledJobs(this IServiceCollection services, int intervalInMinutes = 1)
        {
            services.AddQuartz(opts =>
            {
                opts.UseMicrosoftDependencyInjectionJobFactory();
                var jobkey = JobKey.Create(nameof(ArchiveProductsJob));
                opts
                    .AddJob<ArchiveProductsJob>(jobkey)
                    .AddTrigger(trigger =>
                        trigger
                            .ForJob(jobkey)
                            .WithSimpleSchedule(schedule =>
                                schedule.WithIntervalInMinutes(intervalInMinutes).RepeatForever()));
            });
            services.AddQuartzHostedService();
        }
    }
}
