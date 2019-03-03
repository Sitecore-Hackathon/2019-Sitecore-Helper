using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.Tracker
{
    public class Constants
    {
        public struct TrackerSettings
        {
            public const string TrackerSettingsFolderTemplateID = "{F38AC661-FE5C-4523-AE08-4B3EDC57AE72}";
            public const string TrackerSettingsItemTemplateID = "{E144AAC6-7B4D-4352-80CD-F097F427E667}";

        }
        public struct Settings
        {
            // This is Sitecore 9 instance url. we are fetching data from this instance. Please change it according to your instnace name
            public const string ResetBaseUrl = "http://sc91.local";
            public const string SitecoreUserName = "admin";
            public const string SitecorePassword = "b";
            public const string SitecoreShellSite = "/sitecore/shell";
            public const string SitecoreDefaultDatabase = "web";
            public const string SitecoreDefaultLanguage = "en";
            public const string SitecoreMediaLibraryRoot = "/sitecore/media library";
            public const string SitecoreMediaPrefix = "~/media/";
            public const string SitecoreDefaultMediaResourceExtension = "ashx";
       

        }
    }
}