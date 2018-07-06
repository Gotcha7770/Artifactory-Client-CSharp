using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace ArtifactoryClient.Models.Search
{
    public class QuickSearchConfiguration : BaseSearchConfiguration
    {
        private readonly string _apiBase;
        private Dictionary<string, string> _properties = new Dictionary<string, string>();
        private string[] _repositories;

        public QuickSearchConfiguration(IRestClient restClient)
        {
            RestClient = restClient;
            _apiBase = ArtifactoryBuilder.ApiBase + "/search";
        }

        public QuickSearchConfiguration Repositories(params string[] repositories)
        {
            _repositories = repositories;
            return this;
        }

        public QuickSearchConfiguration WithProperty(string name, string value)
        {
            _properties[name] = value;
            return this;
        }

        public QuickSearchConfiguration WithProperties(Dictionary<string, string> values)
        {
            _properties = values;
            return this;
        }
         
        public NameSearchConfiguration ByName(string name)
        {
            return new NameSearchConfiguration(RestClient, _apiBase, name, _repositories);
        }

        public GAVCSearchConfiguration ArtifactsByGavc()
        {
            return new GAVCSearchConfiguration(RestClient, _apiBase, _repositories);
        }

        public DateRangeSearchConfiguration ArtifactsCreatedInDateRange()
        {
            return new DateRangeSearchConfiguration(RestClient, _apiBase, _repositories);
        }

        protected override string GetResource()
        {
            string resource = _apiBase + "/prop?";

            if (_properties?.Any() ?? false)
            {
                var conditions = _properties.Select(kvp => kvp.Key + "=" + kvp.Value);
                resource += string.Join("&", conditions);
            }

            if (_repositories?.Any() ?? false)
                resource += "&repos=" + string.Join(",", _repositories);

            return resource;
        }
    }
}
