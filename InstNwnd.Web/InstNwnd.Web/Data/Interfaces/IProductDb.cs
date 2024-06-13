using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Models.ProductCrud;
using System.Collections.Generic;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface IProductDb
    {
        List<Product> GetProducts();
        Product GetProduct(int productId);
        void SaveProduct(ProductAddModels productAdd);
        void UpdateProduct(ProductUpdateModels productUpdate);
        void RemoveProduct(ProductRemoveModels productRemove);
    }
}
