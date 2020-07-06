using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubExplorer.Models
{
    public class Repository
    {
        public int id;
        public string name;
        public string html_url;
        public Owner owner;

    }
}
