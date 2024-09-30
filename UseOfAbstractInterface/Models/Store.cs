using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseOfAbstractInterface.Models
{
    abstract class Store
    {
        public string Name {  get; set; }
        public string ContactNumber {  get; set; }

        public Store(string name,string contactNumber)
        {
            Name = name;
            ContactNumber = contactNumber;
        }
        public virtual void AddToCart(string product, double price) { }
        public virtual string ShowCart() { return ""; }

        public abstract string Details();
    }
}
