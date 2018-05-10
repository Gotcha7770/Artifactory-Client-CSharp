using ArtifactoryClient.Models.Repository;
using RestSharp;

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
        IRestResponse Download(string path);

        UploadingConfiguration Upload(string path, byte[] data);
    }
}
