using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace pos
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void Go_To_Clients_List_Page(object sender, EventArgs e)
        {
            List<ListItem> items = Client.Get_All().ConvertAll(client => new ListItem { Photo_Url = client.Profile_Url, Title = client.Name });
            await Navigation.PushAsync(new ListPage(items));
        }

        private void Go_To_Products_List_Page(object sender, EventArgs e)
        {

        }

        private async void Go_To_Sells_Page(object sender, EventArgs e)
        {

        }

        private async void Go_To_Reports_Page(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Reports());
        }
    }
}
