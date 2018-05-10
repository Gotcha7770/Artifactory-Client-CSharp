using System.Linq;
using RestSharp;

namespace ArtifactoryClient.Models.Search
{
    public class GAVCSearchConfiguration: BaseSearchConfiguration
    {
        private readonly string _apiBase;
        private readonly string[] _repositories;
        private string _groupId;
        private string _artifactId;
        private string _version;
        private string _classifier;
        

        public GAVCSearchConfiguration(IRestClient restClient, string apiBase, string[] repositories)
        {
            RestClient = restClient;
            _apiBase = apiBase + "/gavc?";
            _repositories = repositories;
        }

        public GAVCSearchConfiguration GroupId(string groupId)
        {
            _groupId = groupId;
            return this;
        }

        public GAVCSearchConfiguration ArtifactId(string artifactId)
        {
            _artifactId = artifactId;
            return this;
        }

        public GAVCSearchConfiguration Version(string version)
        {
            _version = version;
            return this;
        }

        public GAVCSearchConfiguration Classifier(string classifier)
        {
            _classifier = classifier;
            return this;
        }

        protected override string GetResource()
        {
            string resource = _apiBase + $"g={_groupId}&a={_artifactId}&v={_version}&c={_classifier}";

            if (_repositories?.Any() ?? false)
                resource += "&repos=" + string.Join(",", _repositories);

            return resource;
        }
    }
}
