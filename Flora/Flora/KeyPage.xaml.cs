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
	public partial class KeyPage : ContentPage
	{
		public KeyPage ()
		{
			InitializeComponent ();
		}

        private void OptionOneButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RefinePage());
        }

        private void OptionTwoButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RefinePage());
        }

        private void OptionThreeButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RefinePage());
        }

        private void StartOverButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PickFromThreePage());
        }
    }
}