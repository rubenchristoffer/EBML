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

		public ModAssetSet4 (ModAsset<T> asset1, ModAsset<T> asset2, ModAsset<T> asset3, ModAsset<T> asset4) : base(new ModAsset<T>[4]) {
			assets[0] = asset1;
			assets[1] = asset2;
			assets[2] = asset3;
			assets[3] = asset4;
		}

	}

}
