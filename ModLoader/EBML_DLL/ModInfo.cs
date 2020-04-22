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
		public string Version { get; private set; }

		/// <summary>
		/// Creates a new ModInfo instance.
		/// </summary>
		/// <param name="name">The name of the mod</param>
		/// <param name="description">The description of the mod</param>
		/// <param name="version">The current version of the mod</param>
		public ModInfo (string name, string description, string version) {
			this.Name = name;
			this.Description = description;
			this.Version = version;
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
