using Childcare.API.Integration.Test.Base;
using FluentAssertions.Common;
using Childcare.Dal.Contexts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using Childcare.Dal.Interfaces;

namespace Childcare.Api.Integration.Test.Base
{
    public class IntegrationClassFixture : IDisposable
    {
        public readonly WebApplicationFactory<Program> Host;

        public IntegrationClassFixture()
        {
            Host = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(e =>
                    {
                        e.AddDbContext<ChildcareContext>(options => options
                                .EnableSensitiveDataLogging()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString()),
                            ServiceLifetime.Singleton,
                            ServiceLifetime.Singleton);
                        e.AddTransient<IChildcareDatabase, ChildcareContext>();
                    });
                });

            DatabaseSeed.SeedDatabase(Host.Services.GetService<ChildcareContext>());
        }

        public void Dispose()
        {
            Host?.Dispose();
        }
    }
}