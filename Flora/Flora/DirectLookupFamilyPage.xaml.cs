using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Flora.Model;

namespace Flora
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DirectLookupFamilyPage : ContentPage
	{
        FloraData floraData = new FloraData();
        public DirectLookupFamilyPage()
        {
            InitializeComponent();
        }


        List<string> familyList = new List<string>();
        LinkedList<string> genusPlusFamily = new LinkedList<string>();
        List<string> genusList = new List<string>();
        List<string> scientificNameList = new List<string>();
        List<string> taxonidPlusList = new List<string>();

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            string[] recData = await floraData.GetData();

            for (int i = 0; i < recData.Length; i += 4)
            {
                familyList.Add(recData[i]);
                Debug.WriteLine(i + " familyList " + familyList.Last());
                genusPlusFamily.AddLast(recData[i + 1]);
                Debug.WriteLine(i + " genusList " + genusPlusFamily.Last());
                scientificNameList.Add(recData[i + 2]);
                Debug.WriteLine(i + " scientific name " + scientificNameList.Last());
                taxonidPlusList.Add(recData[i + 3]);
                Debug.WriteLine(i + " taxonid plus scientific name is " + taxonidPlusList.Last());
            }
            scientificNameList = scientificNameList.Distinct().ToList();
            familyList = familyList.Distinct().ToList();
            familyList.Sort();
            var familyNameList = new ObservableCollection<string>(familyList);
            listViewFamily.ItemsSource = familyNameList;
        }

        void Family_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string selectedFamily = listViewFamily.SelectedItem as string;
            foreach (string item in genusPlusFamily)
            {
                if (item.Contains(selectedFamily))
                {
                    string[] pieces = item.Split(null);
                    Debug.WriteLine("piece one is " + pieces[0]);
                    Debug.WriteLine("piece two is " + pieces[1]);
                    genusList.Add(pieces[1]);
                }
            }
            genusList = genusList.Distinct().ToList();
            genusList.Sort();
            Navigation.PushAsync(new DirectLookupGenusPage(selectedFamily, genusList, scientificNameList, taxonidPlusList));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            genusPlusFamily.Clear();
            genusList.Clear();
            //familyList.Clear();
            //scientificNameList.Clear();
            //hasImageList.Clear();
        }
    }
}