using System;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpHelper.OAuth1;

namespace RestSharpHelper
{
    public class ClientBuilder
    {
        //public static Func<string, IRestClient> Build { get; set; }

        public static Func<string, IAuthenticator, IRestClient> Build { get; set; }

        static ClientBuilder()
        {
            Build = (url, auth) => new RestClient(options: new RestClientOptions(url)
            {
                Authenticator = auth
            });
        }
    }
}
