using InstNwnd.Web.Data.Context;
using InstNwnd.Web.Data.Entities;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.ProductCrud;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstNwnd.Web.Data.DbObjects
{
    public class ProductsDb : IProductDb
    {
        private readonly InstNwndContext context;
        private readonly ILogger<ProductsDb> logger;

        public ProductsDb(InstNwndContext context, ILogger<ProductsDb> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        private Products ValidateProducExists(int ProducID)
        {
            var products = context.Products.Find(ProducID);
            return products;
        }

        public List<ProductGetModels> GetProducts()
        {
            return this.context.Products.Select(p => new ProductGetModels
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice ?? 0, // Manejo de valor nullable
                SupplierID = p.SupplierID ?? 0, // Manejo de valor nullable
                CategoryID = p.CategoryID ?? 0, // Manejo de valor nullable
                Discontinued = p.Discontinued
            }).ToList();
        }

        public ProductGetModels GetProducts(int productId)
        {
            var product = this.context.Products.Find(productId);

            if (product == null)
            {
                throw new Exception("This product is not registered.");
            }

            return new ProductGetModels
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice ?? 0, // Manejo de valor nullable
                SupplierID = product.SupplierID ?? 0, // Manejo de valor nullable
                CategoryID = product.CategoryID ?? 0, // Manejo de valor nullable
                Discontinued = product.Discontinued
            };
        }

        public void RemoveProduct(ProductRemoveModels Removeproduct)
        {
  
            var products = ValidateProducExists(Removeproduct.ProductID);

            this.context.Products.Remove(products);
            this.context.SaveChanges();
        }

        public void SaveProduct(ProductAddModels saveProduct)
        {
            var product = new Products
            {
                ProductName = saveProduct.ProductName,
                UnitPrice = saveProduct.UnitPrice,
                QuantityPerUnit = saveProduct.QuantityPerUnit, // Debe ser string
                UnitsInStock = saveProduct.UnitsInStock, // Debe ser short
                UnitsOnOrder = saveProduct.UnitsOnOrder, // Debe ser short
                ReorderLevel = saveProduct.ReorderLevel, // Debe ser short
                SupplierID = saveProduct.SupplierID,
                CategoryID = saveProduct.CategoryID,
                Discontinued = saveProduct.Discontinued,
 
            };

            this.context.Products.Add(product);
            this.context.SaveChanges();
            logger.LogInformation("Producto guardado correctamente: {ProductID}", product.ProductID);
        }

        public void UpdateProduct(ProductUpdateModels updateProduct)
        {
            var productToUpdate = this.context.Products.Find(updateProduct.ProductID);

            if (productToUpdate is null)
            {
                throw new Exception("This product is not registered.");
            }

            productToUpdate.ProductName = updateProduct.ProductName;
            productToUpdate.UnitPrice = updateProduct.UnitPrice;
            productToUpdate.QuantityPerUnit = updateProduct.QuantityPerUnit; // Debe ser string
            productToUpdate.UnitsInStock = updateProduct.UnitsInStock; // Debe ser short
            productToUpdate.SupplierID = updateProduct.SupplierID;
            productToUpdate.CategoryID = updateProduct.CategoryID;
            productToUpdate.UnitsOnOrder = updateProduct.UnitsOnOrder;
            productToUpdate.ReorderLevel = updateProduct.ReorderLevel;
            productToUpdate.Discontinued = updateProduct.Discontinued;

            this.context.Products.Update(productToUpdate);
            this.context.SaveChanges();
            logger.LogInformation("Producto guardado correctamente: {ProductID}", productToUpdate.ProductID);
        }
    }
}
