using ArtifactoryClient.Interfaces;
using RestSharp;

namespace ArtifactoryClient.Models.Repository
{
    public class RepositoriyImpl : IRepository
    {
        private IRestClient _restClient;
        private string _repo;

        public RepositoriyImpl(IRestClient restClient, string repo)
        {
            _restClient = restClient;
            _repo = repo;
        }

        public IRestResponse Download(string path)
        {
            IRestRequest request = new RestRequest(_repo + "/" + path);
            return _restClient.Get(request);
        }

        public UploadingConfiguration Upload(string path, byte[] data)
        {
            return new UploadingConfiguration(_restClient, _repo + "/" + path, data);
        }
    }
}
