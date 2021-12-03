using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace HospitalIntegrationTests
{
    public class InjectionFixture : IDisposable
    {
        // Test server represent hospital api
        private readonly TestServer server;
        // Client send http request to controller
        // Preko klijenta saljemo http zahteve na kontrolere
        public HttpClient Client { get; }

        public InjectionFixture()
        {   
            // Running the test of server, startup class is in use of this project and the class gets all services, dbContext...  
            // Prilikom pokretanja test servera koristi se startup klasa iz ovog projekta i tu su registrovani svi servisi, dbContext itd
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }

        // From ServiceProvider we can get all services which are in startuo class (controller, repository, service, mapper)
        // Pokrecemo sve sto se nalazi u servisu startup od testu
        public IServiceProvider ServiceProvider => server.Host.Services;

        // Dispose objects after testing 
        // Anuliranje objekata nakon zavrsetka testiranja
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
