using System;
using ArtifactoryClient.Interfaces;
using RestSharp;

namespace ArtifactoryClient.Models
{
    public class RepositoriesImpl : IRepositories
    {
        private IRestClient _restClient;
        private string _apiBase;

        public RepositoriesImpl(IRestClient restClient, string apiBase)
        {
            _restClient = restClient;
            _apiBase = apiBase;
        }

        public string Create(int position, IRepository configuration)
        {
            throw new NotImplementedException();
        }

        public string Update(IRepository configuration)
        {
            throw new NotImplementedException();
        }

        public IRepositoryHandle Repository(string repo)
        {
            throw new NotImplementedException();
        }

        public IRepositoryHandle Builders()
        {
            throw new NotImplementedException();
        }

        public string RepositoriesApi { get; }

        public string ReplicationApi { get; }
    }
}
