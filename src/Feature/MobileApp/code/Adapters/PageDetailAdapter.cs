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
using Com.Bumptech.Glide;
using Sitecore.Feature.MobileApp.Models;
using Sitecore.Feature.MobileApp.ViewHolders;

namespace Sitecore.Feature.MobileApp.Adapters
{
    public class PageDetailAdapter : RecyclerView.Adapter
    {
        public event EventHandler<string> ItemClick;
        private Context _context;
        private Destination _datasource;

        public PageDetailAdapter(Context context, Destination datasource)
        {
            _datasource = datasource;
            _context = context;
        }
        public void UpdateDataSource(Destination datasource)
        {
            _datasource = datasource;
            NotifyDataSetChanged();
        }
        public override int ItemCount
        {
            get
            {
                return 1;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Destination destinationDetail = _datasource;
            PageDetailViewHolder ch = holder as PageDetailViewHolder;
            if (destinationDetail != null)
            { 
                ch.Description.Text = destinationDetail.Description;

                try
                {
                    Glide.With(_context).Load(destinationDetail.BannerImage).Into(ch.Image);
                }
                catch (Exception e)
                {

                }
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
               Inflate(Resource.Layout.PageContent, parent, false);
            PageDetailViewHolder vh = new PageDetailViewHolder(itemView, OnClick);
            return vh;
        }
        void OnClick(string id)
        {
            if (ItemClick != null)
                ItemClick(this, id);
        }
    }
}