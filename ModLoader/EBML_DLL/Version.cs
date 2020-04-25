using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML {

	/// <summary>
	/// Data class representing a Semantic version.
	/// See https://semver.org/ for more information.
	/// </summary>
	public class Version {

		/// <summary>
		/// Hard-coded EBML API Version code.
		/// This is safe to use in ModInfo as TargetAPIVersion.
		/// </summary>
		/// <remarks>Do not use this to check the current version!</remarks>
		public const string API_VERSION = "1.0.0";

		/// <summary>
		/// Determines backward-incompatable changes that can break existing mods.
		/// </summary>
		public int Major { get; private set; }

		/// <summary>
		/// Determines new functionality, but ensures backward-compatability with previous minor
		/// versions as long as major versions are equal.
		/// </summary>
		public int Minor { get; private set; }

		/// <summary>
		/// Determines patches or bug fixes that do not introduce additional functionality.
		/// All changes are backward-compatable.
		/// </summary>
		public int Patch { get; private set; }

		/// <summary>
		/// Create a new Version.
		/// </summary>
		/// <param name="major">Major version</param>
		/// <param name="minor">Minor version</param>
		/// <param name="patch">Patch version</param>
		public Version (int major, int minor, int patch) {
			Major = major;
			Minor = minor;
			Patch = patch;
		}

		/// <summary>
		/// Create a new Version.
		/// </summary>
		/// <param name="formattedVersionString">String in the form [MAJOR].[MINOR].[PATCH]</param>
		/// 
		/// <example><code>new Version("1.1.1")</code></example>
		public Version (string formattedVersionString) {
			string[] split = formattedVersionString.Split ('.');
			
			Major = int.Parse (split[0]);
			Minor = int.Parse (split[1]);
			Patch = int.Parse (split[2]);
		}

		/// <summary>
		/// Gets formatted string for Version.
		/// </summary>
		/// <returns>String in the form [MAJOR].[MINOR].[PATCH]</returns>
		public override string ToString () {
			return String.Format ("{0}.{1}.{2}", Major, Minor, Patch);
		}

	}

}
