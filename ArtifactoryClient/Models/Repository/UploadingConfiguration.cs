using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace ArtifactoryClient.Models.Repository
{
    public class UploadingConfiguration
    {
        private readonly IRestClient _restClient;
        private readonly string _path;
        private readonly byte[] _data;
        private readonly Dictionary<string, List<string>> _properties = new Dictionary<string, List<string>>();
        
        public UploadingConfiguration(IRestClient restClient, string path, byte[] data)
        {
            _restClient = restClient;
            _path = path;
            _data = data;
        }

        public UploadingConfiguration WithProperty(string name, string value)
        {
            if (_properties.ContainsKey(name))
            {
                _properties[name].Add(value); 
            }
            else
            {
                _properties[name] = new List<string>{ value };
            }

            return this;
        }

        public UploadingConfiguration WithProperty(string name, string[] values)
        {
            if (_properties.ContainsKey(name))
            {
                _properties[name].AddRange(values);
            }
            else
            {
                _properties[name] = new List<string>(values);
            }

            return this;
        }

        public IRestResponse Run()
        {
            string resource;
            if (_properties.Any())
                resource = _path + ";" + string.Join(";", _properties.Select(x => $"{x.Key}={string.Join(",", x.Value)}"));
            else
                resource = _path;

            string fileName = _path.Split('/').Last();

            IRestRequest request = new RestRequest(resource, Method.PUT);
            request.AddFile(fileName, _data, fileName);

            return  _restClient.Execute(request);
        }
    }
}
