namespace Questao2
{
    public class DataPagination<T> where T : class
    {
        public int Page { get; set; }

        public int Per_Page { get; set; }

        public int Total { get; set; }

        public int Total_Pages { get; set; }

        public T? Data { get; set; }
    }
}