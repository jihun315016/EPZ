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
        [Route("Post")]
        public async Task<ActionResult<List<NaverNews>>> Post([FromBody] NewsQuery query)
        {
            NaverNewsService ns = new NaverNewsService();
            List<NaverNews> list = ns.GetNewsList<NaverNews>(query);            
            return Ok(list);
        }
    }
}
