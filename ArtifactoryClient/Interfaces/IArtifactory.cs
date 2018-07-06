using System;
using ArtifactoryClient.Models.Search;
using RestSharp;

namespace ArtifactoryClient.Interfaces
{
    public interface IArtifactory : IDisposable
    {
        Uri Uri { get; }
        
        string UserAgent { get; }

        IRepositories Repositories { get; }

        IRepository GetRepository(string repo);

        QuickSearchConfiguration Search();

        IRestResponse RestCall(IRestRequest request);
    }
}
