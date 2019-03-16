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
        public string hasImage;
        List<string> uriList;
        string[] uriArray = new string[3];
        public PlantProfilePage(string familyName, string genusName, string scientificName, string hasImage)
        {
            InitializeComponent();
            this.familyName = familyName;
            this.genusName = genusName;
            this.scientificName = scientificName;
            this.hasImage = hasImage;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            FamilyName.BindingContext = this;
            GenusName.BindingContext = this;
            ScientificName.BindingContext = this;

            if (Convert.ToBoolean(hasImage) == true)
            {
                uriList = new List<string>(await floraData.GetImage(scientificName));
                int i = 0;
                foreach (string item in uriList)
                {
                    uriArray[i] = item;
                    i++;
                    if (i > 1)
                    {
                        Debug.WriteLine("uriArray break at " + i);
                        break;
                    }
                }
                //PlantPicture.Source = ImageSource.FromUri(new Uri(uriList[0].ToString()));
                string url = "https://collections.nmnh.si.edu/media/index.php?irn=11986034";
                PlantPicture.Source = url;
            }
            /*
            else
            {
                PlantPicture.Source = ImageSource.FromResource("Flora.Images.plantPicture.jpg");
            }
            */
        }
    }
}