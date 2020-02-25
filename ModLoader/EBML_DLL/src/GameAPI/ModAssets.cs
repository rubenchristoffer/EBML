using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBML.Hooks;

namespace EBML.GameAPI {

	public static class ModAssets {

		public static int currentID { get; private set; }

		private static Dictionary<int, ModAsset> assets = new Dictionary<int, ModAsset>();
		private static Dictionary<string, int> resourceToAssetMappings = new Dictionary<string, int>();

		static ModAssets () {
			Hooks.UnityResourcesHooks.Load.AddPreHook((returnObj, path) => {
				if (DoesMappingExist(path)) {
					ModLoader.Log(path);
					returnObj.SetValue(GetAssetWithMapping(path).asset);
				}
			});

			// TODO: Create Sprite hook here
		}

		public static ModAsset CreateAsset(UnityEngine.Object asset) {
			ModAsset modAsset = new ModAsset(currentID, asset);
			assets.Add(currentID, modAsset);
			currentID++;

			return modAsset;
		}

		public static void AddResourceMapping (string resourceURL, int assetID) {
			resourceToAssetMappings.Add(resourceURL, assetID);
		}

		public static bool DoesMappingExist (string resourceURL) {
			return resourceToAssetMappings.ContainsKey(resourceURL);
		}

		public static ModAsset GetAsset (int assetID) {
			return assets[assetID];
		}

		public static ModAsset GetAssetWithMapping (string resourceURL) {
			return GetAsset(resourceToAssetMappings[resourceURL]);
		}

	}

}
