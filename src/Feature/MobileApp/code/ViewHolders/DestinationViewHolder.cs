using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Sitecore.Feature.MobileApp.ViewHolders
{
    public class DestinationViewHolder: RecyclerView.ViewHolder
    {
        public TextView Title { get; set; }
        public TextView Count { get; set; }
        public ImageView Thumbnail { get; set; }
        public ImageView Overflow { get; set; }
        public string SitecoreItemID { get; set; }

        public DestinationViewHolder(View view, Action<string> listener) : base(view)
        {
            this.Title = view.FindViewById<TextView>(Resource.Id.title);
            this.Thumbnail = view.FindViewById<ImageView>(Resource.Id.thumbnail);
            this.Overflow = view.FindViewById<ImageView>(Resource.Id.overflow);
            this.Thumbnail.Click += (sender, e) => listener(SitecoreItemID);

            

        }

    }
}