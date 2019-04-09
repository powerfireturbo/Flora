using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace Flora
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DirectLookupSpeciesPage : ContentPage
	{
        public string familyName;
        public string genusName;
        ObservableCollection<string> scientificNameList;
        List<string> taxonidPlusList = new List<string>();
        public DirectLookupSpeciesPage(string familyName, string genusName, List<string> scientificNameListSorted, List<string> taxonidPlusList)
        {
            InitializeComponent();
            this.familyName = familyName;
            this.genusName = genusName;
            this.scientificNameList = new ObservableCollection<string>(scientificNameListSorted);
            this.taxonidPlusList = taxonidPlusList;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listViewScientificName.ItemsSource = scientificNameList;
        }
        public string taxonid;
        void Scientific_Name_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string selectedScientificName = listViewScientificName.SelectedItem as string;

            foreach (string item in taxonidPlusList)
            {
                if (item.Contains(selectedScientificName))
                {
                    string[] pieces = item.Split(null);
                    Debug.WriteLine("pieces[0]/taxonid is " + pieces[0]);
                    Debug.WriteLine("pieces[1]/scientificname is " + pieces[1]);
                    taxonid = pieces[0];
                }
            }
            Navigation.PushAsync(new PlantProfilePage(familyName, genusName, selectedScientificName, taxonid));
        }
    }
}