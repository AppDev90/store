using Store.Core.Common.Entity;
using Store.Core.ProductBrands.Entity;
using Store.Core.ProductTypes.Entity;

namespace Store.Core.Products.Entity
{
    public class Product : BaseEntity
    {
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public ProductType ProductType { get; set; }
        public ProductBrand ProductBrand { get; set; }
    }
}
