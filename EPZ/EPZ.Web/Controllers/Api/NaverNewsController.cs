using EPZ.Web.Interfaces.Models;
using EPZ.Web.Interfaces.Services;
using EPZ.Web.Models;
using EPZ.Web.Services;
using EPZ.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EPZ.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaverNewsController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<NewsListVM<NaverNews>>> GetData([FromBody] NewsListVM<NaverNews> newsListVM)
        {
            // 테스트용 샘플 JSON
            //{
            //    "NewsList": [],
            //    "NewsQueryInfo": {
            //    "NewsCategory": "경제",
            //    "PageSize": 10,
            //    "Start": 1
            //    }
            //}

            NaverNewsService ns = new NaverNewsService();
            NewsListVM<NaverNews> list = ns.GetNewsList<NaverNews>(newsListVM);
            return Ok(list);
        }
    }
}
