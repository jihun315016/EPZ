using EPZ.Web.Interfaces.Models;
using EPZ.Web.Models;
using EPZ.Web.ViewModels;

namespace EPZ.Web.Interfaces.Services
{
    public interface INewsService
    {
        public NewsListVM<T> GetNewsList<T>(NewsListVM<T> newsListVM) where T : INews;
    }
}
