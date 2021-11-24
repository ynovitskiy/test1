using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Company.DataProviders.Core;
using Company.DataProviders.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;

namespace Company.DataProviders.Providers
{
    public class RestAirportDataProvider: IAirportDataProvider
    {
        private readonly IConfiguration _config;

        public RestAirportDataProvider(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Airport> GetAirportAsync(string code)
        {
            var host = _config.GetSection("Hosts:GetAirportDetailUrl").Value;

            var request = WebRequest.Create(host.Replace("{airport}", code));
            request.Method = "GET";

            var response = (HttpWebResponse)await request.GetResponseAsync();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"{host} has returned not OK response");
            }

            await using var stream = response.GetResponseStream();
            {
                using var stringReader = new StreamReader(stream);
                var content = await stringReader.ReadToEndAsync();
                var airport = JsonConvert.DeserializeObject<Airport>(content);
                return airport;
            }
        }
    }
}
