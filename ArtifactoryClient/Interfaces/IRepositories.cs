namespace ArtifactoryClient.Interfaces
{
    public interface IRepositories
    {
        string Create(int position, IRepository configuration);

        string Update(IRepository configuration);

        IRepositoryHandle Repository(string repo);

        IRepositoryHandle Builders();

        //List<ILightweightRepository> List(RepositoryType repositoryType);

        string RepositoriesApi { get; }

        string ReplicationApi { get; }
    }
}
