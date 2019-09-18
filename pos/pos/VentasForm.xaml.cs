using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VentasForm : ContentPage
    {
        public List<Product> Product_List;
        public List<Client> Client_List;
        public VentasForm()
        {
            Product_List = Product.Get_All().Where(product => product.Quantity > 0).ToList();
            Client_List = Client.Get_All();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Picker_Productos.ItemsSource = Product_List.ConvertAll(product => $"{product.Name} - ${String.Format("{0:#.00}", product.Price)}");
            Picker_Clientes.ItemsSource = Client_List.ConvertAll(client => client.Name);
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            Product producto = Product_List[Picker_Productos.SelectedIndex];
            Client cliente = Client_List[Picker_Clientes.SelectedIndex];
            int cantidad = int.Parse(Quantity_Entry.Text);

            Sell sell = new Sell
            {

                Client_Id = cliente.Id,
                Product_Id = producto.Id,
                Amount = cantidad,
                Total = producto.Price * cantidad,
                Earnings = (producto.Price - producto.Cost) * cantidad,
                Timestamp = DateTime.Now,
                Photo_Path = producto.Photo_Url
            };

            sell.Insert();
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void Picker_Productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process_Change();

        }

        private void Quantity_Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Process_Change();
        }

        private async void Process_Change()
        {
            if (Quantity_Entry.Text.IndexOf('.') >= 0)
            {
                await DisplayAlert("Error", "La cantidad debe ser entera", "OK");
                Quantity_Entry.Text = Quantity_Entry.Text.Substring(0, Quantity_Entry.Text.IndexOf('.'));
            }

            int quantity = Quantity_Entry.Text.Length != 0 && Quantity_Entry.Text.IndexOf('.') == -1 ? int.Parse(Quantity_Entry.Text) : 0;
            float price = Product_List[Picker_Productos.SelectedIndex].Price;

            Total.Text = $"${String.Format("{0:#.00}", price * quantity)}";
        }
    }
}