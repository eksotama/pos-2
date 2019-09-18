using System;
using System.Collections.Generic;
using SQLite;

namespace pos
{
    public class Sell : Model<Sell>
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Client_Id { get; set; }

        public int Product_Id { get; set; }

        public int Amount { get; set; }

        public float Total { get; set; }

        public float Earnings { get; set; }
        
        public DateTime Timestamp { get; set; }

        public string Photo_Path { get; set; }

        private List<Sell> Get_Sells_From_Last_N_Days(int days)
        {
            var db = PosDb.Connect();
            List<Sell> sells = db.Table<Sell>().Where(sell => sell.Timestamp > DateTime.Now.AddDays(days)).ToList();
            db.Close();
            return sells;
        }

        public List<Sell> Get_Daily_Sells()
        {
            return Get_Sells_From_Last_N_Days(-1);
        }

        public List<Sell> Get_Weekly_Sells()
        {
            return Get_Sells_From_Last_N_Days(-7);
        }

        public List<Sell> Get_Annualy_Sells()
        {
            return Get_Sells_From_Last_N_Days(-365);
        }
    }
}
