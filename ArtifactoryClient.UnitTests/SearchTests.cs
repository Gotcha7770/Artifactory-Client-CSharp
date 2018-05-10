using System;
using System.Collections.Generic;
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
    public class SearchTests
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
        public void QuickSearchTest()
        {
            IList<Artifact> artifacts = _artifactory.Search()
                .Repositories("repositoryName", "anotherRepositoryName")
                .ByName("*.zip")
                .Run();

            Assert.IsNotEmpty(artifacts);
        }

        [Test]
        public void PropertiesSearchTest()
        {
            IList<Artifact> artifacts = _artifactory.Search()
                .Repositories("repositoryName")
                .WithProperty("name", "")
                .WithProperty("version", "")
                .WithOptions(ResponseOptions.Properties|ResponseOptions.Info)
                .Run();

            Assert.IsNotEmpty(artifacts);
        }

        [Test]
        public void GAVCSearchTest()
        {
            //нет возможности проверить!!!
            IList<Artifact> artifacts = _artifactory.Search()
                .ArtifactsByGavc()
                .GroupId("groupId")
                .ArtifactId("artifactId")
                .Version("0.0.1")
                .Classifier("someClass")
                .WithOptions(ResponseOptions.Properties)
                .Run();

            Assert.IsNotEmpty(artifacts);
        }

        [Test]
        public void CreationPeriodSearchTest()
        {
            IList<Artifact> artifacts = _artifactory.Search()
                .Repositories("repositoryName")
                .ArtifactsCreatedInDateRange()
                .From(new DateTime(2018, 2, 24))
                .To(DateTime.UtcNow)
                .WithOptions(ResponseOptions.Properties)
                .Run();

            Assert.IsNotEmpty(artifacts);
        }
    }
}