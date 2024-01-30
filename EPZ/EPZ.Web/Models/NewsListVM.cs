namespace EPZ.Web.Models
{
    public class NewsListVM
    {
        public IEnumerable<NaverNews> NewsList { get; set; }
        public NewsQuery NewsQueryInfo { get; set; }
    }
}
