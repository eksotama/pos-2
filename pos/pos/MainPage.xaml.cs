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
            Func<List<ListItem>> getClients = () => Client.Get_All().ConvertAll(client => new ListItem { Photo_Path = client.Profile_Url, Title = client.Name, Detail = client.Phone });
            var page = new ListPage(getClients, typeof(ClientForm), typeof(ClientDetail), "Clientes");
            await Navigation.PushAsync(page);
        }

        private async void Go_To_Products_List_Page(object sender, EventArgs e)
        {
            Func<List<ListItem>> getProducts = () => Product.Get_All().ConvertAll(product => new ListItem { Photo_Path = product.Photo_Url, Title = product.Name, Detail = product.Price });
            var page = new ListPage(getProducts, typeof(ProductForm), typeof(ProductDetail), "Productos");
            await Navigation.PushAsync(page);
        }

        private async void Go_To_Sells_Page(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ListPage(new List<ListItem>()));
        }

        private async void Go_To_Reports_Page(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Reports());
        }
    }
}
