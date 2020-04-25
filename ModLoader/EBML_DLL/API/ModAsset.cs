namespace EBML.API {

	/// <summary>
	/// A ModAsset is a Unity asset (object) with its
	/// own unique ID. It is used by the mod API to keep
	/// track of modded assets. It is also possible to create
	/// a mapping between path and ModAsset so that if you use any
	/// <see cref="UnityEngine.Resources"/> Load function you load 
	/// the ModAsset, although not all types might be supported using 
	/// the generic version of Load.
	/// Use <see cref="ModAssets"/> to create a ModAsset.
	/// </summary>
	public class ModAsset {

		/// <summary>
		/// Unique ID of this ModAsset.
		/// The ID may change depending on which mods
		/// are loaded first, but it will always start counting
		/// from 1000 and up to ensure no collision with the
		/// game API.
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// The actual asset itself.
		/// </summary>
		public UnityEngine.Object Asset { get; private set; }

		/// <summary>
		/// Creates a new ModAsset without type safety.
		/// </summary>
		/// <param name="id">The unique ID</param>
		/// <param name="asset">The actual asset</param>
		protected ModAsset (int id, UnityEngine.Object asset) {
			this.Id = id;
			this.Asset = asset;
		}

		/// <summary>
		/// Gets the actual asset and casts it before returning it.
		/// </summary>
		/// <typeparam name="T">The type you want to cast to</typeparam>
		/// <returns>Asset itself casted to <code>T</code></returns>
		public T GetAs<T> () where T : UnityEngine.Object {
			return (T) Asset;
		}

	}

	/// <summary>
	/// This is a type-safe wrapper class of <see cref="ModAsset"/>.
	/// </summary>
	/// <typeparam name="T">The asset type</typeparam>
	public class ModAsset<T> : ModAsset where T : UnityEngine.Object {

		internal ModAsset (int id, T asset) : base (id, asset) { }

	}

}
