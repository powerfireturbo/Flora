using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Flora.Model;

namespace Flora
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DirectLookupFamilyPage : ContentPage
	{
        FloraData floraData = new FloraData();
		public DirectLookupFamilyPage ()
		{
			InitializeComponent ();
		}




        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var coll = new ObservableCollection<FloraData.StringData>(await floraData.GetData());
            listViewFamily.ItemsSource = coll;
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedFamily = listViewFamily.SelectedItem as FloraData.StringData;
            Navigation.PushAsync(new DirectLookupGenusPage(selectedFamily));
        }

    }
}