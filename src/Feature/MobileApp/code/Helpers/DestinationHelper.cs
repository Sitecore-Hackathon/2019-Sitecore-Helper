using Android.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sitecore.Feature.MobileApp.Models;
using Sitecore.Foundation.Tracker.Helpers;
using Sitecore.Foundation.Tracker.Extensions;

namespace Sitecore.Feature.MobileApp.Helpers
{

    public class DestinationHelper
    {
        private SitecoreHelper _sitecoreHelper;

        public DestinationHelper()
        {

            _sitecoreHelper = new SitecoreHelper();
        }
        //This method is for getting the list of destinations
        public async Task<List<Destination>> GetDestinations()
        {
            List<Destination> Destinations = new List<Destination>();
            try
            {
                var sitecoreItems = await _sitecoreHelper.GetItemByPath(
                                Constants.ConstantPath.RepositoryPath,
                                Sitecore.MobileSDK.API.Request.Parameters.PayloadType.Full,
                                new List<Sitecore.MobileSDK.API.Request.Parameters.ScopeType> { Sitecore.MobileSDK.API.Request.Parameters.ScopeType.Children });
                if (sitecoreItems != null)
                    foreach (var item in sitecoreItems)
                    {
                        var Dstn = new Destination
                        {
                            SitecoreID = item.Id,
                            Name = item.GetValueFromField(Constants.Templates.Destination.Fields.DestinationName),
                            Thumbnail = item.GetImageUrlFromMediaField(Constants.Templates.Destination.Fields.Thumbnail, Constants.Settings.ResetBaseUrl)
                        };
                        Destinations.Add(Dstn);
                    }


            }
            catch (Exception ex)
            {
                Log.Error("Error in GetDestinations(),  Error: {0}", ex.Message);
                throw ex;
            }
            return Destinations;
        }

        //Get the sitecore media url
        public async Task<string> GetMediaUrl(string path, string field)
        {
            string mediaUrl = string.Empty;
            try
            {
                var sitecoreItems = await _sitecoreHelper.GetItemByPath(
                              path,
                               Sitecore.MobileSDK.API.Request.Parameters.PayloadType.Full,
                               new List<Sitecore.MobileSDK.API.Request.Parameters.ScopeType> { Sitecore.MobileSDK.API.Request.Parameters.ScopeType.Self });


                if (sitecoreItems != null)
                {


                    mediaUrl = sitecoreItems[0].GetImageUrlFromMediaField(Constants.Settings.BackdropImage, Constants.Settings.ResetBaseUrl);

                }
                return mediaUrl;
            }


            catch (Exception ex)
            {
                Log.Error("GetMediaUrl", ex.Message);
            }
            return mediaUrl;
        }

        //Gets the detail about each destination
        public async Task<Destination> GetTravelDestinationDetail(string id)
        {
            Destination destinationDescription = new Destination();

            try
            {
                var sitecoreItems = await _sitecoreHelper.GetItemById(
                               id,
                                Sitecore.MobileSDK.API.Request.Parameters.PayloadType.Full,
                                new List<Sitecore.MobileSDK.API.Request.Parameters.ScopeType> { Sitecore.MobileSDK.API.Request.Parameters.ScopeType.Self });


                if (sitecoreItems != null)
                {
                    destinationDescription.Description = sitecoreItems[0].GetValueFromField(Constants.Templates.Destination.Fields.Description);
                    destinationDescription.BannerImage = sitecoreItems[0].GetImageUrlFromMediaField(Constants.Templates.Destination.Fields.BannerImage, Constants.Settings.ResetBaseUrl);
                }



            }
            catch (Exception ex)
            {
                Log.Error("Error in GetAlbums(),  Error: {0}", ex.Message);
                throw ex;
            }

            return destinationDescription;
        }
    }
}