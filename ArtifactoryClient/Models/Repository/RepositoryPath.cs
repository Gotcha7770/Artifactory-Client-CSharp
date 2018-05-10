namespace ArtifactoryClient.Models.Repository
{
    public class RepositoryPath
    {
        public string RepositoryKey { get; }

        public string ItemPath { get; }

        public RepositoryPath(string repositoryKey, string itemPath)
        {
            RepositoryKey = repositoryKey;
            ItemPath = itemPath;
        }

        public bool Equals(RepositoryPath other)
        {
            return ItemPath == other.ItemPath && RepositoryKey == other.RepositoryKey;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is RepositoryPath path && Equals(path);
        }

        public override int GetHashCode()
        {
            int result = RepositoryKey.GetHashCode();
            result = 31 * result + ItemPath.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            return "RepoPathImpl{" +
                       $"repoKey='{RepositoryKey}', " +
                       $"itemPath='{ItemPath}'" +
                   "}";
        }
    }
}
