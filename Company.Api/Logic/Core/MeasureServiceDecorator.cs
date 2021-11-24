using System.Threading.Tasks;
using Company.DataProviders.Models;

namespace Company.Api.Logic.Core
{
    public abstract class MeasureServiceDecorator: IMeasureService
    {
        protected IMeasureService MeasureService;

        protected MeasureServiceDecorator(IMeasureService measureService)
        {
            MeasureService = measureService;
        }

        /// <summary>
        /// Get a distance beetween two airports
        /// </summary>
        /// <param name="from">IATA code of the first airport</param>
        /// <param name="to">IATA code of the second airport</param>
        /// <returns></returns>
        public abstract Task<double> CalculateDistance(string @from, string to);

    }
}