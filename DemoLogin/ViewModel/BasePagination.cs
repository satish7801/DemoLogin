namespace DemoLogin.ViewModel
{
    public class BasePagination<T>  where T : class
    {
        public List<T> Data { get; set; }

        public int TotalCount { get; set; }
    }
}
