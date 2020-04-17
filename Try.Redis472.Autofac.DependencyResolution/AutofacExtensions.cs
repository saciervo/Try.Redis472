namespace Try.Redis472
{
    using System;
    using global::Autofac;
    using Microsoft.Extensions.Options;

    public static class AutofacExtensions
    {
        // Ninject version of:
        // https://github.com/aspnet/Options/blob/rel/1.1.1/src/Microsoft.Extensions.Options/OptionsServiceCollectionExtensions.cs#L20
        public static void RegisterOptions(this ContainerBuilder builder)
        {
            // services.TryAdd(ServiceDescriptor.Singleton(typeof(IOptions<>), typeof(OptionsManager<>)));
            builder.RegisterGeneric(typeof(OptionsManager<>)).As(typeof(IOptions<>)).SingleInstance();

            // services.TryAdd(ServiceDescriptor.Scoped(typeof(IOptionsSnapshot<>), typeof(OptionsManager<>)));
            builder.RegisterGeneric(typeof(OptionsManager<>)).As(typeof(IOptionsSnapshot<>)).InstancePerRequest();

            // services.TryAdd(ServiceDescriptor.Singleton(typeof(IOptionsMonitor<>), typeof(OptionsMonitor<>)));
            builder.RegisterGeneric(typeof(OptionsMonitor<>)).As(typeof(IOptionsMonitor<>)).SingleInstance();

            // services.TryAdd(ServiceDescriptor.Transient(typeof(IOptionsFactory<>), typeof(OptionsFactory<>)));
            builder.RegisterGeneric(typeof(OptionsFactory<>)).As(typeof(IOptionsFactory<>));

            // services.TryAdd(ServiceDescriptor.Singleton(typeof(IOptionsMonitorCache<>), typeof(OptionsCache<>)));
            builder.RegisterGeneric(typeof(OptionsCache<>)).As(typeof(IOptionsMonitorCache<>)).SingleInstance();
        }

        public static void Configure<TOptions>(this ContainerBuilder builder, Action<TOptions> configureOptions)
            where TOptions : class
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            // services.AddSingleton<IConfigureOptions<TOptions>>(new ConfigureNamedOptions<TOptions>(name, configureOptions));
            var configOptions = new ConfigureNamedOptions<TOptions>(null, configureOptions);

            builder.RegisterInstance(configOptions).As<IConfigureOptions<TOptions>>().SingleInstance();
        }
    }
}