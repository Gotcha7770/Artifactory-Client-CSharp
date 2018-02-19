using System;
using ArtifactoryClient.Interfaces;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;

namespace ArtifactoryClient.UnitTests
{

    [TestFixture]
    public class BuilderTests
    {
        private string _baseUrl = "https://some.url";
        private string _userName = "user";
        private string _password = "pass";


        [Test]
        public void BuildWithClientTest()
        {
            IRestClient client = new RestClient
            {
                BaseUrl = new Uri(_baseUrl),
                Authenticator = new HttpBasicAuthenticator(_userName, _password)
            };

            IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
                .SetRestClient(client)
                .Build();
        }

        [Test]
        public void BuilderWithAuthentificationTest()
        {
            IAuthenticator authenticator = new HttpBasicAuthenticator(_userName, _password);
            IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
                .SetAuthentificator(authenticator)
                .SetUrl(_baseUrl)
                .Build();
        }

        [Test]
        public void BuilderWithNameAndPasswordTest()
        {
            IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
                .SetUsername(_userName)
                .SetPassword(_password)
                .SetUrl(_baseUrl)
                .Build();
        }
    }
}