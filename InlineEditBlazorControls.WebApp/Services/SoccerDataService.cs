using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace InlineEditBlazorControls.WebApp.Services
{
    public class SoccerDataService
    {
        private readonly HttpClient client = new HttpClient();

        public SoccerDataService()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "InlineEditBlazorControls");

            var baseUrl = "https://api.openligadb.de";
            client.BaseAddress = new System.Uri(baseUrl.EndsWith("/") ? baseUrl : string.Concat(baseUrl, "/"));
        }

        public async Task<List<Match>> GetMatches()
        {
            string leagueShortcut = "bl1";
            int season = 2020;

            string path = string.Concat("getmatchdata/", leagueShortcut, "/", season,"/",1);

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var stringresult = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<List<Match>>(stringresult);
                return res;
            }

            return null;
        }
    }

    public record Match
    {
        public int MatchId { get; set; }

        public DateTime? MatchDateTime { get; set; }

        public string LeagueName { get; set; }

        public Team Team1 { get; set; }

        public Team Team2 { get; set; }

        public Group Group { get; set; }
    }

    public class Group
    {
        public string GroupName { get; set; }
        public int GroupOrderID { get; set; }
        public int GroupID { get; set; }
    }
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ShortName { get; set; }

        public string TeamIconUrl { get; set; }
        public string TeamGroupName { get; set; }
    }
}
