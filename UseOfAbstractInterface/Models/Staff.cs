using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseOfAbstractInterface.Models
{
    internal class Staff:Store
    {
        public int Id {  get; set; }
        public Staff(string name, string contactNumber, int id) : base(name, contactNumber)
        {
            Id = id;
        }

        public override string Details()
        {
            return $"Id number : {Id}" +
                $"Staff Name : {Name}\n" +
                $"Staff Number : {ContactNumber}";
        }

    }
}
