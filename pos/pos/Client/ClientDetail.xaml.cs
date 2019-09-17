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
    public partial class ClientDetail : ContentPage
    {
        public Client Client_Info { get; set; }

        public ClientDetail(int id)
        {
            InitializeComponent();
            Client_Info = Client.Get(id);
        }

        protected override void OnAppearing()
        {
            Name_Entry.Text = Client_Info.Name;
            Email_Entry.Text = Client_Info.Email;
            Address_Entry.Text = Client_Info.Address;
            Phone_Entry.Text = Client_Info.Phone;
            Photo_Entry.Text = Client_Info.Profile_Url;
            Profile.Source = Client_Info.Profile_Url;
        }

        private void Update_Client(object sender, EventArgs e)
        {
            Client_Info.Name = Name_Entry.Text;
            Client_Info.Email = Email_Entry.Text;
            Client_Info.Phone = Phone_Entry.Text;
            Client_Info.Profile_Url = Photo_Entry.Text;
            Client_Info.Address = Address_Entry.Text;

            Client_Info.Update();
            Return_To_List();
        }

        private async void Delete_Client(object sender, EventArgs e)
        {
            var acceptDeleting = await DisplayAlert("Eliminar cliente", "Estas seguro de querer borrar al cliente", "OK", "Cancelar");

            if (acceptDeleting)
            {
                Client_Info.Delete();
                Return_To_List();
            }
        }

        private async void Return_To_List()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void TakePicture_Clicked(object sender, EventArgs e)
        {
            string imagePath = await Camera.TakePhoto("clients");
            Profile.Source = imagePath;
            Photo_Entry.Text = imagePath;
        }
    }
}