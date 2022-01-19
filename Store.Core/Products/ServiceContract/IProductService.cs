using Store.Core.Common.Dto;
using Store.Core.Products.Dto;
using Store.Core.Products.Dto.Query;
using Store.Core.Products.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.Products.ServiceContract
{
    public interface IProductService
    {
        Product Get(int id);
        Task<ProductsWithDetail> GetWithDetail(int id);
        Task<Pagination<ProductsWithDetail>> GetPdoducts(FilterDto filterDto);
        void Add(Product product);
    }
}
