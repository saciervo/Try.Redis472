namespace Try.Redis472.Autofac.Console
{
    using global::Autofac;
    using System;
    using DependencyResolution;
    using Services;

    internal class Program
    {
        public static void Main(string[] args)
        {
            // Setup DI
            var builder = new ContainerBuilder();
            AutofacInstaller.Configure(builder);
            var container = builder.Build();
            var service = container.Resolve<ITestService>();

            // Act
            var result = service.Get();
            if (string.IsNullOrWhiteSpace(result))
            {
                service.Set("Hello World");
                result = service.Get();
            }
            
            Console.WriteLine(result);
        }
    }
}