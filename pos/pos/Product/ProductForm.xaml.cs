using Plugin.Media;
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
    public partial class ProductForm : ContentPage
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private async void Register_Product(object sender, EventArgs e)
        {
            string name, photo;
            int quantity;
            float price, cost;
            try
            {
                name = Name_Entry.Text;
                photo = Photo_Entry.Text;
                quantity = int.Parse(Quantity_Entry.Text);
                price = float.Parse(Price_Entry.Text);
                cost = float.Parse(Cost_Entry.Text);
            }
            catch
            {
                await DisplayAlert("Alerta", "Todos los campos deben estar llenos", "OK");
                return;
            }

            Product product = new Product
            {
                Name = name,
                Cost = cost,
                Price = price,
                Photo_Url = photo,
                Quantity = quantity
            };

            product.Insert();
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void TakePicture_Clicked(object sender, EventArgs e)
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Products",
                Name = "idxd.jpg"
            });

            if (file == null)
                return;

            Profile.Source = file.Path;
            Photo_Entry.Text = file.Path;
        }
    }
}