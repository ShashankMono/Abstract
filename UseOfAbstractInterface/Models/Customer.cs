using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseOfAbstractInterface.Models
{
    internal class Customer:Store
    {
        public Dictionary<string, double> cart = new Dictionary<string, double>();
        public Customer(string name, string contactNumber) : base(name, contactNumber) { }
        public override string Details()
        {
            return $"Customer Name : {Name}\n" +
                $"Contact Number : {ContactNumber}";
        }

        public override void AddToCart(string product, double price)
        {
            cart.Add(product, price);
        }

        public override string ShowCart()
        {
            if(cart.Count == 0)
            {
                return "Cart is empty!";
            }
            string result = "\n==================> Your Cart <==================\n";
            double total = 0;
            foreach(var pair in cart)
            {
                result += $"{pair.Key} : {pair.Value}\n";
                total += pair.Value;
            }
            result += $"Total value of cart is : {total}";
            return result;
        }

    }
}
