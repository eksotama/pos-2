using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        private Type Add_Item_Page { get; set; }

        private Type Detail_Item_Page { get; set; }

        private string TitleString { get; set; }

        private Func<List<ListItem>> Getter { get; set; }

        public ListPage(Func<List<ListItem>> getterFunc, Type addItemPage, Type detailItemPage, string title)
        {
            Getter = getterFunc;
            Add_Item_Page = addItemPage;
            Detail_Item_Page = detailItemPage;
            TitleString = title;
            BindingContext = this;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Title = TitleString;
            Items_List.ItemsSource = Getter();
        }

        private async void Add_Item(object sender, EventArgs e)
        {
            var page = Activator.CreateInstance(Add_Item_Page);
            await Navigation.PushAsync((ContentPage)page);
        }
    }
}