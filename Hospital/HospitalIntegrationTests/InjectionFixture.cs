using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HospitalIntegrationTests
{
    public class InjectionFixture : IDisposable
    {
        private readonly TestServer server;
        public HttpClient Client { get; }

        public InjectionFixture()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
            //Client.BaseAddress = new Uri("http://localhost:53255");
        }

        public IServiceProvider ServiceProvider => server.Host.Services;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                server.Dispose();
                Client.Dispose();
            }
        }
    }
}
