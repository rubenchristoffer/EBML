namespace EBML.GameAPI {

	/// <summary>
	/// You can look at this as an array of ModAssets.
	/// </summary>
	/// <typeparam name="T">The asset type of ModAssets</typeparam>
	public class ModAssetSet<T> where T : UnityEngine.Object {

		/// <summary>
		/// The assets in the set.
		/// </summary>
		public ModAsset<T>[] Assets { get; protected set; }

		/// <summary>
		/// Creates a new ModAssetSet given an array of ModAssets.
		/// </summary>
		/// <param name="assets">The assets you want to create a set out of</param>
		public ModAssetSet (ModAsset<T>[] assets) {
			this.Assets = assets;
		}

	}

	/// <summary>
	/// This is type of <see cref="ModAssetSet{T}"/> that is restricted to four ModAssets exactly.
	/// </summary>
	/// <typeparam name="T">The asset type of ModAssets</typeparam>
	public class ModAssetSet4<T> : ModAssetSet<T> where T : UnityEngine.Object {

		/// <summary>
		/// Creates a new ModAssetSet with four assets.
		/// </summary>
		/// <param name="asset1">First asset</param>
		/// <param name="asset2">Second asset</param>
		/// <param name="asset3">Third asset</param>
		/// <param name="asset4">Fourth asset</param>
		public ModAssetSet4 (ModAsset<T> asset1, ModAsset<T> asset2, ModAsset<T> asset3, ModAsset<T> asset4) : base (new ModAsset<T>[4]) {
			Assets[0] = asset1;
			Assets[1] = asset2;
			Assets[2] = asset3;
			Assets[3] = asset4;
		}

	}

}
