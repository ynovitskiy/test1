using System.Threading.Tasks;
using Company.Api.Helpers;
using Company.Api.Logic.Core;
using Microsoft.Extensions.Caching.Memory;

namespace Company.Api.Logic.Services
{
    public class CachedMeasureServiceDecorator : MeasureServiceDecorator
    {
        private readonly IMemoryCache _memoryCache;

        public CachedMeasureServiceDecorator(IMeasureService measureService, IMemoryCache memoryCache)
            :base(measureService)

        {
            _memoryCache = memoryCache;
        }

        public override async Task<double> CalculateDistance(string @from, string to)
        {
            var key = CacheHelper.GetKey(from, to);
            if (_memoryCache.TryGetValue(key, out var distanceFromCache))
            {
                return (double) distanceFromCache;
            }

            var distance = await MeasureService.CalculateDistance(from, to);

            _memoryCache.Set(key, distance);

            return distance;
        }
    }
}