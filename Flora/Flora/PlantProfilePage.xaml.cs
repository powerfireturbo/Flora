﻿using System;
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
		public PlantProfilePage ()
		{
			InitializeComponent ();
		}

        private void StartOverButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}