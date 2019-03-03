using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Sitecore.Feature.MobileApp.Adapters;
using Sitecore.Feature.MobileApp.Helpers;
using Sitecore.Feature.MobileApp.Models;
using static Android.Support.V7.Widget.RecyclerView;

namespace Sitecore.Feature.MobileApp
{
    [Activity(Label = "PageDetailActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class PageDetailActivity : Activity
    {
        private RecyclerView _recyclerView;
        private PageDetailAdapter _adapter;
        private Destination _destinationDetail;
        private AppBarLayout _appBarLayout;
        private CollapsingToolbarLayout _collapsingToolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string id = Intent.GetStringExtra("id"); //getting the sitecore id of the item clicked
            SetContentView(Resource.Layout.DetailPage);  // setting layout for second page
            SetupRecyclerView(id);
        }

        // Setting up recycler view
        private void SetupRecyclerView(string id)
        {
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView2);
            _adapter = new PageDetailAdapter(this, _destinationDetail);

            _adapter.ItemClick += OnItemClick;

            LayoutManager layoutManager = new GridLayoutManager(this, 1);
            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.SetAdapter(_adapter);

            GetData(id);
        }

        //get detailed info about a destination
        private async void GetData(string id)
        {
            DestinationHelper dm = new DestinationHelper();
            if (!string.IsNullOrEmpty(id))
            {
                _destinationDetail = await dm.GetTravelDestinationDetail(id);
                _adapter.UpdateDataSource(_destinationDetail);
            }

        }

        //On click of book now button
        void OnItemClick(object sender, string id)
        {
            
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
                this._collapsingToolbar.SetTitle("Travel App");
            }
        }
    }
}