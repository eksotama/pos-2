using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace pos
{
    class Sell
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
    }
}
