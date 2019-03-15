using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DirectLookupSpeciesPage : ContentPage
	{
        public string familyName;
        public string genusName;
        ObservableCollection<string> scientificNameList;
		public DirectLookupSpeciesPage (string familyName, string genusName, List<string> scientificNameListSorted)
		{
			InitializeComponent ();
            this.familyName = familyName;
            this.genusName = genusName;
            this.scientificNameList = new ObservableCollection<string>(scientificNameListSorted);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listViewScientificName.ItemsSource = scientificNameList;
        }

        void Scientific_Name_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string selectedScientificName = listViewScientificName.SelectedItem as string;
            Navigation.PushAsync(new PlantProfilePage(familyName, genusName, selectedScientificName));
        }
    }
}