using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubExplorer.Models
{
    public class GithubAPIResponse
    {
        public int total_count;
        public List<Repository> items;
    }
}