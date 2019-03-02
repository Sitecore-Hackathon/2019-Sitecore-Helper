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
    class PageDetailViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Description { get; private set; }

        public Button BookNow { get; private set; }
        public string SitecoreItemID { get; set; }

        public PageDetailViewHolder(View itemView, Action<string> listener) : base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Description = itemView.FindViewById<TextView>(Resource.Id.textView);
            this.BookNow = itemView.FindViewById<Button>(Resource.Id.submit);
            this.BookNow.Click += (sender, e) => listener(SitecoreItemID);
        }

    }
}