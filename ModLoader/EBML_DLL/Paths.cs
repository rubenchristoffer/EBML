using System.IO;

namespace EBML {

	/// <summary>
	/// This class contains file paths for EBML. 
	/// </summary>
	public static class Paths {

		/// <summary>
		/// The path to the actual game executable.
		/// </summary>
		public static readonly string GAME_PATH;

		/// <summary>
		/// The path to the EBML folder.
		/// </summary>
		public static readonly string EBML_PATH;

		/// <summary>
		/// The path to the DLL Log folder.
		/// </summary>
		public static readonly string LOG_PATH;

		/// <summary>
		/// The path to the Mods folder.
		/// </summary>
		public static readonly string MODS_PATH;

		static Paths () {
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
