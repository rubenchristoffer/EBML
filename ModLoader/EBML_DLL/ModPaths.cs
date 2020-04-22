using System.IO;

namespace EBML {

	/// <summary>
	/// This class contains file paths for EBML. 
	/// </summary>
	public static class ModPaths {

		/// <summary>
		/// The path to the actual game executable.
		/// </summary>
		public static string GAME_PATH { get; private set; }

		/// <summary>
		/// The path to the EBML folder.
		/// </summary>
		public static string EBML_PATH { get; private set; }

		/// <summary>
		/// The path to the DLL Log folder.
		/// </summary>
		public static string LOG_PATH { get; private set; }

		/// <summary>
		/// The path to the Mods folder.
		/// </summary>
		public static string MODS_PATH { get; private set; }

		static ModPaths () {
			GAME_PATH = new DirectoryInfo (@".\").FullName;
			EBML_PATH = GAME_PATH + @"EBML\";
			LOG_PATH = EBML_PATH + @"DLL_Logs\";
			MODS_PATH = EBML_PATH + @"Mods\";
		}

		internal static void CreateAllModPaths () {
			Directory.CreateDirectory (EBML_PATH);
			Directory.CreateDirectory (MODS_PATH);
			Directory.CreateDirectory (LOG_PATH);
		}

	}

}
