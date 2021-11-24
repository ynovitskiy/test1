using System.Threading.Tasks;
using Company.DataProviders.Models;

namespace Company.DataProviders.Core
{
    public interface IAirportDataProvider
    {
        Task<Airport> GetAirportAsync(string code);
    }
}