using System.Collections.Generic;
using ArtifactoryClient.Models;

namespace ArtifactoryClient.Interfaces
{
    public interface ISearchConfiguration
    {
        ISearchConfiguration Repositories(params string[] repositories);

        ISearchConfiguration GroupId(string groupId); //id???

        ISearchConfiguration ArtifactId(string artifactId);

        ISearchConfiguration Version(string version);

        ISearchConfiguration Classifier(string classifierId);

        List<RepositoryPath> Search();

        string RawSearch();

        //IPropertyFilters ItemsByProperty();
    }
}
