using EPZ.Web.Models;
using EPZ.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace EPZ.Web.Controllers
{
    [Route("[controller]")]
    public class NaverNewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // https://localhost:7259/NaverNews/Get
        [HttpPost]
        [Route("Get")]
        public async Task<IActionResult> GetAsync(NewsListVM<NaverNews> newsListVM)
        {
            string jsonString;
            NewsListVM<NaverNews> list = new NewsListVM<NaverNews>();

            if (newsListVM?.NewsQueryInfo == null) 
            {
                newsListVM = new NewsListVM<NaverNews>()
                {
                    NewsList = new List<NaverNews>(),
                    NewsQueryInfo = new NewsQuery()
                    {
                        NewsCategory = NaverNewsCategory.언론사별.ToString(),
                        PageSize = 10,
                        Start = 1
                    }
                };
            }

            string url = "https://localhost:7259/api/NaverNews";
            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync<NewsListVM<NaverNews>>(url, newsListVM);

            if (response.IsSuccessStatusCode) 
            {
                jsonString = await response.Content.ReadAsStringAsync();
                list = Newtonsoft.Json.JsonConvert.DeserializeObject<NewsListVM<NaverNews>>(jsonString);
                return View("Index", list);
            }
            else
            {
                return View("Index", null);
            }
        }

        [HttpPost]
        [Route("Hello")]
        public IActionResult Hello(NewsListVM<NaverNews> newsListVM)
        {
            return View();
        }
    }
}
