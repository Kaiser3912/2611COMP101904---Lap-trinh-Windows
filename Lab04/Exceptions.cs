using System;

namespace Lab04
{
    public class DuplicateProductException : Exception
    {
        public string ProductId { get; }

        public DuplicateProductException(string id)
            : base($"Lỗi: Sản phẩm với mã '{id}' đã tồn tại trong hệ thống!")
        {
            ProductId = id;
        }
    }

    public class ProductNotFoundException : Exception
    {
        public string ProductId { get; }

        public ProductNotFoundException(string id)
            : base($"Lỗi: Không tìm thấy sản phẩm có mã '{id}'!")
        {
            ProductId = id;
        }
    }
}