using System;

namespace Lab04
{
    public class Product : IEntity
    {
        private decimal _giatien;
        private int _sanpham;

        public string MaSP { get; set; } = string.Empty;
        public string TenSP { get; set; } = string.Empty;

        public string Id => MaSP;

        public decimal Price
        {
            get => _giatien;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Đơn giá không được nhận giá trị âm!");
                _giatien = value;
            }
        }

        public int Quantity
        {
            get => _sanpham;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số lượng không được nhận giá trị âm!");
                _sanpham = value;
            }
        }


        public Product(string maSP, string tenSP, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Mã sản phẩm không được để trống!");

            MaSP = maSP.Trim();
            TenSP = tenSP?.Trim() ?? string.Empty;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Mã SP: {MaSP,-8} | Tên SP: {TenSP,-20} | Đơn giá: {Price,10:N0} đ | Số lượng: {Quantity,5} | Thành tiền: {(Price * Quantity),12:N0} đ";
        }
    }
}