using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) =>
            Create(product);



        public void DeleteOneProduct(Product product) =>
            Delete(product);



        public async Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters,bool trackChanges)
        {
            var products = await FindAll(trackChanges)
          .OrderBy(x => x.Id)
          .ToListAsync();

            return PagedList<Product>
                .ToPagedList(products, productParameters.PageNumber,
                productParameters.PageSize);
        }

        public async Task<PagedList<Product>> GetFilteredPricesProductsAsync(ProductFilterParameters productParameters, bool trackChanges)
        {
            var products = await FindByCondition( b =>
            ((b.Price >= productParameters.MinPrice) &&
            (b.Price <= productParameters.MaxPrice)),trackChanges)
                .OrderBy(x => x.Id)
                
              .ToListAsync();
              return PagedList<Product>
                .ToPagedList(products, productParameters.PageNumber,
                productParameters.PageSize);
        }

        public async Task<IEnumerable<Product>> GetFilteredProductsAsync(ProductFilterParameters filterParams, bool trackChanges)
        {
            var productsQuery = _context.Products.AsQueryable();

            // Fiyat aralığı filtresi
            if (filterParams.MinPrice > 0 || filterParams.MaxPrice < 10000)
            {
                productsQuery = productsQuery.Where(p => p.Price >= filterParams.MinPrice && p.Price <= filterParams.MaxPrice);
            }

            // Kategori filtresi
            if (filterParams.CategoryId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.CategoryId == filterParams.CategoryId.Value);
            }

            // Şehir filtresi
            if (!string.IsNullOrEmpty(filterParams.City))
            {
                filterParams.City = filterParams.City.ToLower();
                filterParams.City = char.ToUpper(filterParams.City[0]) + filterParams.City.Substring(1);
                productsQuery = productsQuery.Where(p => p.ProductLocation.Contains(filterParams.City));
            }

            // Zaman sıralama filtresi
            if (filterParams.SortByDate)
            {
                productsQuery = filterParams.SortByDateAscending
                    ? productsQuery.OrderBy(p => p.ProductTime)
                    : productsQuery.OrderByDescending(p => p.ProductTime);
            }

            // Fiyat sıralama filtresi
            if (filterParams.SortByPrice)
            {
                productsQuery = filterParams.SortByPriceAscending
                    ? productsQuery.OrderBy(p => p.Price)
                    : productsQuery.OrderByDescending(p => p.Price);
            }

            //return await productsQuery
            //    .Include(x => x.ProductCategory)
            //    .ToListAsync();
            return PagedList<Product>
                .ToPagedList(productsQuery, filterParams.PageNumber, filterParams.PageSize);
        }

        public async Task<Product> GetOneProductByIdAsync(int id, bool trackChanges) =>
              await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

    
        public void UpdateOneProduct(Product product)  =>
            Update(product);


    }
}
