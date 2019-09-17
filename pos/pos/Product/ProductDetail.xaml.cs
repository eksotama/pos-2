using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetail : ContentPage
    {
        public Product Product_Info { get; set; }

        public ProductDetail(int id)
        {
            InitializeComponent();
            Product_Info = Product.Get(id);
        }

        protected override void OnAppearing()
        {
            Name_Entry.Text = Product_Info.Name;
            Price_Entry.Text = Product_Info.Price.ToString();
            Quantity_Entry.Text = Product_Info.Quantity.ToString();
            Cost_Entry.Text = Product_Info.Cost.ToString();
            Photo_Entry.Text = Product_Info.Photo_Url;

            Profile.Source = Product_Info.Photo_Url;
        }

        private async void Update_Product(object sender, EventArgs e)
        {
            try
            {
                Product_Info.Name = Name_Entry.Text;
                Product_Info.Price = float.Parse(Price_Entry.Text);
                Product_Info.Quantity = int.Parse(Quantity_Entry.Text);
                Product_Info.Photo_Url = Photo_Entry.Text;
                Product_Info.Cost = float.Parse(Cost_Entry.Text);
                Product_Info.Update();
                Return_To_List();
            }
            catch
            {
                await DisplayAlert("Error", "Faltan valores por llenar para el producto", "Cancel");
                Product_Info = Product.Get(Product_Info.Id);
                OnAppearing();
            }            
        }

        private async void Delete_Product(object sender, EventArgs e)
        {
            var acceptDeleting = await DisplayAlert("Eliminar Producte", "Estas seguro de querer borrar al Producte", "OK", "Cancelar");

            if (acceptDeleting)
            {
                Product_Info.Delete();
                Return_To_List();
            }
        }

        private async void Return_To_List()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
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