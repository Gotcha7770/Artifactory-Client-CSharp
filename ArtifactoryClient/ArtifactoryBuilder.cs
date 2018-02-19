using ArtifactoryClient.Utils;

namespace ArtifactoryClient
{
    public enum PackageType
    {
        Custom,
        Bower,
        Cocoapods,
        Debian,
        Distribution,
        Docker,
        Gems,
        Generic,
        Gitlfs,
        Gradle,
        Ivy,
        Maven,
        Npm,
        Nuget,
        Opkg,
        P2,
        Pypi,
        Sbt,
        Vagrant,
        Vcs,
        Yum,
        Rpm,
        Composer,
        Conan,
        Chef,
        Puppet
    }

    public static class ArtifactoryBuilder
    {
        public static string DefaultUserAgent = "artifactory-client-DotNet";
        public static string ApiBase = "/api";

        public static ArtifactoryConfiguration CreateArtifactory()
        {
            return new ArtifactoryConfiguration();
        }
    }
}
