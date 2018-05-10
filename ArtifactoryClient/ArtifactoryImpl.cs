using System;
using ArtifactoryClient.Interfaces;
using ArtifactoryClient.Models.Repository;
using ArtifactoryClient.Models.Search;
using RestSharp;
using RestSharp.Authenticators;

namespace ArtifactoryClient
{
    /// <summary>
    /// REST client for JFrog Artifactory service
    /// </summary>
    public class ArtifactoryImpl : IArtifactory
    {
        public IRestClient RestClient { get; }

        #region Costructors

        public ArtifactoryImpl(string url, string userName, string password)
        {
            //проверка url???
            RestClient = new RestClient
            {
                BaseUrl = new Uri(url),
                Authenticator = new HttpBasicAuthenticator(userName, password)
            };
        }

        public ArtifactoryImpl(IRestClient restClient)
        {
            RestClient = restClient;
        }

        #endregion

        #region Interface Implementation

        public Uri Uri => RestClient.BaseUrl;
        
        public string UserAgent => RestClient.UserAgent;

        public IRepositories Repositories => new RepositoriesImpl(RestClient);

        public IRepository GetRepository(string repo)
        {
            if (string.IsNullOrEmpty(repo))
                throw new ArgumentNullException(nameof(repo));

            return Repositories.Repository(repo);
        }

        public QuickSearchConfiguration Search() => new QuickSearchConfiguration(RestClient);

        public IRestResponse RestCall(IRestRequest request)
        {
            return RestClient.Execute(request);
        }

        public void Dispose()
        { }

        #endregion

    }
}
