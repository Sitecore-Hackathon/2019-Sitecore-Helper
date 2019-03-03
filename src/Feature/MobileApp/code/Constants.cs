using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Sitecore.Feature.MobileApp
{
    public class Constants
    {
        public struct Settings
        {
            // This is Sitecore 9 instance url. we are fetching data from this instance. Please change it according to your instnace name
            public const string ResetBaseUrl = "http://sc91.local";
            public const string BackdropTitle = "BackdropTitle";
            public const string BackdropSubtitle = "BackdropSubtitle";
            public const string BackdropImage = "BackdropImage";

        }
        public struct ConstantPath
        {
            public const string RepositoryPath = "/sitecore/content/Dev/Data/Destinations";

        }
        public struct Templates
        {
            public struct Destination
            {
                public struct Fields
                {
                    public const string DestinationName = "Name";
                    public const string Thumbnail = "Thumbnail";
                    public const string BannerImage = "Banner";
                    public const string Description = "Description";


                }
            }
        }
    }
}
