using System.Threading.Tasks;
using Company.DataProviders.Core;
using Company.DataProviders.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Company.DataProviders.Providers
{
    public class CachedDataProviderDecorator: AirportDataProviderDecorator
    {
        private readonly IMemoryCache _cache;

        public CachedDataProviderDecorator(IAirportDataProvider dataProvider, IMemoryCache memoryCache) 
            : base(dataProvider)
        {
            _cache = memoryCache;
        }

        public override async Task<Airport> GetAirportAsync(string code)
        {
            if (_cache.TryGetValue(code, out var airportFromCache))
            {
                return (Airport)airportFromCache;
            }

            var airport = await DataProvider.GetAirportAsync(code);

            _cache.Set(code, airport);

            return airport;
        }
    }
}