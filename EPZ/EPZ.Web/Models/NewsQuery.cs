namespace EPZ.Web.Models
{
    public class NewsQuery
    {        
        public NewsCategory NewsCategory { get; set; }
        public int PageSize { get; set; }
        public int Start { get; set; } = 1;
    }

    public enum NewsCategory
    {
        정치, 경제, 사회, 생활_문화, IT_과학, 세계
    }
}
