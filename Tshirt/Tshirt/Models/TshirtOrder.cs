using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Tshirt.Model
{
    public class TshirtOrder
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set;}
        public string Name { get; set;}
        public string Surname { get; set;}
        public string Gender { get; set; }
        public string Tshirtcolour { get; set; }
        public string Shippingaddress { get; set; }
    }
}
