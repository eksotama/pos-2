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
    public partial class VentasDetail : ContentPage
    {
        public Sell Venta_Info { get; set; }

        public Product Product_Info { get; set; }

        public Client Client_Info { get; set; }

        public List<Product> Product_List;
        public List<Client> Client_List;
        public VentasDetail(int id)
        {
            InitializeComponent();
            Venta_Info = Sell.Get(id);

            Product_List = Product.Get_All().Where(product => product.Quantity > 0).ToList();
            Client_List = Client.Get_All();

            Product_Info = Product.Get(Venta_Info.Product_Id);
            Client_Info = Client.Get(Venta_Info.Client_Id);
        }

        protected override void OnAppearing()
        {

            Product_Photo.Source = Product_Info.Photo_Url;
            Quantity.Text = Venta_Info.Amount.ToString();
            Total.Text = Venta_Info.Total.ToString();
            Earnings.Text = Venta_Info.Earnings.ToString();
            Picker_Productos.ItemsSource = Product_List.ConvertAll(product => $"{product.Name} - ${String.Format("{0:#.00}", product.Price)}");
            Picker_Clientes.ItemsSource = Client_List.ConvertAll(client => client.Name);
            Product_Photo.Source = Product_Info.Photo_Url;

            int currentClientId = Client_List.FindIndex(client => client.Id == Client_Info.Id);
            int currentProductId = Product_List.FindIndex(product => product.Id == Product_Info.Id);

            Picker_Clientes.SelectedIndex = currentClientId;
            Picker_Productos.SelectedIndex = currentProductId;
        }

        private void Update_Venta(object sender, EventArgs e)
        {

            Venta_Info.Update();
            Return_To_List();
        }

        private async void Delete_Venta(object sender, EventArgs e)
        {
            var acceptDeleting = await DisplayAlert("Eliminar venta", "Estas seguro de querer borrar la venta?", "OK", "Cancelar");

            if (acceptDeleting)
            {
                Venta_Info.Delete();
                Return_To_List();
            }
        }

        private async void Return_To_List()
        {
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
            if (Quantity.Text.IndexOf('.') >= 0)
            {
                await DisplayAlert("Error", "La cantidad debe ser entera", "OK");
                Quantity.Text = Quantity.Text.Substring(0, Quantity.Text.IndexOf('.'));
            }

            int quantity = Quantity.Text.Length != 0 && Quantity.Text.IndexOf('.') == -1 ? int.Parse(Quantity.Text) : 0;
            float price = Product_List[Picker_Productos.SelectedIndex].Price;

            Total.Text = $"${String.Format("{0:#.00}", price * quantity)}";
        }
    }
}