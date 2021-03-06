﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Sitecore.Feature.MobileApp;
using System;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;
using Com.Bumptech.Glide;
using Android.Util;
using Sitecore.Feature.MobileApp.Helpers;
using Sitecore.Feature.MobileApp.Adapter;
using static Android.Support.V7.Widget.RecyclerView;
using Android.Content;
using Sitecore.Feature.MobileApp.Models;
using System.Collections.Generic;
using Sitecore.Foundation.Tracker.UT;

namespace Sitecore.Feature.MobileApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView _recyclerView;
        private DestinationAdapter _adapter;
        
        private List<Destination> _destinations;
        private AppBarLayout _appBarLayout;
        private CollapsingToolbarLayout _collapsingToolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.Main);    //Setting the layout for Home page
                _destinations = new List<Destination>();
                SetupRecyclerView();  // creating card layout for destinations
                SetupCollapsingToolbar();
                LoadBackdropCover();  // loading banner image


             /* Here we are tracking the activity of the user using universal tracker.
                we are triggering a event of type goal and event in the below method  */

                RegisterInteractions register = new RegisterInteractions();

                register.Register();


            }
            catch(Exception ex)
            {
                Log.Error("error occured in oncreate method in Main Activity", ex.Message);
            }
            
        }

        // This method is for loading the banner image
        private  void LoadBackdropCover()
        {
            try
            { DestinationHelper sm = new DestinationHelper();
                Glide.With(this).Load(Resource.Drawable.Backdrop)
                   .Into((ImageView)FindViewById(Resource.Id.imageBackdrop));

            }
            catch (System.Exception e)
            {
                Log.Error("error occured in LoadBackdropCover method in Main Activity", e.Message);
            }
        }

        //This method is for setting up card layout
        private void SetupRecyclerView()
        {
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _adapter = new DestinationAdapter(this, _destinations);
            _adapter.ItemClick += OnItemClick;

            LayoutManager layoutManager = new GridLayoutManager(this, 2);
            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.SetAdapter(_adapter);

            DestinationList();


        }

        //This method is for getting the Destinations. The Destinations are displayed in card and tile layout
        private async void DestinationList()
        {
            DestinationHelper dm = new DestinationHelper();
            _destinations = await dm.GetDestinations();
            _adapter.UpdateDataSource(_destinations);
        }
        private void SetupCollapsingToolbar()
        {
            _collapsingToolbar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsingToolbar);
            _collapsingToolbar.SetTitle(" ");

            this._appBarLayout = FindViewById<AppBarLayout>(Resource.Id.appBar);
            this._appBarLayout.SetExpanded(true);
            this._appBarLayout.OffsetChanged += AppBarLayout_OffsetChanged;
        }
        private void AppBarLayout_OffsetChanged(object sender, AppBarLayout.OffsetChangedEventArgs e)
        {

            int scrollRange = -1;
            if (scrollRange == -1) scrollRange = _appBarLayout.TotalScrollRange;

            if (scrollRange + e.VerticalOffset == 0)
            {
                this._collapsingToolbar.SetTitle(GetString(Resource.String.app_name));
            }
            else
            {
                this._collapsingToolbar.SetTitle(" ");
            }
        }

        //This method is for redirecting the user to next page on click of any of the card
        void OnItemClick(object sender, string id)
        {
            Intent intent = new Intent(this, typeof(PageDetailActivity));
            intent.PutExtra("id", id);
            StartActivity(intent);
        }
        
        
    }
}