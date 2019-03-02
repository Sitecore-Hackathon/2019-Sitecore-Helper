using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Foundation.Orm.Models
{
    public interface IGlassBase
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [SitecoreId]
        Guid Id { get; }

        [SitecoreItem]
        Item Item { get; set; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.Language)]
        Language Language { get; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.Version)]
        int Version { get; }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.Url)]
        string Url { get; }

        /// <summary>
        /// Gets the name of the template.
        /// </summary>
        /// <value>
        /// The name of the template.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        string TemplateName { get; }

        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        Guid TemplateId { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.Name)]
        string Name { get; }
        [SitecoreField("__Display name")]
        string DisplayName { get; set; }

    }
}
