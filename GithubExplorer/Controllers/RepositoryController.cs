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

        public async Task<ActionResult> Index(string query)
        {
            List<Repository> result = await GithubAPI.GetRepositories(query);
            return View(result);
        }

        public ActionResult Favorites(string jsonItem)
        {
            Repository item = null;
            if (jsonItem != null)
            {
                item = System.Web.Helpers.Json.Decode<Repository>(jsonItem);
            }
            List<Repository> repositoryList = (List<Repository>)Session["favorites"];
            if (repositoryList == null)
            {
                repositoryList = new List<Repository>();
                Session["favorites"] = repositoryList;
            }
            if (item != null && item.name != null)
            {
                repositoryList.Add(item);
            }
            return View("Favorites",repositoryList);
        }

        [ChildActionOnly]
        public ActionResult Gallery(List<Repository> repositoryList)
        {
            return PartialView(repositoryList);
        }
    }
}