using System.Threading.Tasks;
using Company.Api.Logic.Core;
using Company.DataProviders.Core;
using Geolocation;
using Microsoft.AspNetCore.Http;

namespace Company.Api.Logic.Services
{
    public class MeasureService : IMeasureService
    {
        private readonly AirportDataProviderDecorator _provider;

        public MeasureService(AirportDataProviderDecorator provider)
        {
            _provider = provider;
        }

        public async Task<double> CalculateDistance(string from, string to)
        {
            if (from.Equals(to))
            {
                return 0;
            }

            var airports = await Task.WhenAll(_provider.GetAirportAsync(from), _provider.GetAirportAsync(to));

            if (airports == null || airports.Length < 2 || airports[0] == null || airports[1] == null)
            {
                throw new BadHttpRequestException("");
            }

            var distance = GeoCalculator
                .GetDistance(new Coordinate
                    {
                        Latitude = airports[0].Location.Lat,
                        Longitude = airports[0].Location.Lon,
                    },
                    new Coordinate
                    {
                        Latitude = airports[1].Location.Lat,
                        Longitude = airports[1].Location.Lon,
                    });

            return distance;
        }
    }
}
