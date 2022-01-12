using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Core.ProductBrands.Entity;
using Store.Core.Products.Entity;
using Store.Core.ProductTypes.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Store.Infrastructure.Data
{
    public class StoreContextInitialWork
    {

        public static void Migrate(StoreDbContext context, ILogger logger)
        {
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                LoggError(logger, "StoreContext Migration Error!" + ex.Message);
            }

        }

        public static void SeedData(StoreDbContext context, ILogger logger)
        {
            try
            {
                //Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                var path = "..\\Store.Infrastructure";

                if (ProductBrandTableIsEmpty(context))
                {
                    AddProductBarands(context, path);
                }

                if (ProductTypeTableIsEmpty(context))
                {
                    AddProductTypes(context, path);
                }

                if (ProductTableIsEmpty(context))
                {
                    AddProducts(context, path);
                }
            }
            catch (Exception ex)
            {
                LoggError(logger, "StoreContext SeedDate Error! " + ex.Message);
            }
        }

        private static void LoggError(ILogger logger, string message)
        {
            logger.LogError(message);
        }

        private static bool ProductBrandTableIsEmpty(StoreDbContext context)
        {
            return !context.ProductBrands.Any();
        }
        private static void AddProductBarands(StoreDbContext context, string path)
        {
            var brandsData =
                File.ReadAllText(path + @"\Data\SeedData\brands.json");

            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

            foreach (var item in brands)
            {
                context.ProductBrands.Add(item);
            }

            context.SaveChanges();
        }

        private static bool ProductTypeTableIsEmpty(StoreDbContext context)
        {
            return !context.ProductTypes.Any();
        }
        private static void AddProductTypes(StoreDbContext context, string path)
        {
            var typesData =
                File.ReadAllText(path + @"\Data\SeedData\types.json");

            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

            foreach (var item in types)
            {
                context.ProductTypes.Add(item);
            }

            context.SaveChanges();
        }

        private static bool ProductTableIsEmpty(StoreDbContext context)
        {
            return !context.Products.Any();
        }
        private static void AddProducts(StoreDbContext context, string path)
        {
            var productsData =
                File.ReadAllText(path + @"\Data\SeedData\products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            foreach (var item in products)
            {
                context.Products.Add(item);
            }

            context.SaveChanges();
        }


    }
}
