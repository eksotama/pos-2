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
        private Type Add_Item_Page;

        private Type Detail_Item_Page;

        private string TitleString;

        public ListPage(List<ListItem> items, Type addItemPage, Type detailItemPage, string title)
        {
            if (items.Count > 0)
            {
                Items_List.ItemsSource = new ObservableCollection<ListItem>(items);
            }

            Add_Item_Page = addItemPage;
            Detail_Item_Page = detailItemPage;
            TitleString = title;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Title = TitleString;
        }

        private async void Add_Item(object sender, EventArgs e)
        {
            var page = Activator.CreateInstance(Add_Item_Page);
            await Navigation.PushAsync((ContentPage)page);
        }
    }
}