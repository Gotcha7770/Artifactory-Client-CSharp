using System;
using ArtifactoryClient.Interfaces;
using RestSharp;

namespace ArtifactoryClient.Utils
{
    public class SearchesImpl : ISearches
    {
        private IRestClient _restClient;
        private string _apiBase;

        public SearchesImpl(IRestClient restClient, string apiBase)
        {
            _restClient = restClient;
            _apiBase = apiBase;
        }

        public ISearchConfiguration ArtifactsByName(string name)
        {
            throw new NotImplementedException();
        }

        public ISearchConfiguration ArtifactsCreatedSince(long sinceMillis)
        {
            throw new NotImplementedException();
        }

        public ISearchConfiguration ArtifactsCreatedInDateRange(long fromMillis, long toMillis)
        {
            throw new NotImplementedException();
        }

        public ISearchConfiguration ArtifactsByGavc()
        {
            throw new NotImplementedException();
        }

        public ISearchConfiguration ArtifactsLatestVersion()
        {
            throw new NotImplementedException();
        }
    }
}
