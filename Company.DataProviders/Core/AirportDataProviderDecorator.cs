using System.Threading.Tasks;
using Company.DataProviders.Models;

namespace Company.DataProviders.Core
{
    public abstract class AirportDataProviderDecorator : IAirportDataProvider
    {
        protected IAirportDataProvider DataProvider;

        protected AirportDataProviderDecorator(IAirportDataProvider airportDataProvider)
        {
            DataProvider = airportDataProvider;
        }

        public abstract Task<Airport> GetAirportAsync(string code);
    }
}