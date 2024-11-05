namespace WebApi.Helper
{
    public class BasePagingQueryParams
    {
        public int PageNumber { get; set; } = 1;

        private int maxPageSize = 50;
        private int pageSize = 5;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > maxPageSize ? pageSize = maxPageSize : pageSize = value;
        }
    }
}
