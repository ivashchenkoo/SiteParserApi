using Microsoft.Extensions.Hosting;
using SiteParserApi.Data.Repositories.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SiteParserApi.Services
{
    public class ParseSitesHostedService : IHostedService
    {
        private readonly IPostRepository _postRepository;

        public ParseSitesHostedService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(1));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Console.WriteLine("SiteParsing");

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
