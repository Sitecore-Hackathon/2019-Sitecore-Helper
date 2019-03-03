using Android.Util;
using Sitecore.Foundation.Tracker.Extensions;
using Sitecore.Foundation.Tracker.Helpers;
using Sitecore.Foundation.Tracker.Models;
using Sitecore.UniversalTrackerClient.Entities;
using Sitecore.UniversalTrackerClient.Request.RequestBuilder;
using Sitecore.UniversalTrackerClient.Session.SessionBuilder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sitecore.Foundation.Tracker.UT
{
    public class RegisterInteractions
    {
        private readonly SitecoreHelper _sitecoreHelper;
        public RegisterInteractions()
        {
            _sitecoreHelper = new SitecoreHelper();

        }

        //In this method we are tracking the user and collecting the data in Universal tracker DB. After collection data is processed
        //using processing service and push to xDB
        public async Task<TrackerSettings> GetTrackerSettings()
        {
            string trackerSettingsFullPath = string.Empty;
            string query = string.Empty;
            query = Constants.Settings.TrackerItemPath;

            TrackerSettings ts = new TrackerSettings();

            var trackerSettingsItemPath = await _sitecoreHelper.GetItemByPath(query, Sitecore.MobileSDK.API.Request.Parameters.PayloadType.Full,
                                new List<Sitecore.MobileSDK.API.Request.Parameters.ScopeType> { Sitecore.MobileSDK.API.Request.Parameters.ScopeType.Self });
            if (trackerSettingsItemPath != null)
            {
                ts.ServiceURL = trackerSettingsItemPath[0].GetValueFromField(Templates.TrackerSettings.Fields.ServiceURL);
                ts.ChannelID = trackerSettingsItemPath[0].GetValueFromField(Templates.TrackerSettings.Fields.Channel);
                ts.Event = trackerSettingsItemPath[0].GetValueFromField(Templates.TrackerSettings.Fields.Event);
                ts.Goals = trackerSettingsItemPath[0].GetValueFromField(Templates.TrackerSettings.Fields.Goal);
                if (trackerSettingsItemPath[0].GetValueFromField(Templates.TrackerSettings.Fields.IsTrackingActive).Equals("1"))
                {
                    ts.IsTrackingActive = true;
                }
                else
                {
                    ts.IsTrackingActive = false;
                }
            }
            return ts;
        }
        public async void Register()
        {
            try
            {
                RegisterInteractions ri = new RegisterInteractions();
                TrackerSettings trackerSettings = await ri.GetTrackerSettings();
                if (trackerSettings.IsTrackingActive)
                {
                    string instanceUrl = trackerSettings.ServiceURL;//Collection service url
                    string channelId = trackerSettings.ChannelID; //channel id must be add in config.json
                    string eventDefinitionId = trackerSettings.Event;//event id
                    string goalDefinitionId = trackerSettings.Goals;//goal id
                    var defaultInteraction = UTEntitiesBuilder.Interaction()
                                            .ChannelId(channelId)
                                            .Initiator(InteractionInitiator.Contact)
                                            .Contact("MobileAPP", "Anonymous")
                                            .Build();

                    using (var session = SitecoreUTSessionBuilder.SessionWithHost(instanceUrl)
                                        .DefaultInteraction(defaultInteraction)
                                        .BuildSession()
                            )
                    {
                        //trigerring the event
                        var eventRequest = UTRequestBuilder.EventWithDefenitionId(eventDefinitionId)
                                            .AddCustomValues("MobileAppUniversalTraker", "10")
                                            .Timestamp(DateTime.Now)
                                            .Build();
                        var eventResponse = await session.TrackEventAsync(eventRequest);
                        //Triggering the goal
                        var goalRequest = UTRequestBuilder.GoalEvent(goalDefinitionId, DateTime.Now).Build();
                        var goalResponse = await session.TrackGoalAsync(goalRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error occurred in Regitser methos of RegisterInteraction",ex.Message);
            }
        }

    }
}