using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArtifactoryClient.Interfaces;
using ArtifactoryClient.Models;
using ArtifactoryClient.Models.Search;
using ArtifactoryClient.UnitTests.Helpers;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;

namespace ArtifactoryClient.UnitTests
{
    [TestFixture]
    public class ArtifactUploadTests
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
        public void UploadArtifactTest()
        {
            byte[] bytes = File.ReadAllBytes("some/file/path");

            IRestResponse response = _artifactory.GetRepository("repositoryName")
                .Upload("artifactName/artifactName.1.0.3.ext", bytes)
                .WithProperty("name", "artifactName")
                .WithProperty("version", "1.0.3")
                .WithProperty("dependencies", new[] { "dep1", "dep2" })
                .Run();

            Assert.IsTrue(response.IsSuccessful);

            IList<Artifact> artifacts = _artifactory.Search()
                .Repositories("repositoryName")
                .ByName("test.zip")
                .WithOptions(ResponseOptions.Properties)
                .Run();

            Assert.IsNotEmpty(artifacts);
            Assert.IsTrue(artifacts.First().Properties.ContainsKey("name"));
            Assert.IsTrue(artifacts.First().Properties["name"].SequenceEqual(new [] { "test" }));
        }
    }
}
