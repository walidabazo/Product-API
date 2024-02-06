namespace Product.API.MyHelper
{
    public class Pagination<T> where T : class

    {
        public Pagination(int pageSize, int pageNumber, int pageCount, IReadOnlyList<T> data)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            PageCount = pageCount;
            Data = data;
        }
        //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
