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
	public partial class RefinePage : ContentPage
	{
		public RefinePage ()
		{
			InitializeComponent ();
		}

        private void OptionOneButton_Clicked(object sender, EventArgs e)
        {

        }

        private void OptionTwoButton_Clicked(object sender, EventArgs e)
        {

        }

        private void OptionThreeButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ViewResultsOnMapButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GpsPage());
        }

        private void StartOverButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PickFromThreePage());
        }
    }
}