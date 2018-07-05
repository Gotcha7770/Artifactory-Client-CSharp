# Artifacotry-Client-CSharp [![Build status](https://ci.appveyor.com/api/projects/status/7q38la3x5wo4lffc?svg=true)](https://ci.appveyor.com/project/Gotcha7770/artifacotry-client-csharp)
Rest client for Artifactory on C# partially inspired by https://github.com/jfrog/artifactory-client-java

Now only search, downloading and uploading artifatcs is available.

There is 3 way to create Artifactory client:

1) with implementation of IRestClient

```csharp
IRestClient client = new RestClient
{
    BaseUrl = new Uri(http:\\some\url),
    Authenticator = new HttpBasicAuthenticator(userName, password)
};

IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
    .SetRestClient(client)
    .Build();
```

2) with implementation of IAuthenticator

```csharp
IAuthenticator authenticator = new HttpBasicAuthenticator(userName, password);

IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
    .SetAuthentificator(authenticator)
    .SetUrl(http:\\some\url)
    .Build();
```

3) or just set properties

```csharp
IArtifactory artifactory = ArtifactoryBuilder.CreateArtifactory()
    .SetUserName(TestConnection.UserName)
    .SetPassword(TestConnection.Password)
    .SetUrl(TestConnection.Url + TestConnection.ArtifactorySection)
    .Build();
```
