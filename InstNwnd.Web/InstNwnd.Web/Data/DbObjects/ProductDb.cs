using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.ProductCrud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.DbObjects
{
    public class ProductDb : IProductDb
    {
        private readonly InstNwndContext context;

        public ProductDb(InstNwndContext context)
        {
            this.context = context;
        }

        public ProductModels GetProduct(int productId)
        {
            var product = this.context.Product.Find(productId);

            if (product == null)
            {
                throw new Exception("This product is not registered.");
            }

            return new ProductModels()
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice ?? 0, // Manejo de decimal?
                UnitsInStock = product.UnitsInStock ?? 0, // Manejo de short?
                Deleted = product.Deleted,
                DeleteDate = product.DeleteDate,
                Description = product.Description
            };
        }

        public List<ProductModels> GetProducts()
        {
            return this.context.Product.Select(p => new ProductModels()
            {
                ProductId = p.Id,
                ProductName = p.ProductName,
                QuantityPerUnit = p.QuantityPerUnit,
                UnitPrice = p.UnitPrice ?? 0, // Manejo de decimal?
                UnitsInStock = p.UnitsInStock ?? 0, // Manejo de short?
                Deleted = p.Deleted,
                DeleteDate = p.DeleteDate,
                Description = p.Description
            }).ToList();
        }

        public void RemoveProduct(ProductRemoveModels removeProduct)
        {
            var productToDelete = this.context.Product.Find(removeProduct.ProductId);

            if (productToDelete == null)
            {
                throw new Exception("This product is not registered.");
            }

            productToDelete.Deleted = removeProduct.Deleted;
            productToDelete.DeleteDate = removeProduct.DeleteDate;

            this.context.Product.Update(productToDelete);
            this.context.SaveChanges();
        }

        public void SaveProduct(ProductAddModels saveProduct)
        {
            var product = new Product()
            {
                ProductName = saveProduct.ProductName,
                QuantityPerUnit = saveProduct.QuantityPerUnit,
                UnitPrice = saveProduct.UnitPrice,
                UnitsInStock = saveProduct.UnitsInStock,
                Description = saveProduct.Description
            };

            this.context.Product.Add(product);
            this.context.SaveChanges();
        }

        public void UpdateProduct(ProductUpdateModels updateProduct)
        {
            var productToUpdate = this.context.Product.Find(updateProduct.ProductId);

            if (productToUpdate == null)
            {
                throw new Exception("This product is not registered.");
            }

            productToUpdate.ProductName = updateProduct.ProductName;
            productToUpdate.QuantityPerUnit = updateProduct.QuantityPerUnit;
            productToUpdate.UnitPrice = updateProduct.UnitPrice;
            productToUpdate.UnitsInStock = updateProduct.UnitsInStock;
            productToUpdate.Description = updateProduct.Description;
            productToUpdate.Deleted = updateProduct.Deleted;
            productToUpdate.DeleteDate = updateProduct.DeleteDate;

            this.context.Product.Update(productToUpdate);
            this.context.SaveChanges();
        }
    }
}
