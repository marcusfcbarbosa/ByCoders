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

        /// <summary>
        /// Imagina que após a inserção vc deseja que um processo secundário fique processando os arquivos
        /// Dai só coloquei ele aqui pra ele ficar setando alguma coisa a criterio de exibição
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var titulos = scope.ServiceProvider.GetRequiredService<ITituloRepository>();
                    await titulos.ProcessTituls();
                }
            }
        }
    }
}
