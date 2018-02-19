namespace ArtifactoryClient.Interfaces
{
    public interface IRepositoryHandle
    {
        //IItemHandle Folder(string folderName);

        //IItemHandle File(String filePath);

        //IReplicationStatus ReplicationStatus { get; }

        //string Delete();

        //string Delete(string path);

        IRepository Repository { get; }

        //IUploadableArtifact Upload(string targetPath, InputStream content);

        //IUploadableArtifact Upload(string targetPath, IFile content);

        //IUploadableArtifact CopyBySha1(string targetPath, string sha1);

        //IDownloadableArtifact Download(string path);

        //HashSet<IItemPermission> EffectivePermissions { get; }

        //IReplications Replications { get; }

        //bool IsFolder(string path);

        bool Exists { get; }
    }
}
