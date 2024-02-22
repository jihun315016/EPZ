using EPZ.Web.Interfaces.Models;
using EPZ.Web.Interfaces.Services;
using EPZ.Web.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using EPZ.Web.ViewModels;

namespace EPZ.Web.Services
{
    public class NaverNewsService : INewsService 
    {
        public NewsListVM<T> GetNewsList<T>(NewsListVM<T> newsListVM) where T : INews
        {
            string query = $"{newsListVM.NewsQueryInfo.NewsCategory.Replace('_', ' ')}&display={newsListVM.NewsQueryInfo.PageSize}&start={newsListVM.NewsQueryInfo.Start}&sort=sim";
            string url = $"https://openapi.naver.com/v1/search/news.json?query={query}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "클라이언트아이디"); // 클라이언트아이디
            request.Headers.Add("X-Naver-Client-Secret", "클라이언트아이디");       // 클라이언트시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();

            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();

                JObject parsedJson = JObject.Parse(text);
                JArray items = (JArray)parsedJson["items"];

                List<T> newsList = JsonConvert.DeserializeObject<List<T>>(items.ToString());

                foreach (var item in newsList) 
                {
                    item.Title = GetRegexString(item.Title);
                }
                newsListVM.NewsList = newsList;

                return newsListVM;
            }
            else
            {
                return default(NewsListVM<T>);
            }
        }

        private static string GetRegexString(string str)
        {
            string result;
            string[] specialCharacters;

            specialCharacters = new string[] { "&nbsp;", "&lt;", "&gt;", "&amp;", "&quot;", "&#035;", "&#039;" };

            result = Regex.Replace(str, "<.*?>", String.Empty); // 태그 제거

            foreach (string specialCharacter in specialCharacters)
            {
                result = result.Replace(specialCharacter, string.Empty);
            }

            return result;
        }
    }
}
