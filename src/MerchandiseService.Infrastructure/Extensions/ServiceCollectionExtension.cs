using Infrastructure.Handlers.MerchRequestAggregate;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IssueMerchRequestCommandHandler).Assembly);
            
            return services;
        }
        
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMerchRequestRepository, MerchRequestRepository>();
            return services;
        }
    }
}