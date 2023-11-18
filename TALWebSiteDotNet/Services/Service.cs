using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TALWebSiteDotNet.Models;

namespace TALWebSiteDotNet.Services
{
    public static class Service
    {
        private static readonly HttpClient Client = new HttpClient();
        public static void InitializeHttpClient()
        {
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["TALWebAPIUrl"]);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static List<OccupationQueryResult> GetOccupations()
        {
            var endpoint = ConfigurationManager.AppSettings["OccupationControllerEndpoint"];
            IList<OccupationQueryResult> occupations = null;
            var response = Client.GetAsync(endpoint).Result;        // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var responseStr = response.Content.ReadAsStringAsync().Result;
                occupations = JsonConvert.DeserializeObject<List<OccupationQueryResult>>(responseStr);
            }
            return (List<OccupationQueryResult>)occupations;
        }

        public static decimal? GetFactor(int occupationId)
        {
            var endpoint = ConfigurationManager.AppSettings["RatingControllerEndpoint"];
            var request = new RatingQuery() { OccupationId = occupationId };
            var content = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");

            RatingQueryResult factor = null;
            var response = Client.PostAsync(endpoint, stringContent).Result;        // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var responseStr = response.Content.ReadAsStringAsync().Result;
                factor = JsonConvert.DeserializeObject<RatingQueryResult>(responseStr);
            }
            return factor?.Factor;
        }
    }
}