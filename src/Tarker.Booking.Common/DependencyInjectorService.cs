using Microsoft.Extensions.DependencyInjection;

namespace Tarker.Booking.Common
{
    public static class DependencyInjectorService
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            return services;
        }
    }
}
