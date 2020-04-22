using System;
using System.Collections.Generic;
using EBML.GameAPI.Extensions;
using Static;
using UnityEngine;

namespace EBML.GameAPI {

	/// <summary>
	/// This class should be used by mods to register new
	/// resources to the game.
	/// </summary>
	public static class ModResources {

		static readonly Dictionary<int, Sprite> modResourceIcons = new Dictionary<int, Sprite> ();
		static readonly List<int> modProductionResources = new List<int> ();
		static readonly List<int> modWarResources = new List<int> ();

		/// <summary>
		/// The ID that the next modded resource object will have
		/// </summary>
		public static int NextResourceID { get; private set; }

		/// <summary>
		/// The ID that the next modded resource production object will have
		/// </summary>
		public static int NextResourceProductionID { get; private set; }

		static ModResources () {
			NextResourceID = 48; // Last vanilla ID is 47
			NextResourceProductionID = 9; // Last vanilla ID is 8

			// Hook to properly initialize the usedResources Dictionary
			// It is hard-coded to use the vanilla resources
			Hooks.WeaponCraftWindowHooks.Awake.AddPreHook ((instance) => {
				Dictionary<int, long> usedResources = instance.GetUsedResources ();

				modProductionResources.ForEach (mpr => usedResources.Add (mpr, 0));
			});

			// This hook is needed for properly adding modded weapons to 
			// "Sell Weapons" window since the vanilla method uses a hard-coded approach
			Hooks.GameWindowHooks.Start.AddPreHook ((instance) => {
				if (instance.type == GameWindow.WindowType.WeaponInvest) {
					WeaponInvestWindow window = (WeaponInvestWindow) instance;

					window.SetSellCardsPool (new AutoPool<ResourceSellCard> (() => {
						Array values = Enum.GetValues (typeof (ArmyInfo.WarriorClass));
						int num = 0;

						// Add all the vanilla resources
						for (int i = 0; i < values.Length; i++) {
							ArmyInfo.WarriorClass warriorClass = (ArmyInfo.WarriorClass) values.GetValue (i);
							if (warriorClass != ArmyInfo.WarriorClass.Militiaman && SingletonMonoBehaviour<ResourceController>.THIS.IsResourceAvailable ((int) warriorClass)) {
								window.GetSellCardsPool ()[num++].SetResource (SingletonMonoBehaviour<ResourceController>.THIS.GetResource ((int) warriorClass));
							}
						}

						// This is actually where the modded resources are added to the list of weapons
						foreach (int modWarResource in modWarResources) {
							if (SingletonMonoBehaviour<ResourceController>.THIS.IsResourceAvailable (modWarResource)) {
								window.GetSellCardsPool ()[num++].SetResource (SingletonMonoBehaviour<ResourceController>.THIS.GetResource (modWarResource));
							}
						}
					}, window.GetSellCardPrefab (), window.GetSellCardsContainer (), (ResourceSellCard card) => {
						card.onValueChanged += window.UpdateInfo;
					}));
				}
			});
		}

		/// <summary>
		/// Registers a new resource, which allows you to create your own kind of resource.
		/// The ID will be assigned to nextResourceID automatically.
		/// Note that the actual resource will not be created until
		/// <see cref="ResourceController.CreateResources"/> has been called, but this will
		/// happen automatically.
		/// </summary>
		/// <param name="staticResourceData">Resource information</param>
		/// <param name="iconSprite">Optional icon.</param>
		/// <param name="isWarResource">If this is true, it will be possible to sell it to other countries.</param>
		/// <returns>ID of the new resource</returns>
		/// <seealso cref="SimpleSpriteFactory"/>
		public static int RegisterNewResource (StaticResourceData staticResourceData, ModAsset<Sprite> iconSprite = null, bool isWarResource = false) {
			staticResourceData.id = NextResourceID;
			AddStaticResource (staticResourceData);
			modWarResources.Add (NextResourceID);

			if (iconSprite != null) {
				string resourceURL = "ResourceIcons/" + NextResourceID;

				if (!ModAssets.DoesMappingExist (resourceURL))
					ModAssets.AddResourceMapping (resourceURL, iconSprite.Id);
			}

			return NextResourceID++;
		}

		/// <summary>
		/// Registers a new resource by calling <see cref="RegisterNewResource(StaticResourceData, ModAsset{Sprite}, bool)"/>. 
		/// In addition to this, it registers the resource production data, indicating that
		/// this is a resource that can be produced (typically grain or some kind of weapon).
		/// The IDs will be assigned automatically.
		/// Note that the actual resource will not be created until
		/// <see cref="ResourceController.CreateResources"/> has been called, but this will
		/// happen automatically.
		/// </summary>
		/// <param name="staticResourceData">Generate this using DataFactory</param>
		/// <param name="staticResourceProductionData">Generate this using DataFactory</param>
		/// <param name="iconSprite">Optional icon.</param>
		/// <param name="isWarResource">If this is true, it will be possible to sell it to other countries.</param>
		/// <returns>Tuple containing assigned ID of resource and 
		/// ID of production resource respectively</returns>
		/// <seealso cref="ModAssets.CreateAsset{T}(T)"/>
		/// <seealso cref="SimpleSpriteFactory"/>
		/// <seealso cref="DataFactory.CreateStaticResourceData(string, Resource.ResourceType, int, int)"/>
		/// <seealso cref="DataFactory.CreateStaticResourceProductionData(int, Turn.Season, int, int, float, int, float)"/>
		public static Tuple<int, int> RegisterNewProductionResource (StaticResourceData staticResourceData, StaticResourceProductionData staticResourceProductionData, ModAsset<Sprite> iconSprite = null, bool isWarResource = true) {
			int resourceID = RegisterNewResource (staticResourceData, iconSprite, isWarResource);

			staticResourceProductionData.id = NextResourceProductionID;
			staticResourceProductionData.resourse_id = resourceID;

			if (staticResourceProductionData.price_seeding_id1 != 0 && !modProductionResources.Contains (staticResourceProductionData.price_seeding_id1))
				modProductionResources.Add (staticResourceProductionData.price_seeding_id1);

			if (staticResourceProductionData.price_seeding_id2 != 0 && !modProductionResources.Contains (staticResourceProductionData.price_seeding_id2))
				modProductionResources.Add (staticResourceProductionData.price_seeding_id2);

			AddStaticResourceProduction (staticResourceProductionData);

			return new Tuple<int, int> (resourceID, NextResourceProductionID++);
		}

		static void AddStaticResource (StaticResourceData resource) {
			StaticResource staticResource = Singletons.RESOURCE_CONTROLLER.GetStaticResource ();

			StaticResourceData[] newData = new StaticResourceData[staticResource.staticResourceDataArr.Length + 1];
			staticResource.staticResourceDataArr.CopyTo (newData, 0);
			newData[newData.Length - 1] = resource;

			staticResource.staticResourceDataArr = newData;
		}

		static void AddStaticResourceProduction (StaticResourceProductionData resourceProduction) {
			StaticResourceProduction staticResourceProduction = Singletons.RESOURCE_CONTROLLER.GetStaticResourceProduction ();

			StaticResourceProductionData[] newData = new StaticResourceProductionData[staticResourceProduction.staticResourceProductionDataArr.Length + 1];
			staticResourceProduction.staticResourceProductionDataArr.CopyTo (newData, 0);
			newData[newData.Length - 1] = resourceProduction;

			staticResourceProduction.staticResourceProductionDataArr = newData;
		}

	}

}
