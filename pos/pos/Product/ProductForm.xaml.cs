using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductForm : ContentPage
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private async void Register_Product(object sender, EventArgs e)
        {
            try
            {
                string name = Name_Entry.Text;
                string photo = Photo_Entry.Text;
                int quantity = int.Parse(Quantity_Entry.Text);
                float price = float.Parse(Price_Entry.Text);
                float cost = float.Parse(Cost_Entry.Text);
                Random rnd = new Random();
                new Product
                {
                    Name = name,
                    Cost = cost,
                    Price = price,
                    Photo_Url = photo,
                    Quantity = quantity,
                    Color = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)).ToHex().Substring(0, 7)
                }.Insert();

                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch
            {
                await DisplayAlert("Alerta", "Todos los campos deben estar llenos", "OK");
            }

        }

        private async void TakePicture_Clicked(object sender, EventArgs e)
        {
            string imagePath = await Camera.TakePhoto("products");
            Profile.Source = imagePath;
            Photo_Entry.Text = imagePath;
        }

        private void Photo_Entry_Completed(object sender, EventArgs e)
        {
            Refresh_Profile();
        }

        private void Photo_Entry_Unfocused(object sender, FocusEventArgs e)
        {
            Refresh_Profile();
        }

        private void Refresh_Profile()
        {
            Profile.Source = Photo_Entry.Text;
        }
    }
}