namespace Try.Redis472.Autofac.DependencyResolution
{
    using global::Autofac;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Caching.StackExchangeRedis;
    using Services;

    public static class AutofacInstaller
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<TestService>().As<ITestService>();
            
            builder.RegisterType<RedisCache>().As<IDistributedCache>().SingleInstance();
            builder.RegisterOptions();
            builder.Configure<RedisCacheOptions>(options =>
            {
                options.Configuration = "xxxxx.redis.cache.windows.net:6379,password=******,ssl=False,abortConnect=False";
            });
        }
    }
}