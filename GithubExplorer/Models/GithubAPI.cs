using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace GithubExplorer.Models
{
    public class GithubAPI
    {
        private static readonly string MainURL = @"https://api.github.com/search/repositories?q=";

        public static async Task<List<Repository>> GetRepositories(string query)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "request");
                using (HttpResponseMessage response = await client.GetAsync(MainURL + query))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string JsonResult = await response.Content.ReadAsStringAsync();
                        return Json.Decode<GithubAPIResponse>(JsonResult).items;
                    }
                    return new List<Repository>();
                }

            }

        }

    }
}