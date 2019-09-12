using System;
using System.Collections.Generic;

namespace pos
{
    public abstract class Model<T> where T : new()
    {
        public void Insert()
        {
            var db = PosDb.Connect();
            db.Insert(this);
            db.Close();
        }

        public void Delete()
        {
            var db = PosDb.Connect();
            try
            {
                db.Delete(this);
            }
            catch
            {
                Console.WriteLine("No record to delete");
            }
            finally
            {
                db.Close();
            }
        }

        public void Update()
        {
            var db = PosDb.Connect();
            try
            {
                db.Update(this);
            }
            catch
            {
                Console.WriteLine("No record to update");
            }
            finally
            {
                db.Close();
            }
        }

        public static T Get(string id)
        {
            var db = PosDb.Connect();
            T records = db.Find<T>(id);
            db.Close();
            return records;
        }

        public static List<T> Get_All()
        {
            var db = PosDb.Connect();
            var records = db.Table<T>().ToList();
            db.Close();
            return records;
        }
    }
}
