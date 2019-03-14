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
	public partial class PickFromThreePage : ContentPage
	{
        FloraData floraData = new FloraData();
		public PickFromThreePage ()
		{
			InitializeComponent ();
		}

        private void GpsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GpsPage());
        }

        private void KeyButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KeyPage());
        }

        private void DirectLookupFamilyButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DirectLookupFamilyPage());
        }
    }
}