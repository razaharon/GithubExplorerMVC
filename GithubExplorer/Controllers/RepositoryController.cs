using GithubExplorer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GithubExplorer.Controllers
{
    public class RepositoryController : Controller
    {

        public async Task<ActionResult> Index(string query)
        {
            List<Repository> result = await GithubAPI.GetRepositories(query);
            Dictionary<int, Repository> resultDictionary = new Dictionary<int, Repository>(result.Count);
            result.ForEach(r => resultDictionary.Add(r.id, r));
            return View(resultDictionary);
        }

        public ActionResult Favorites(string jsonItem, string type)
        {
            Repository item = null;
            Dictionary<int, Repository> repositoryList = (Dictionary<int, Repository>)Session["favorites"];
            if (repositoryList == null)
            {
                repositoryList = new Dictionary<int, Repository>();
                Session["favorites"] = repositoryList;
            }
            if (jsonItem != null)
            {
                item = System.Web.Helpers.Json.Decode<Repository>(jsonItem);
            }
            if (type == "add")
            {
                AddToFavorites(item, repositoryList);
            }
            if (type == "remove")
            {
                RemoveFromFavorites(item, repositoryList);
            }
            return View("Favorites", repositoryList);
        }

        private void RemoveFromFavorites(Repository item, Dictionary<int, Repository> repositoryList)
        {
            repositoryList.Remove(item.id);
        }

        private void AddToFavorites(Repository item, Dictionary<int, Repository> repositoryList)
        {
            if (item != null && item.id != 0 && !repositoryList.ContainsKey(item.id))
            {
                repositoryList.Add(item.id, item);
            }
        }


        [ChildActionOnly]
        public ActionResult Gallery(Dictionary<int,Repository> repositoryList)
        {
            return PartialView(repositoryList);
        }

    }
}