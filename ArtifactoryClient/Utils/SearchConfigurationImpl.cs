using System;
using System.Collections.Generic;
using ArtifactoryClient.Interfaces;
using ArtifactoryClient.Models;

namespace ArtifactoryClient.Utils
{
    public class SearchConfigurationImpl : ISearchConfiguration
    {
        public ISearchConfiguration Repositories(params string[] repositories)
        {
            throw new NotImplementedException();
        }

        public ISearchConfiguration GroupId(string groupId)
        {
            throw new NotImplementedException();
        }

        public ISearchConfiguration ArtifactId(string artifactId)
        {
            throw new NotImplementedException();
        }

        public ISearchConfiguration Version(string version)
        {
            throw new NotImplementedException();
        }

        public ISearchConfiguration Classifier(string classifierId)
        {
            throw new NotImplementedException();
        }

        public List<RepositoryPath> Search()
        {
            throw new NotImplementedException();
        }

        public string RawSearch()
        {
            throw new NotImplementedException();
        }
    }
}
