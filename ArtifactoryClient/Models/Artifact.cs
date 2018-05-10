using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArtifactoryClient.Models
{
    public class Artifact
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("properties")]
        public IDictionary<string, string[]> Properties { get; set; }

        [JsonProperty("downLoadUri")]
        public string DownLoadUri { get; set; }

        [JsonProperty("mimeType")]
        public string MimeType { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("checksums")]
        public Dictionary<string, string> Checksums { get; set; }

        [JsonProperty("originalChecksums")]
        public Dictionary<string, string> OriginalChecksums { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        private bool IsEqual(Artifact other)
        {
            return Uri == other.Uri;
        }

        /// <summary>
        /// Equality of the artifacts is equality of references
        /// or equality of URIs
        /// </summary>
        public bool Equals(Artifact other)
        {
            return other != null && (ReferenceEquals(this, other) || IsEqual(other));
        }

        public override bool Equals(object obj)
        {
            return obj is Artifact model && (ReferenceEquals(this, model) || IsEqual(model));
        }

        public override int GetHashCode()
        {
            return Uri.GetHashCode();
        }
    }

    internal class ArtifactslList
    {
        [JsonProperty("results")]
        public IList<Artifact> Artifacts;
    }
}

