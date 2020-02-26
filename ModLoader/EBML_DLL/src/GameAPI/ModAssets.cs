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
			currentID = 1000;

			// Create Load hooks so that when you use the UnityEngine.Resources.Load functions
			// it will automatically return mod asset if it has a resource mapping

			Hooks.UnityResourcesHooks.Load.AddPreHook((returnObj, path) => {
				if (DoesMappingExist(path)) {
					ModLoader.Log(path);
					returnObj.SetValue(GetAssetWithMapping(path).asset);
				}
			});

			Hooks.UnityResourcesHooks.LoadSprite.AddPreHook((returnObj, path) => {
				if (DoesMappingExist(path)) {
					ModLoader.Log(path);
					returnObj.SetValue(GetAssetWithMapping(path).GetAs<UnityEngine.Sprite>());
				}
			});
		}

		public static ModAsset<T> CreateAsset<T>(T asset) where T : UnityEngine.Object {
			ModAsset<T> modAsset = new ModAsset<T>(currentID, asset);
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
