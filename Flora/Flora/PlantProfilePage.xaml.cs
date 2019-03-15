using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flora
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlantProfilePage : ContentPage
	{
        public string familyName { get; }
        public string genusName { get; }
        public string scientificName { get; }
		public PlantProfilePage (string familyName, string genusName, string scientificName)
		{
			InitializeComponent ();
            this.familyName = familyName;
            this.genusName = genusName;
            this.scientificName = scientificName;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FamilyName.BindingContext = this;
            GenusName.BindingContext = this;
            ScientificName.BindingContext = this;
        }

    }
}