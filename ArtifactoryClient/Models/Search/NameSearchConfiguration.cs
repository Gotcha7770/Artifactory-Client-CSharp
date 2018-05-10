using System.Linq;
using RestSharp;

namespace ArtifactoryClient.Models.Search
{
    /// <summary>
    /// Configuration for Artifact search by part of file name
    /// </summary>
    public class NameSearchConfiguration : BaseSearchConfiguration
    {
        private readonly string _apiBase;
        private readonly string _name;
        private readonly string[] _repositories;

        public NameSearchConfiguration(IRestClient restClient, string apiBase, string name, string[] repositories)
        {
            RestClient = restClient;
            _apiBase = apiBase + "/artifact?";
            _name = name;
            _repositories = repositories;
        }

        protected override string GetResource()
        {
            string resource = _apiBase + $"name={_name}";

            if (_repositories?.Any() ?? false)
                resource += "&repos=" + string.Join(",", _repositories);

            return resource;
        }
    }
}
