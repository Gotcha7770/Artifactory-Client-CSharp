# Artifacotry-Client-CSharp [![Build status](https://ci.appveyor.com/api/projects/status/7q38la3x5wo4lffc?svg=true)](https://ci.appveyor.com/project/Gotcha7770/artifacotry-client-csharp)
Rest client for Artifactory on C# partially inspired by https://github.com/jfrog/artifactory-client-java

Now only search, downloading and uploading artifatcs is available.

There are three ways to create Artifactory client:

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
    .SetUserName(userName)
    .SetPassword(password)
    .SetUrl(http:\\some\url)
    .Build();
```

### Search

1) Quick search

```csharp
IList<Artifact> artifacts = _artifactory.Search()
    .Repositories("repositoryName", "anotherRepositoryName")
    .ByName("*.zip")
    .Run();
```

2) Properties search

```csharp
IList<Artifact> artifacts = _artifactory.Search()
    .Repositories("repositoryName")
    .WithProperty("name", "")
    .WithProperty("version", "")
    .WithOptions(ResponseOptions.Properties|ResponseOptions.Info)
    .Run();
```

3) Create period search

```csharp
IList<Artifact> artifacts = _artifactory.Search()
    .Repositories("repositoryName")
    .ArtifactsCreatedInDateRange()
    .From(new DateTime(2018, 2, 24))
    .To(DateTime.UtcNow)
    .WithOptions(ResponseOptions.Properties)
    .Run();
```
### Download artifacts

```csharp
 string artifactPath = "your/artifact/path";
 IRestResponse response = _artifactory.GetRepository("repositoryName").Download(artifactPath);
```

### Upload artifacts

```csharp
IRestResponse response = _artifactory.GetRepository("repositoryName")
    .Upload("artifactName/artifactName.1.0.3.ext", bytes)
    .WithProperty("name", "artifactName")
    .WithProperty("version", "1.0.3")
    .WithProperty("dependencies", new[] { "dep1", "dep2" })
    .Run();
```
