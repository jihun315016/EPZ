using EPZ.Web.Models;

namespace EPZ.Web.ViewModels
{
    public class NewsListVM<T>
    {
        public IEnumerable<T> NewsList { get; set; }
        public NewsQuery NewsQueryInfo { get; set; }
    }
}
