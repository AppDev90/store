
namespace Store.Core.Products.Dto
{
    public class FilterDto
    {
        private const int MaxPageSize = 50;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize ? MaxPageSize : value);
        }
        public int PageIndex { get; set; } = 1;
        public string Sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        public string ProductName { get; set; }


    }
}
