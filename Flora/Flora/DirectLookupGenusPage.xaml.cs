using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Flora.Model;
using System.Collections.ObjectModel;

namespace Flora
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DirectLookupGenusPage : ContentPage
	{
        public string familyName;
        ObservableCollection<string> genusList = new ObservableCollection<string>();
        List<string> scientificNameList = new List<string>();
        List<string> taxonidPlusList = new List<string>();
        public DirectLookupGenusPage(string selectedFamily, List<string> genusList, List<string> scientificNameList, List<string> taxonidPlusList)
        {
            InitializeComponent();
            this.familyName = selectedFamily;
            this.genusList = new ObservableCollection<string>(genusList);
            this.scientificNameList = scientificNameList;
            this.taxonidPlusList = taxonidPlusList;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listViewGenus.ItemsSource = genusList;
        }

        void Genus_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string selectedGenus = listViewGenus.SelectedItem as string;
            List<string> scientificNameListSorted = new List<string>();
            foreach (string item in scientificNameList)
            {
                if (item.Contains(selectedGenus))
                {
                    scientificNameListSorted.Add(item);
                }
            }
            scientificNameListSorted.Sort();
            Navigation.PushAsync(new DirectLookupSpeciesPage(familyName, selectedGenus, scientificNameListSorted, taxonidPlusList));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //genusPlusFamily.Clear();
            //genusList.Clear();
            //familyList.Clear();
            scientificNameList.Clear();
            //hasImageList.Clear();
        }
    }
}