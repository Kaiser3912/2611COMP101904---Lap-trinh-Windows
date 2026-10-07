using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    public class ProductService
    {
        private readonly Repository<Product> _repository;

        public event Action<Product>? OnProductAdded;
        public event Action<Product>? OnProductRemoved;

        public ProductService(Repository<Product> repository)
        {
            _repository = repository;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (string.IsNullOrWhiteSpace(product.MaSP))
                throw new ArgumentException("Mã sản phẩm không được rỗng!");

            if (_repository.FindById(product.MaSP) != null)
                throw new DuplicateProductException(product.MaSP);

            _repository.Add(product);
            OnProductAdded?.Invoke(product); 
        }

        public void RemoveProduct(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Mã sản phẩm không hợp lệ!");

            var existing = _repository.FindById(maSP);
            if (existing == null)
                throw new ProductNotFoundException(maSP);

            _repository.Remove(maSP);
            OnProductRemoved?.Invoke(existing); 
        }

        public Product? FindById(string maSP)
        {
            return _repository.FindById(maSP);
        }

        public IReadOnlyList<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Product> SearchByName(string keyword)
        {
            string kw = (keyword ?? string.Empty).Trim().ToLower();
            return _repository.Find(p => p.TenSP.ToLower().Contains(kw));
        }

        public IEnumerable<Product> Filter(Func<Product, bool> predicate)
        {
            return _repository.Find(predicate);
        }

        public decimal CalculateTotalInventoryValue()
        {
            return _repository.GetAll().Sum(p => p.Price * p.Quantity);
        }
    }
}