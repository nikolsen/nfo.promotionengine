using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using PromotionEngine.Core.Interfaces;
using PromotionEngineDemo;

namespace PromotionEngine.Tests
{
    public class PromotionEngineFixture : IDisposable
    {
        private readonly TestServer _testServer;
        public IPromotionService PromotionService => _testServer.Services.GetService(typeof(IPromotionService)) as IPromotionService;
        public IPriceRepository ProductRepository => _testServer.Services.GetService(typeof(IPriceRepository)) as IPriceRepository;

        public PromotionEngineFixture()
        {
            var builder = new WebHostBuilder();
            builder.UseStartup<Startup>();
            builder.UseKestrel();
            _testServer = new TestServer(builder);

            _testServer.Host.Start();
        }

        public void Dispose()
        {
            // TODO: Cleanup
        }
    }
}
