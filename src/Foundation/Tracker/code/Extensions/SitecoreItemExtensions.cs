using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Sitecore.MobileSDK.API.Items;

namespace Sitecore.Foundation.Tracker.Extensions
{
    public static class SitecoreItemExtensions
    {
        //Gets the value from field
        public static string GetValueFromField(this ISitecoreItem item, string fieldName)
        {
            if (item == null) return string.Empty;

            if (!item.Fields.Any(s => s.Name == fieldName))
                return string.Empty;

            return item[fieldName].RawValue;
        }

        //Gets the image url from media field
        public static string GetImageUrlFromMediaField(this ISitecoreItem item, string mediafieldName,
                                                       string websiteUrl = null)
        {
            XElement xmlElement = GetXElement(item, mediafieldName);
            if (xmlElement == null)
                return string.Empty;

            XAttribute attribute = xmlElement
                .Attributes()
                .FirstOrDefault(attr => attr.Name == "mediaid" || attr.Name == "id");

            if (attribute == null)
                return string.Empty;

            string mediaId = attribute.Value;

            Guid id = Guid.Parse(mediaId);

            if (string.IsNullOrWhiteSpace(websiteUrl))
                return String.Format("-/media/{0}", id.ToString("N"));

            return String.Format("{0}/-/media/{1}", websiteUrl, id.ToString("N"));
        }

        private static XElement GetXElement(this ISitecoreItem item, string fieldName)
        {
            if (item == null)
                return null;


            if (item.Fields.All(f => f.Name != fieldName))
                return null;

            string fieldValue = item[fieldName].RawValue;

            if (string.IsNullOrWhiteSpace(fieldValue))
                return null;

            return XElement.Parse(fieldValue);
        }

      
    }
}
