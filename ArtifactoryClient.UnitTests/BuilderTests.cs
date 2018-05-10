using System;
using ArtifactoryClient.Interfaces;
using ArtifactoryClient.UnitTests.Helpers;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;

namespace ArtifactoryClient.UnitTests
{

    [TestFixture]
    public class BuilderTests
    {
        [Test]
        public void BuildWithClientTest()
        {
            IRestClient client = new RestClient
            {
                BaseUrl = new Uri(TestConnection.Url + TestConnection.ArtifactorySection),
                Authenticator = new HttpBasicAuthenticator(TestConnection.UserName, TestConnection.Password)
            };

            IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
                .SetRestClient(client)
                .Build();
        }

        [Test]
        public void BuilderWithAuthentificationTest()
        {
            IAuthenticator authenticator = new HttpBasicAuthenticator(TestConnection.UserName, TestConnection.Password);
            IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
                .SetAuthentificator(authenticator)
                .SetUrl(TestConnection.Url + TestConnection.ArtifactorySection)
                .Build();
        }

        [Test]
        public void BuilderWithNameAndPasswordTest()
        {
            IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
                .SetUserName(TestConnection.UserName)
                .SetPassword(TestConnection.Password)
                .SetUrl(TestConnection.Url + TestConnection.ArtifactorySection)
                .Build();
        }
    }
}