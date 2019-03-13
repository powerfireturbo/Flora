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
	public partial class DirectLookupFamilyPage : ContentPage
	{
		public DirectLookupFamilyPage ()
		{
			InitializeComponent ();
		}

        private void ViewGeneraButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DirectLookupGenusPage());
        }

        private void StartOverButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PickFromThreePage());
        }
    }
}