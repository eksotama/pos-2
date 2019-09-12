using System;
using System.Collections.Generic;
using System.Text;

namespace pos
{
    public class Product
    {
        public string Name;

        public string Photo_Url;

        public int Quantity;

        public float Price;

        public float Cost;

        public static Product Get(string id)
        {
            return new Product();
        }
        public static List<Product> Get_All()
        {
            return new List<Product>();
        }
    }
}
