namespace EPZ.Web.Models
{
    public class NaverNews
    {
        // 뉴스 기사의 제목. 제목에서 검색어와 일치하는 부분은 <b> 태그로 감싸져 있습니다.
        public string Title { get; set; }

        // 뉴스 기사 원문의 URL
        public string OriginalLink { get; set; }

        // 뉴스 기사의 네이버 뉴스 URL. 네이버에 제공되지 않은 기사라면 기사 원문의 URL을 반환합니다
        public string Link { get; set; }

        // 뉴스 기사의 내용을 요약한 패시지 정보. 패시지 정보에서 검색어와 일치하는 부분은 <b> 태그로 감싸져 있습니다.
        public string Description { get; set; }

        // 뉴스 기사가 네이버에 제공된 시간. 네이버에 제공되지 않은 기사라면 기사 원문이 제공된 시간을 반환합니다.
        public string PubDate { get; set; }
    }
}
