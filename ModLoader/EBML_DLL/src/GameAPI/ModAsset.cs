using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML.GameAPI {

	public class ModAsset {

		public int id { get; private set; }
		public UnityEngine.Object asset { get; private set; }

		internal ModAsset(int id, UnityEngine.Object asset) {
			this.id = id;
			this.asset = asset;
		}

		public T GetAs<T> () where T : UnityEngine.Object {
			return (T) asset;
		}

	}

}
