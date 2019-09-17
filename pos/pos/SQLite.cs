using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SQLite;

namespace pos
{
    class PosDb
    {
        public static SQLiteConnection Connect()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dbPath = Path.Combine(folder, "pos.db");
            return new SQLiteConnection(dbPath);
        }
    }
}
