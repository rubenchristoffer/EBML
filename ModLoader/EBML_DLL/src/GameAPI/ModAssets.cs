using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML.GameAPI {

	public static class ModAssets {

		public static int currentID { get; private set; }

		private static Dictionary<int, UnityEngine.Object> assets = new Dictionary<int, UnityEngine.Object>();
		private static Dictionary<string, int> resourceToAssetMappings = new Dictionary<string, int>();

		public static int AddAsset(UnityEngine.Object obj) {
			assets.Add(currentID, obj);

			return currentID++;
		}

		public static void AddResourceMapping (string resourceURL, int assetID) {
			resourceToAssetMappings.Add(resourceURL, assetID);
		}

		public static bool DoesMappingExist (string resourceURL) {
			return resourceToAssetMappings.ContainsKey(resourceURL);
		}

		public static T GetAsset<T> (int assetID) where T : UnityEngine.Object {
			return (T) assets[assetID];
		}

		public static T GetAssetWithMapping<T> (string resourceURL) where T : UnityEngine.Object {
			return GetAsset<T>(resourceToAssetMappings[resourceURL]);
		}

	}

}
