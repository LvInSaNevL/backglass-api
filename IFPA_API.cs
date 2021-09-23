using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace USER_API
{
    public class IFPA
    {
        static readonly string BaseURL = "https://api.ifpapinball.com/v1/";
        static readonly string API_Key = "143311bee48d9b6238c7c994011454e4";

        public static async Task<UserIFPAStats> GetUser(string first_name, string last_name)
        {
            // Format the name
            string userTarget = $"{first_name.Substring(0, 1)}%20{last_name}";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Anything");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Uri target = new Uri($"{BaseURL}player/search?api_key={API_Key}&q={userTarget}");

            HttpResponseMessage response = await client.GetAsync(target);
            string strResponse = await response.Content.ReadAsStringAsync();
            JObject parsed = JObject.Parse(strResponse);


            return new UserIFPAStats
            {
                PlayerID = parsed["search"][0]["player_id"].ToString(),
                City = parsed["search"][0]["city"].ToString(),
                State = parsed["search"][0]["state"].ToString(),
                Country = parsed["search"][0]["country_code"].ToString(),
                Rank = parsed["search"][0]["wppr_rank"].ToString()
            };
        }
    }
}