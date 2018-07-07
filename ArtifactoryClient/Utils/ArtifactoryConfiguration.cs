using System;
using System.Net;
using ArtifactoryClient.Interfaces;
using RestSharp;
using RestSharp.Authenticators;

namespace ArtifactoryClient.Utils
{
    //public interface IArtifactoryConfiguration
    //{
    //    IArtifactoryConfiguration SetRestClient(IRestClient restClient);
    //    IArtifactoryConfiguration SetAuthentificator(IAuthenticator authenticator);
    //    IArtifactoryConfiguration SetUserName(string username);
    //    IArtifactoryConfiguration SetPassword(string password);
    //    IArtifactoryConfiguration SetUrl(string url);
    //    IArtifactoryConfiguration SetUserAgent(string userAgent);
    //    IArtifactoryConfiguration SetProxy(IWebProxy proxy);
    //    IArtifactory Build();
    //}

    public class ArtifactoryConfiguration
    {
        protected string UserName;
        protected string Password;
        protected string Url;
        protected string UserAgent;
        protected IWebProxy Proxy; 

        //bool IgnoreSSLIssues???
        //string AccessToken - Authentificator
        //connectionTimeOut - Timeout // ReadWriteTimeout

        public virtual ArtifactoryRestClientConfiguration SetRestClient(IRestClient restClient)
        {
            if (restClient == null) throw new ArgumentNullException(nameof(restClient));

            var authenticator = new HttpBasicAuthenticator(UserName, Password);
            return new ArtifactoryRestClientConfiguration(restClient, authenticator, Url, UserAgent);
        }

        public virtual ArtifactoryAuthentificatorConfiguration SetAuthentificator(IAuthenticator authenticator)
        {
            if(authenticator == null) throw new ArgumentNullException(nameof(authenticator));

            return new ArtifactoryAuthentificatorConfiguration(authenticator, Url, UserAgent);
        }

        public virtual ArtifactoryConfiguration SetUserName(string username)
        {
            UserName = username;
            return this;
        }

        public virtual ArtifactoryConfiguration SetPassword(string password)
        {
            Password = password;
            return this;
        }

        public virtual ArtifactoryConfiguration SetUrl(string url)
        {
            //Url может быть только HHTP/HTTPS???
            //проверка???
            Url = url;
            return this;
        }

        public virtual ArtifactoryConfiguration SetUserAgent(string userAgent)
        {
            UserAgent = userAgent;
            return this;
        }

        public virtual ArtifactoryConfiguration SetProxy(IWebProxy proxy)
        {
            Proxy = proxy;
            return this;
        }

        public virtual IArtifactory Build()
        {
            IRestClient restClient = new RestClient
            {
                BaseUrl = new Uri(Url + "artifactory/"),
                Authenticator = new HttpBasicAuthenticator(UserName, Password),
                UserAgent = UserAgent ?? ArtifactoryBuilder.DefaultUserAgent,
                Proxy = this.Proxy
            };

            IArtifactory artifactory = new ArtifactoryImpl(restClient);

            return artifactory;
        }
    }
}
