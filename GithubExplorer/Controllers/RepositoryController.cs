using GithubExplorer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GithubExplorer.Controllers
{
    public class RepositoryController : Controller
    {
        // GET: Repository
        public async Task<ActionResult> Index(string query)
        {
            List<Repository> result = await GithubAPI.GetRepositories(query);
            return View(result);
        }

        public ActionResult Favorites()
        {
            return View();
        }

        public async Task<ActionResult> Gallery(string query)
        {
            List<Repository> result = await GithubAPI.GetRepositories(query);
            return View(result);
        }
    }
}