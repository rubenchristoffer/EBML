using EBML.Logging;

namespace EBML {

	/// <summary>
	/// This is a an abstract class representation
	/// of a mod. The ModLoader searches for a subclass
	/// of this object after loading a Mod DLL.
	/// In other words, create a subclass of this
	/// class when creating your mod.
	/// </summary>
	public abstract class Mod {

		/// <summary>
		/// Logger provided by ModLoader.
		/// It is recommended to use this log when logging to console.
		/// </summary>
		protected readonly ILog log;

		/// <summary>
		/// This contains information about the mod (metadata).
		/// </summary>
		public abstract ModInfo Info { get; }

		/// <summary>
		/// This will be called right after the mod is loaded
		/// and might be called before other mods are loaded.
		/// </summary>
		public virtual void OnLoad () { }

		/// <summary>
		/// This will be called after every mod has been loaded
		/// and should be used to initialize data.
		/// </summary>
		public virtual void OnInit () { }

		/// <summary>
		/// This will be called after every mod has been initialized.
		/// </summary>
		public virtual void OnPostInit () { }

	}

}
