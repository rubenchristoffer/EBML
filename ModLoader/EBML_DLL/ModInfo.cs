namespace EBML {

	/// <summary>
	/// This class should be used to
	/// contain metadata about a mod.
	/// </summary>
	public class ModInfo {

		/// <summary>
		/// This is the official name of the mod.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// This is a description of the mod.
		/// </summary>
		public string Description { get; private set; }

		/// <summary>
		/// This is the current version of the mod.
		/// </summary>
		public Version Version { get; private set; }

		/// <summary>
		/// This is the version of the EBML API that
		/// you are targetting. 
		/// </summary>
		public Version TargetAPIVersion { get; private set; }

		/// <summary>
		/// Creates a new ModInfo instance.
		/// </summary>
		/// <param name="name">The name of the mod</param>
		/// <param name="description">The description of the mod</param>
		/// <param name="version">The current version of the mod</param>
		/// <param name="targetAPIVersion">The EBML API version that this mod is using / targetting.
		/// This should not be a dynamic value that might change over time!</param>
		public ModInfo (string name, string description, Version version, Version targetAPIVersion) {
			Name = name;
			Description = description;
			Version = version;
			TargetAPIVersion = targetAPIVersion;
		}

		/// <summary>
		/// Gets the string representation of ModInfo.
		/// </summary>
		/// <returns>String in form '[name] - [version]'</returns>
		public override string ToString () {
			return Name + " - " + Version;
		}

	}

}
