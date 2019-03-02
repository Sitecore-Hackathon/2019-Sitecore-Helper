using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Sitecore.Feature.MobileApp.Models;
using Sitecore.Feature.MobileApp.ViewHolders;

namespace Sitecore.Feature.MobileApp.Adapter
{
    public class DestinationAdapter : RecyclerView.Adapter
    {
        public event EventHandler<string> ItemClick;
        private List<Destination> _datasource;
        private Context _context;
        private string TAG = "DestinationAdapter";

        public DestinationAdapter(Context context, List<Destination> datasource)
        {
            _datasource = datasource;
            _context = context;
        }

        public void UpdateDataSource(List<Destination> datasource)
        {
            _datasource = datasource;
            NotifyDataSetChanged();
        }

        #region Overrides

        public override int ItemCount
        {
            get
            {
                return _datasource.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Destination album = _datasource[position];
            DestinationViewHolder viewHolder = holder as DestinationViewHolder;
            viewHolder.Title.Text = album.Name;
            viewHolder.SitecoreItemID = album.SitecoreID;

            try
            {
                Glide.With(_context).Load(album.Thumbnail).Into(viewHolder.Thumbnail);
            }
            catch (Exception e)
            {
                Log.Error(TAG, e.Message);
            }

        }

     

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Card, parent, false);
            var MainPage = new Xamarin.Forms.NavigationPage();
            ImageView img = itemView.FindViewById<ImageView>(Resource.Id.thumbnail);

            return new DestinationViewHolder(itemView, OnClick);
        }

        #endregion

        #region Events

        private void Popup_MenuItemClick(object sender, Android.Support.V7.Widget.PopupMenu.MenuItemClickEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.BookNow:
                    Toast.MakeText(_context, "Book Now", ToastLength.Long).Show();
                    break;
                case Resource.Id.QuickView:
                    Toast.MakeText(_context, "Quick View", ToastLength.Long).Show();
                    break;
                default:
                    break;
            }
        }

        void OnClick(string id)
        {
            if (ItemClick != null)
                ItemClick(this, id);
        }

        #endregion
    }
}