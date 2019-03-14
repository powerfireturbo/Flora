using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Flora.Model;

namespace Flora
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DirectLookupGenusPage : ContentPage
	{
		public DirectLookupGenusPage (FloraData.StringData selectedFamily)
		{
			InitializeComponent ();
		}

        private void ViewSpeciesButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DirectLookupSpeciesPage());
        }

        private void RefineButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RefinePage());
        }

        private void StartOverButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PickFromThreePage());
        }
    }
}