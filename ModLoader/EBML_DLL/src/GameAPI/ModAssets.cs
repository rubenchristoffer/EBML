﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBML.Hooks;

namespace EBML.GameAPI {

	/// <summary>
	/// This class is responsible for storing all the
	/// <see cref="ModAsset"/>s and you should use this
	/// class to create them.
	/// </summary>
	public static class ModAssets {

		/// <summary>
		/// This is the ID that the next ModAsset will have.
		/// </summary>
		public static int nextID { get; private set; }

		private static Dictionary<int, ModAsset> assets = new Dictionary<int, ModAsset>();
		private static Dictionary<string, int> resourceToAssetMappings = new Dictionary<string, int>();

		static ModAssets () {
			nextID = 1000;

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

		/// <summary>
		/// Creates a new ModAsset based on a given asset.
		/// A resource mapping will NOT be added by default.
		/// </summary>
		/// <typeparam name="T">The asset type</typeparam>
		/// <param name="asset">The asset itself</param>
		/// <returns>ModAsset with unique ID</returns>
		public static ModAsset<T> CreateAsset<T>(T asset) where T : UnityEngine.Object {
			ModAsset<T> modAsset = new ModAsset<T>(nextID, asset);
			assets.Add(nextID, modAsset);
			nextID++;

			return modAsset;
		}

		/// <summary>
		/// Adds a new resource mapping to a given ModAsset by its ID.
		/// This means that if you try to use the resourceURL in any of the
		/// <see cref="UnityEngine.Resources"/> load functions it will return
		/// the mod asset instead (that is given that the type has a hook 
		/// for it).
		/// </summary>
		/// <param name="resourceURL">The resource URL used for mapping</param>
		/// <param name="assetID">The ID of the asset you want to map it to</param>
		public static void AddResourceMapping (string resourceURL, int assetID) {
			resourceToAssetMappings.Add(resourceURL, assetID);
		}

		/// <summary>
		/// Checks whether or not a mapping already exists for that
		/// given resourceURL. A resourceURL can only be mapped to one
		/// asset.
		/// </summary>
		/// <param name="resourceURL">The resourceURL you want to check</param>
		/// <returns>True if mapping exists, otherwise false</returns>
		public static bool DoesMappingExist (string resourceURL) {
			return resourceToAssetMappings.ContainsKey(resourceURL);
		}

		/// <summary>
		/// Gets the asset given its ID.
		/// </summary>
		/// <param name="assetID">The ID of the asset</param>
		/// <returns>ModAsset with that ID if it exists</returns>
		public static ModAsset GetAsset (int assetID) {
			return assets[assetID];
		}

		/// <summary>
		/// Gets an asset given its resourceURL mapping if
		/// such a mapping exists.
		/// </summary>
		/// <param name="resourceURL">The resource mapping URL</param>
		/// <returns>ModAsset mapped to resourceURL if it exists</returns>
		public static ModAsset GetAssetWithMapping (string resourceURL) {
			return GetAsset(resourceToAssetMappings[resourceURL]);
		}

	}

}
