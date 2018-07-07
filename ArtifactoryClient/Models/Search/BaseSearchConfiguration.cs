using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace ArtifactoryClient.Models.Search
{
    /// <summary>
    /// This flags set additional information that can be added to response.
    /// You can combine <see cref="Info"/> and <see cref="Properties"/> to recieve
    /// all available extra information
    /// </summary>
    [Flags]
    public enum ResponseOptions
    {
        /// <summary>
        /// Without any additional info
        /// </summary>
        None = 0x0,

        /// <summary>
        /// To add extra information of the founded artifact
        /// </summary>
        Info = 0x1,

        /// <summary>
        /// To get the properties of the founded artifact
        /// </summary>
        Properties = 0x2
    }

    /// <summary>
    /// Base search configuration class,
    /// contains startup methods
    /// </summary>
    public abstract class BaseSearchConfiguration
    {
        /// <summary>
        /// REST Http client to communicate with artifactory service
        /// </summary>
        protected IRestClient RestClient;

        /// <summary>
        /// Response options
        /// </summary>
        protected ResponseOptions Options;

        /// <summary>
        /// Set response options
        /// </summary>
        public virtual BaseSearchConfiguration WithOptions(ResponseOptions options)
        {
            Options = options;
            return this;
        }

        /// <summary>
        /// Obtaining resource url method
        /// </summary>
        /// <returns></returns>
        protected abstract string GetResource();

        /// <summary>
        /// Search start method
        /// </summary>
        public virtual ArtifactslList Run()
        {
            IRestRequest request = new RestRequest(GetResource());
            string headerValue = Options.ToString().ToLower();
            request.AddHeader(ArtifactoryBuilder.DetailHeaderName, headerValue);

            IRestResponse response = RestClient.Get(request);

            HttpStatusCode status = response.StatusCode;
            if (status != HttpStatusCode.OK
                && status != HttpStatusCode.NoContent
                && status != HttpStatusCode.Accepted)
            {
                return new ArtifactslList { Response = response };
            }

            var artifacts =  JsonConvert.DeserializeObject<ArtifactslList>(response.Content);
            artifacts.Response = response;

            return artifacts;
        }

        /// <summary>
        /// Async search start method
        /// </summary>
        public Task<ArtifactslList> RunAsync()
        {
            return Task<ArtifactslList>.Factory.StartNew(Run);
        }
    }
}
