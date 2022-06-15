using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Okta_ConsoleClient
{
    public class Program
    {
        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            var access_token = await GetToken();

            CallWeatherForecastApiAsync(access_token).GetAwaiter().GetResult();

            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
        }

        static async Task<string> GetToken()
        {
            HttpClient client = new HttpClient();
            var issuer = "https://dev-88745611.okta.com/oauth2/default/";
            var clientId = "0oa5dz2otei9Ce5or5d7";
            var clientSecret = "YIBGMXwvgAGPtWnyFsXiOWuwen5-fcnPT5Rh9bXh";
            //var base64ClientIdClientSecret = "MG9hNWR6Mm90ZWk5Q2U1b3I1ZDc6WUlCR01Yd3ZnQUdQdFdueUZzWGlPV3V3ZW41LWZjblBUNVJoOWJYaA==";

            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            nvc.Add(new KeyValuePair<string, string>("scope", "api"));

            client.BaseAddress = new Uri(issuer);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64ClientIdClientSecret);
            var authToken = Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authToken));

            var req = new HttpRequestMessage(HttpMethod.Post, "v1/token")
            {
                Content = new FormUrlEncodedContent(nvc)
            };
            var response = await client.SendAsync(req);
            var res = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine(res);

            Console.WriteLine("Parsed JSON...");
            dynamic parsedJson = JsonConvert.DeserializeObject(res);
            Console.WriteLine(parsedJson);

            Console.WriteLine("access_token...");
            var access_token = parsedJson.access_token.ToString();
            Console.WriteLine(access_token);

            return access_token;
        }
        static async Task CallWeatherForecastApiAsync(string access_token)
        {
            // Call WeatherForecast API.
            Console.WriteLine("Calling the Weather Forecast API...");
            var apiUrl = "https://localhost:7060/";

            HttpClient apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(apiUrl);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token);
            Console.WriteLine($"Calling API url {apiUrl}weatherforecast...");

            var apiResult = await apiClient.GetAsync($"{apiUrl}weatherforecast");

            var content = await apiResult.Content.ReadAsStringAsync();
            Console.WriteLine("Weather Forecast...");
            Console.WriteLine(content);

        }
    }
}