using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Project
    {

        public static JObject GetProjects()
        {
            var client = new RestClient("https://github.com/");
            var request = new RestRequest("bcooper085?tab=stars", Method.GET);
            request.AddHeader("Accept", "application/vnd.github.v3+json");

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject result = JsonConvert.DeserializeObject<JObject>(response.Content);
            Console.WriteLine(result);
            return result;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient client, RestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
