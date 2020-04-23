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
	public struct Version {

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
		/// Gets formatted string for Version.
		/// </summary>
		/// <returns>String in the form [MAJOR].[MINOR].[PATCH]</returns>
		public override string ToString () {
			return String.Format ("{0}.{1}.{2}", Major, Minor, Patch);
		}

		/// <summary>
		/// Gets the official EBML version.
		/// </summary>
		/// <returns>Official API version</returns>
		public static Version GetAPIVersion () {
			return new Version (1, 0, 0);
		}

	}

}
