using System.IO;
using EBML.Logging;

namespace EBML {

	/// <summary>
	/// ModFiles is a utility class that you use for loading external resources
	/// into the game from files such as textures / sprites. 
	/// </summary>
	public static class ModFiles {

		static readonly ILog log = LogFactory.GetLogger (typeof (ModFiles));

		/// <summary>
		/// Reads a file from disk and stores the data in a byte array.
		/// </summary>
		/// <param name="relativeFilePath">Path relative to Mods folder</param>
		/// <returns>A raw byte array if file exists or null otherwise</returns>
		public static byte[] ReadFileFromDisk (string relativeFilePath) {
			string fullPath = GetFullPath (relativeFilePath);

			log.Debug (string.Format ("Reading file from disk: {0}...", fullPath));

			if (!File.Exists (fullPath))
				return null;

			return File.ReadAllBytes (fullPath);
		}

		/// <summary>
		/// Gets the full path based on relative mods path.
		/// </summary>
		/// <param name="relativeFilePath">Path relative to Mods folder</param>
		/// <returns>String containing full path</returns>
		public static string GetFullPath (string relativeFilePath) {
			return Path.Combine (ModPaths.MODS_PATH, relativeFilePath);
		}

	}

}
