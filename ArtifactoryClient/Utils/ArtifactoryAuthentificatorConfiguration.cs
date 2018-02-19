using System;
using System.Net;
using ArtifactoryClient.Interfaces;
using RestSharp;
using RestSharp.Authenticators;

namespace ArtifactoryClient.Utils
{
    public class ArtifactoryAuthentificatorConfiguration 
    {
        protected IAuthenticator Authenticator;
        protected string Url;
        protected string UserAgent;
        protected IWebProxy Proxy;

        public ArtifactoryAuthentificatorConfiguration(IAuthenticator authenticator, string url, string userAgent)
        {
            Authenticator = authenticator;
            Url = url;
            UserAgent = userAgent;
        }
        
        public virtual ArtifactoryAuthentificatorConfiguration SetUrl(string url)
        {
            Url = url;
            return this;
        }

        public virtual ArtifactoryAuthentificatorConfiguration SetUserAgent(string userAgent)
        {
            UserAgent = userAgent;
            return this;
        }

        public virtual ArtifactoryAuthentificatorConfiguration SetProxy(IWebProxy proxy)
        {
            Proxy = proxy;
            return this;
        }

        public IArtifactory Build()
        {
            IRestClient restClient = new RestClient
            {
                BaseUrl = new Uri(Url),
                Authenticator = this.Authenticator,
                UserAgent = this.UserAgent,
                Proxy = this.Proxy
            };

            IArtifactory artifactory = new ArtifactoryImpl(restClient);

            return artifactory;
        }
    }
}