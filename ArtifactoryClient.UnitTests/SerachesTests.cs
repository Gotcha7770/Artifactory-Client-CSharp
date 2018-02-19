using ArtifactoryClient.Interfaces;
using NUnit.Framework;
using RestSharp;

namespace ArtifactoryClient.UnitTests
{
    [TestFixture]
    public class SerachesTests
    {
        private IRestClient _restClient;
        
        [OneTimeSetUp]
        public void InitCommon()
        {
            _restClient = new RestClient();
        }

        [Test]
        public void Usage()
        {
            IArtifactory artifactory = new ArtifactoryImpl(_restClient);
        }
    }
}