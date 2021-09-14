using AwesomePoll.Application;
using AwesomePoll.Application.Services;
using AwesomePoll.Core.Interfaces.Repositories;
using AwesomePoll.Infrastructure.Persistency;
using AwesomePoll.Infrastructure.Persistency.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomePoll.Infrastucture.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<PollContext>(opt => opt.UseInMemoryDatabase("PollDatabase"));

            return serviceCollection;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPollRepository, PollRepository>();
            serviceCollection.AddScoped<IPollVoteRepository, PollVoteRepository>();

            return serviceCollection;
        }

        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPollService, PollService>();
            serviceCollection.AddAutoMapper(typeof(ProfileMapping));

            return serviceCollection;
        }
    }
}
