namespace EPZ.Web.Models
{
    public class NewsQuery
    {
        public string NewsCategory { get; set; }
        public int PageSize { get; set; }
        public int Start { get; set; } = 1;
    }

    public enum NaverNewsCategory
    {
        언론사별, 정치, 경제, 사회, 생활_문화, IT_과학, 세계, 랭킹, 신문보기, 오피니언, TV, 팩트체크, 알고리즘_안내, 정정보도_모음
    }
}
