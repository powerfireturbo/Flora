using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Flora.Model;
using System.Diagnostics;

namespace Flora
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlantProfilePage : ContentPage
	{
        FloraData floraData = new FloraData();
        public string familyName { get; }
        public string genusName { get; }
        public string scientificName { get; }
        public string taxonid;
        public string indianaFlora { get; set; }
        List<string> uriList = new List<string>();
        public PlantProfilePage(string familyName, string genusName, string scientificName, string taxonid)
        {
            InitializeComponent();
            this.familyName = familyName;
            this.genusName = genusName;
            this.scientificName = scientificName;
            this.taxonid = taxonid;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            uriList = await floraData.WebScraper(taxonid);
            FamilyName.BindingContext = this;
            GenusName.BindingContext = this;
            ScientificName.BindingContext = this;
            indianaFlora = uriList.First();
            uriList.Remove(indianaFlora);
            Indiana_Flora_description.BindingContext = this;
            PlantPicture.Source = uriList.First();

        }//OnAppearing end
    }
}