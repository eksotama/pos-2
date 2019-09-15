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

        private void Register_Client(object sender, EventArgs e)
        {

        }
    }
}