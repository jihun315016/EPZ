using EPZ.Web.Models;

namespace EPZ.Web.ViewModels
{
    public class NewsListVM
    {
        public IEnumerable<NaverNews> NewsList { get; set; }
        public NewsQuery NewsQueryInfo { get; set; }
    }
}
