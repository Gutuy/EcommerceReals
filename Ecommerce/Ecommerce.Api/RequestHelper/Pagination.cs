namespace Ecommerce.Api.RequestHelper
{
    public class Pagination<T>(int pagesize,int pageindex,int count,IReadOnlyList<T>data)
    {
        public int PageSize { get; set; }=pagesize;
        public int PageIndex { get; set; } = pageindex;

        public int Count { get; set; }=count;

        public IReadOnlyList<T> Data {  get; set; }=data;
    }
}
