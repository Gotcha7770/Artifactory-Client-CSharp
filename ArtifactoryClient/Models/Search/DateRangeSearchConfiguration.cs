using System;
using System.Linq;
using ArtifactoryClient.Utils;
using RestSharp;

namespace ArtifactoryClient.Models.Search
{
    public class DateRangeSearchConfiguration: BaseSearchConfiguration
    {
        private readonly string _apiBase;
        private  readonly string[] _repositories;
        private DateTime _from;
        private DateTime _to;

        public DateRangeSearchConfiguration(IRestClient restClient, string apiBase, string[] repositories)
        {
            RestClient = restClient;
            _apiBase = apiBase + "/creation?";
            _repositories = repositories;
        }

        public DateRangeSearchConfiguration From(DateTime from)
        {
            _from = from;
            return this;
        }

        public DateRangeSearchConfiguration To(DateTime to)
        {
            _to = to;
            return this;
        }

        protected override string GetResource()
        {
            string resource = _apiBase + $"from={_from.ToUnixStamp() * 1000}&to={_to.ToUnixStamp() * 1000}";
            
            if (_repositories?.Any() ?? false)
                resource += "&repos=" + string.Join(",", _repositories);

            return resource;
        }
    }
}