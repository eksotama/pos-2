using System;
using System.Collections.Generic;
using System.Text;

namespace pos
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Photo_Path { get; set; }

        public string Title { get; set; }

        public dynamic Detail { get; set; }

        public int Client_Id { get; set; }

        public int Product_Id { get; set; }

        public int Amount { get; set; }

        public float Total { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
