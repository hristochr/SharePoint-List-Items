using Microsoft.SharePoint.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Security;

namespace SpListItems
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://yoursite.sharepoint.com/sites/xxxxxxxxxxxx";
            string userName = "me@me.com";
            string pwd = "your password";
            SecureString secureString = new SecureString();
            foreach (char c in pwd.ToCharArray())
            {
                secureString.AppendChar(c);
            }
            SharePointOnlineCredentials credentials = new SharePointOnlineCredentials(userName, secureString);
            JToken jToken = GetList(new Uri(url), credentials, "List title");
            Console.WriteLine(jToken["results"]);
            Console.ReadLine();
        }
        public static JToken GetList(Uri webUri, ICredentials credentials, string listTitle)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
                client.Credentials = credentials;
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json;odata=verbose");
                client.Headers.Add(HttpRequestHeader.Accept, "application/json;odata=verbose");
                Uri endpointUri = new Uri(webUri + "/_api/web/lists/getbytitle('" + listTitle + "')/items");
                string result = client.DownloadString(endpointUri); 

                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                JToken jToken = jo["d"];
                return jToken;
            }
        }
    }
}
