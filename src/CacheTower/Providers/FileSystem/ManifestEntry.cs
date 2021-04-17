using System;

namespace CacheTower.Providers.FileSystem
{
	/// <inheritdoc/>
	public class ManifestEntry : IManifestEntry
	{
		/// <inheritdoc/>
		public string? FileName { get; set; }
		/// <inheritdoc/>
		public DateTime Expiry { get; set; }
	}
}
