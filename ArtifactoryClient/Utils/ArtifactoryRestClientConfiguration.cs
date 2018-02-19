using System;
using System.Net;
using ArtifactoryClient.Interfaces;
using RestSharp;
using RestSharp.Authenticators;

namespace ArtifactoryClient.Utils
{
    public class ArtifactoryRestClientConfiguration
    {
        protected IRestClient RestClient;

        public ArtifactoryRestClientConfiguration(IRestClient restClient, IAuthenticator authenticator, string url, string userAgent)
        {
            RestClient = restClient;

            if (RestClient.Authenticator == null)
                RestClient.Authenticator = authenticator;

            if(RestClient.BaseUrl == null)
                RestClient.BaseUrl = new Uri(url);

            if(string.IsNullOrEmpty(RestClient.UserAgent))
                RestClient.UserAgent = userAgent;
        }
        
        public ArtifactoryRestClientConfiguration SetAuthentificator(IAuthenticator authenticator)
        {
            RestClient.Authenticator = authenticator;
            return this;
        }

        public ArtifactoryRestClientConfiguration SetUrl(string url)
        {
            RestClient.BaseUrl = new Uri(url);
            return this;
        }

        public ArtifactoryRestClientConfiguration SetUserAgent(string userAgent)
        {
            RestClient.UserAgent = userAgent;
            return this;
        }

        public virtual ArtifactoryRestClientConfiguration SetProxy(IWebProxy proxy)
        {
            RestClient.Proxy = proxy;
            return this;
        }

        public IArtifactory Build()
        {
            IArtifactory artifactory = new ArtifactoryImpl(RestClient);

            return artifactory;
        }
    }
}