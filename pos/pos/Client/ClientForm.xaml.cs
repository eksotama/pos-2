using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientForm : ContentPage
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private async void Register_Client(object sender, EventArgs e)
        {
            Client client = new Client
            {
                Name = Name_Entry.Text,
                Address = Address_Entry.Text,
                Phone = Phone_Entry.Text,
                Email = Email_Entry.Text,
                Profile_Url = Photo_Entry.Text
            };

            client.Insert();
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void TakePicture_Clicked(object sender, EventArgs e)
        {
            string imagePath = await Camera.TakePhoto("clients");
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