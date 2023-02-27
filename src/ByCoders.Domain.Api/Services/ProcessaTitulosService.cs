using ByCoders.Core.Extensions;
using ByCoders.Domain.Api.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ByCoders.Domain.Api.Services
{
    public class ProcessaTitulosService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ProcessaTitulosService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var titulos = scope.ServiceProvider.GetRequiredService<ITituloRepository>();
                var titulosAProcessar = await titulos.GetAllTitulosToProcess();
                if(titulosAProcessar.Count() > 0)
                {
                    titulosAProcessar.ForEach(x => x.ProcessaTitulo());
                    await titulos.UnitOfWork.Commit();
                }
            }
        }
    }
}
