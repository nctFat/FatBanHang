using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanHang.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        private List<CartItem> _items;

        public Cart()
        {
            _items = new List<CartItem>();

        }
        public List<CartItem> Items { get { return _items; } }
        // Các phương thức xử lý
        public void Add(Product p,int qty)
        {
            var item = _items.FirstOrDefault(x => x.Product.Id == p.Id);
            if (item == null)
            {
                _items.Add(new CartItem { Product = p, Quantity = qty });
            }
            else
            {
                item.Quantity += 1;
            }

        }
        public void Update(int ProductID,int qty)
        {
            var item = _items.FirstOrDefault(x => x.Product.Id == ProductID);
            if(item != null)
            {
                if(qty>0)
                {
                    item.Quantity = qty;
                }
                else
                {
                    _items.Remove(item);
                }
            }
        }
        // delete
        public void Delete(int Product)
        {
            var item = _items.FirstOrDefault(x => x.Product.Id == Product);
            if(item != null)
            {
                _items.Remove(item);
            }

        }
        //tính tiền đơn hàng
        public double Total

        {
            get
            {
                double total = _items.Sum(x => x.Quantity * x.Product.Price);
                return total;
            }
        }
        // tính tổng số lượng
        public double Quantity
        {
            get
            {
                double quantity = _items.Sum(x => x.Quantity);
                return quantity;
            }
        }
    }
}
