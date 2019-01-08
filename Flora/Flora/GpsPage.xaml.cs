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
	public partial class GpsPage : ContentPage
	{
		public GpsPage ()
		{
			InitializeComponent ();
		}

        private void RefineButton_Clicked(object sender, EventArgs e)
        {

        }

        private void StartOverButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}