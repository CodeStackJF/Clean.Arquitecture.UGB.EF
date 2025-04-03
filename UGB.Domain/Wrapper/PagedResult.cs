namespace UGB.Domain.Wrapper
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IEnumerable<T> records {get; set;}
        public PagedResult(int _currentPage, int _pageCount, int _pageSize, int _totalRecords)
        {
            records = new List<T>();
            currentPage = _currentPage;
            pageCount = _pageCount;
            pageSize = _pageSize;
            totalRecords = _totalRecords;
        }

        public PagedResult()
        {
            records = new List<T>();
        }
    }

    public class PagedResultBase
    {
        public int currentPage { get; set; }
        public int pageCount { get; set; }
        public int pageSize { get; set; }
        public int totalRecords { get; set; }
    }
}