using System.Threading.Tasks;

namespace Company.Api.Logic.Core
{
    public interface IMeasureService
    {
        /// <summary>
        /// Calculate distance between two airports
        /// </summary>
        /// <returns></returns>
        /// <param name="from">Point on map</param>
        /// <param name="to">Point on map</param>
        public Task<double> CalculateDistance(string from, string to);
    }
}
