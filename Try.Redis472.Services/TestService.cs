namespace Try.Redis472.Services
{
    using System.Text;
    using Microsoft.Extensions.Caching.Distributed;

    public interface ITestService
    {
        string Get();
        void Set(string value);
    }
    
    public class TestService : ITestService
    {
        private const string Foobar = "foobar";
        
        private readonly IDistributedCache cache;

        public TestService(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public string Get()
        {
            var result = this.cache.GetAsync(Foobar).GetAwaiter().GetResult();
            return result == null ? null : Encoding.UTF8.GetString(result);
        }

        public void Set(string value)
        {
            var result = Encoding.UTF8.GetBytes(value);
            this.cache.SetAsync(Foobar, result).GetAwaiter().GetResult();
        }
    }
}