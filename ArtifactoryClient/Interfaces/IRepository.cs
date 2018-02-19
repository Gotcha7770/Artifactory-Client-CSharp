using System.Collections.Generic;

namespace ArtifactoryClient.Interfaces
{
    public enum RepositoryType
    {
        Unknown,
        Local,
        Remote,
        Vitrual
    }

    public interface IRepository
    {
        //String MAVEN_2_REPO_LAYOUT = "maven-2-default";

        string Key { get; }

        RepositoryType Type { get; }

        string Description { get; }

        string Notes { get; }

        string GetIncludesPattern();

        string GetExcludesPattern();

        string GetRepoLayoutRef();

        //IRepositorySettings GetRepositorySettings();

        //IXraySettings GetXraySettings();

        Dictionary<string, object> GetCustomProperties();
    }
}
