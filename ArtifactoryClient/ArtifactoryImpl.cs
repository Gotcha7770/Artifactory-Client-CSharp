using System;
using ArtifactoryClient.Interfaces;
using ArtifactoryClient.Models;
using ArtifactoryClient.Utils;
using RestSharp;
using RestSharp.Authenticators;

namespace ArtifactoryClient
{
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

        public string Uri => RestClient.BaseUrl.ToString();

        public string ContextName { get; } //???

        public string UserAgent => RestClient.UserAgent;

        public IRepositories Repositories => new RepositoriesImpl(RestClient, ArtifactoryBuilder.ApiBase);

        public IRepositoryHandle GetRepository(string repo)
        {
            if (string.IsNullOrEmpty(repo))
                throw new ArgumentException(nameof(repo));

            return Repositories.Repository(repo);
        }

        public ISearches Searches => new SearchesImpl(RestClient, ArtifactoryBuilder.ApiBase);

        public IRestResponse RestCall(IRestRequest request)
        {
            return RestClient.Execute(request);
        }

        public void Dispose()
        { }

        #endregion


    }
}
