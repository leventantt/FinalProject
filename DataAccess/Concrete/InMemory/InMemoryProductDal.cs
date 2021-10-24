using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal

    {   List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>() {
            new Product() { ProductId=1,CategoryId=1,ProductName="Bardar" ,UnitPrice=15,UnitsInStoct=15},
            new Product() { ProductId=2,CategoryId=1,ProductName="Kamera" ,UnitPrice=500,UnitsInStoct=3},
            new Product() { ProductId=3,CategoryId=2,ProductName="Telefon" ,UnitPrice=1500,UnitsInStoct=2},
            new Product() { ProductId=4,CategoryId=2,ProductName="Klavye" ,UnitPrice=150,UnitsInStoct=65},
            new Product() { ProductId=5,CategoryId=2,ProductName="Fare" ,UnitPrice=85,UnitsInStoct=1},
            };

        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            
            _products.Remove(productToDelete);

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        
        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStoct = product.UnitsInStoct;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
        public List<Product> GetAllByCategory(int CategoryId)
        {
             return _products.Where(p => p.CategoryId == CategoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
