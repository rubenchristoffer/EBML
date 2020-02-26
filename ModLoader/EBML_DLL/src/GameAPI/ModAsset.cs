using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML.GameAPI {

	public class ModAsset {

		public int id { get; private set; }
		public UnityEngine.Object asset { get; private set; }

		protected ModAsset (int id, UnityEngine.Object asset) {
			this.id = id;
			this.asset = asset;
		}

		public T GetAs<T> () where T : UnityEngine.Object {
			return (T) asset;
		}

	}

	public class ModAsset<T> : ModAsset where T : UnityEngine.Object {

		internal ModAsset (int id, T asset) : base (id, asset) {}

	}

}
