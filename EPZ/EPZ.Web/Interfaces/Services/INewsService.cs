using EPZ.Web.Interfaces.Models;
using EPZ.Web.Models;

namespace EPZ.Web.Interfaces.Services
{
    public interface INewsService
    {
        public List<T> GetNewsList<T>(NewsQuery newsQuery) where T : INews;
    }
}
