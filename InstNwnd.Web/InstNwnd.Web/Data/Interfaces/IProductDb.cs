using InstNwnd.Web.Data.Models.ProductCrud;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface IProductDb
    {
        List<ProductGetModels> GetProducts();
        ProductGetModels GetProducts(int productId);
        void RemoveProduct(ProductRemoveModels Removeproduct);
        void SaveProduct(ProductAddModels saveProduct); // Asegúrate de que esta firma sea correcta
        void UpdateProduct(ProductUpdateModels updateProduct);
    }
}
