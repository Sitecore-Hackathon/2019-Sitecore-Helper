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
        public async Task<TrackerSettings> GetTrackerSettings()
        {
            string trackerSettingsFullPath = string.Empty;
            string query = string.Empty;
            query = "/sitecore/system/Settings/Foundation/Tracker/Tracker Setting Items/Tracker Settings Mobile App";

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
                    string instanceUrl = trackerSettings.ServiceURL;
                    string channelId = trackerSettings.ChannelID;
                    string eventDefinitionId = trackerSettings.Event;
                    string goalDefinitionId = trackerSettings.Goals;
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

                        var eventRequest = UTRequestBuilder.EventWithDefenitionId(eventDefinitionId)
                                            .AddCustomValues("MobileAppUniversalTraker", "10")
                                            .Timestamp(DateTime.Now)
                                            .Build();
                        var eventResponse = await session.TrackEventAsync(eventRequest);

                        var goalRequest = UTRequestBuilder.GoalEvent(goalDefinitionId, DateTime.Now).Build();
                        var goalResponse = await session.TrackGoalAsync(goalRequest);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}