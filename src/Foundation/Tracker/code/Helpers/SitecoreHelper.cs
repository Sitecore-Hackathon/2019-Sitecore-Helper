using System;
using System.Collections.Generic;
using Android.Util;
using Sitecore.MobileSDK.API;
using Sitecore.MobileSDK.API.Exceptions;
using Sitecore.MobileSDK.API.Items;
using Sitecore.MobileSDK.API.Request;
using Sitecore.MobileSDK.API.Request.Parameters;
using Sitecore.MobileSDK.API.Session;
using Sitecore.MobileSDK.PasswordProvider;
using System.Threading.Tasks;

namespace Sitecore.Foundation.Tracker.Helpers
{
    public class SitecoreHelper
    {
        //gets the item or child item on specifying the path
        public async Task<ScItemsResponse> GetItemByPath(string itemPath, PayloadType itemLoadType, List<ScopeType> itemScopeTypes, string itemLanguage = "en")
        {
            try
            {
                using (ISitecoreWebApiSession session = GetSession())
                {
                    IReadItemsByPathRequest request = ItemWebApiRequestBuilder.ReadItemsRequestWithPath(itemPath).Payload(itemLoadType).AddScope(itemScopeTypes).Language(itemLanguage).Build();
                    var response = await session.ReadItemAsync(request);
                    return await session.ReadItemAsync(request);
                }


            }
            catch (SitecoreMobileSdkException ex)
            {
                Log.Error("Error in GetItemByPath, id{0}. Error{1}", itemPath, ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Log.Error("Error in GetItemByPath, id{0}. Error{1}", itemPath, ex.Message);
                throw ex;
            }
        }


        //gets the item or child item on specifying the id
        public async Task<ScItemsResponse> GetItemById(string itemId, PayloadType itemLoadType, List<ScopeType> itemScopeTypes, string itemLanguage = "en")
        {
            try
            {
                using (ISitecoreWebApiSession session = GetSession())

                {
                    IReadItemsByIdRequest request = ItemWebApiRequestBuilder.ReadItemsRequestWithId(itemId).Payload(itemLoadType).AddScope(itemScopeTypes).Language(itemLanguage).Build();
                    return await session.ReadItemAsync(request);
                }

            }
            catch (SitecoreMobileSdkException ex)
            {
                Log.Error("Error in GetItemByPath, id{0}. Error{1}", itemId, ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Log.Error("Error in GetItemByPath, id{0}. Error{1}", itemId, ex.Message);
                throw ex;
            }
        }

        //for configuring the session with sitecore
        private ISitecoreWebApiSession GetSession(string userName = "", string password = "")
        {

            if (string.IsNullOrEmpty(userName))
            {
                userName = Constants.Settings.SitecoreUserName;
                password = Constants.Settings.SitecorePassword;
            }

            using (var credentials = new SecureStringPasswordProvider(userName, password))
            {

                ISitecoreWebApiSession session = SitecoreWebApiSessionBuilder.AuthenticatedSessionWithHost(Constants.Settings.ResetBaseUrl)
                .Credentials(credentials)
                .WebApiVersion("v1")
                .DefaultDatabase(Constants.Settings.SitecoreDefaultDatabase)
                .DefaultLanguage(Constants.Settings.SitecoreDefaultLanguage)
                .MediaLibraryRoot(Constants.Settings.SitecoreMediaLibraryRoot)
                .MediaPrefix(Constants.Settings.SitecoreMediaPrefix)
                .DefaultMediaResourceExtension(Constants.Settings.SitecoreDefaultMediaResourceExtension)
                .BuildSession();
                return session;
            }
        }
        //gets the item or child item on specifying the query
        public async Task<ScItemsResponse> GetItemByQuery(string query, string itemLanguage = "en")
        {
            try
            {
                using (ISitecoreWebApiSession session = GetSession())

                {
                    IReadItemsByQueryRequest request = ItemWebApiRequestBuilder.ReadItemsRequestWithSitecoreQuery(query).Language(itemLanguage).Build();
                    return await session.ReadItemAsync(request);
                }

            }
            catch (SitecoreMobileSdkException ex)
            {
                Log.Error("Error in GetItemByQuery, id{0}. Error{1}", query, ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Log.Error("Error in GetItemByQuery, id{0}. Error{1}", query, ex.Message);
                throw ex;
            }
        }

    }
}