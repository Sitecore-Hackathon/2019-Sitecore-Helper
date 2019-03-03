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

namespace Sitecore.Feature.MobileApp.Models
{
    //Fields for each Destination
    public class Destination
    {
        public string SitecoreID { get; internal set; }
        public string Name { get; internal set; }
        public string Thumbnail { get; internal set; }

        public string BannerImage { get; internal set; }
        public string Description { get; internal set; }
    }
}