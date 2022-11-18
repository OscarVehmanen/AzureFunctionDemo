using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



namespace ChuckNorrisJokes
{
    class JokeHelper
    {
        public static async Task<String> GetJokeAsync()
        {
            var joke = "No joke for you!!";

            using (var httpClient = new HttpClient())
            {
                //Testing webhook!
                var apiEndPoint = "https://api.chucknorris.io/jokes/random";
                httpClient.BaseAddress = new Uri(apiEndPoint);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseMessage = await httpClient.GetAsync(apiEndPoint);

                if(responseMessage.IsSuccessStatusCode)
                {
                    var jsonContent = await responseMessage.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(jsonContent);
                    joke = data.value;
                }
                return joke;
             }
        }
    }
}