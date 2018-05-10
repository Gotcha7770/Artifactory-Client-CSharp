using NUnit.Framework;
using System;
using ArtifactoryClient.Interfaces;
using ArtifactoryClient.UnitTests.Helpers;
using RestSharp;
using RestSharp.Authenticators;

namespace ArtifactoryClient.UnitTests
{
    [TestFixture]
    public class ArtifactDownloadTests
    {
        private IArtifactory _artifactory;

        [OneTimeSetUp]
        public void InitCommon()
        {
            IRestClient client = new RestClient
            {
                BaseUrl = new Uri(TestConnection.Url + TestConnection.ArtifactorySection),
                Authenticator = new HttpBasicAuthenticator(TestConnection.UserName, TestConnection.Password)
            };

            _artifactory = new ArtifactoryImpl(client);
        }

        [Test]
        public void DownloadArtifactTest()
        {
            string artifactPath = "your/artifact/path";
            IRestResponse response = _artifactory.GetRepository("repositoryName").Download(artifactPath);

            Assert.IsNotNull(response.RawBytes);
        }
    }
}
