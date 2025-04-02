namespace UGB.Domain.Wrapper
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IEnumerable<T> records {get; set;}
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