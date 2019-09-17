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
    public partial class ClientForm : ContentPage
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private async void Register_Client(object sender, EventArgs e)
        {
            string name = Name_Entry.Text;
            string address = Address_Entry.Text;
            string phone = Phone_Entry.Text;
            string email = Email_Entry.Text;
            string photo = Photo_Entry.Text;

            Client client = new Client
            {
                Name = name,
                Address = address,
                Phone = phone,
                Email = email,
                Profile_Url = photo
            };

            client.Insert();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}