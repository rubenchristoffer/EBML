using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML.GameAPI {

	public class ModAssetSet<T> where T : UnityEngine.Object {

		public ModAsset<T>[] assets { get; protected set; }

		public ModAssetSet (ModAsset<T>[] assets) {
			this.assets = assets;
		}

	}

	public class ModAssetSet4<T> : ModAssetSet<T> where T : UnityEngine.Object {

		public ModAssetSet4 (ModAsset<T> asset1, ModAsset<T> asset2, ModAsset<T> asset3, ModAsset<T> asset4) {
			assets = new ModAsset<T>[] {
				asset1, 
				asset2,
				asset3, 
				asset4
			};
		}

	}

}
