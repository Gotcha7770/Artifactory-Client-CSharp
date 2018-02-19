using System;
using RestSharp;

namespace ArtifactoryClient.Interfaces
{
    public interface IArtifactory : IDisposable
    {
        string Uri { get; }

        string ContextName { get; }

        string UserAgent { get; }

        IRepositories Repositories { get; }

        IRepositoryHandle GetRepository(string repo);

        ISearches Searches { get; }

        //ISecurity Security { get; }

        //IStorage Storage { get; }

        //IPlugins Plugins { get; }

        //IArtifactorySystem System { get; }

        IRestResponse RestCall(IRestRequest request);
    }
}
