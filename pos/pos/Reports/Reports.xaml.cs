using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microcharts;
using SkiaSharp;

namespace pos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reports : ContentPage
    {
        public Reports()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            float totalEarnings = Sell.TotalEarnings;
            Total_Earnings.Text = $"${totalEarnings}";

            if (totalEarnings > 0)
            {
                Total_Earnings.TextColor = Color.Green;
            }
            else if (totalEarnings < 0)
            {
                Total_Earnings.TextColor = Color.Red;
            }

            Show_Daily();
            Show_Weekly();
            Show_Annualy();
        }

        private BarChart Create_Bar_Chart_Based_On_Sells(List<Sell> sells)
        {
            return new BarChart
            {
                Entries = sells.ConvertAll(sell => new Microcharts.Entry(sell.Amount)
                {
                    Label = Product.Get(sell.Product_Id).Name,
                    ValueLabel = sell.Amount.ToString()
                })
            };
        }

        public void Show_Daily()
        {
            List<Sell> sells = Sell.Get_Daily_Sells();

            Daily_Chart.Chart = Create_Bar_Chart_Based_On_Sells(sells);
        }

        public void Show_Weekly()
        {
            List<Sell> sells = Sell.Get_Weekly_Sells();

            Weekyly_Chart.Chart = Create_Bar_Chart_Based_On_Sells(sells);
        }

        public void Show_Annualy()
        {
            List<Sell> sells = Sell.Get_Annualy_Sells();

            Annualy_Chart.Chart = Create_Bar_Chart_Based_On_Sells(sells);
        }
    }
}