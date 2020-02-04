using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Static;
using EBML.GameAPI.Extensions;

namespace EBML.GameAPI {

    public static class ModResources {

        public static int nextResourceID { get; private set; }
        public static int nextResourceProductionID { get; private set; }

        private static List<int> modProductionResources = new List<int>();
        private static List<int> modWarResources = new List<int>();

        static ModResources () {
            nextResourceID = Singletons.RESOURCE_CONTROLLER.GetStaticResource().staticResourceDataArr.Length + 1;
            nextResourceProductionID = 9;

            Hooks.WeaponCraftWindowHooks.Awake.AddPreHook((instance) => {
                Dictionary<int, long> usedResources = instance.GetUsedResources();

                modProductionResources.ForEach(mpr => usedResources.Add(mpr, 0));
            });

            // This hook is needed for properly adding modded weapons to 
            // "Sell Weapons" window
            Hooks.GameWindowHooks.Start.AddPreHook((instance) => {
                if (instance.type == GameWindow.WindowType.WeaponInvest) {
                    WeaponInvestWindow window = (WeaponInvestWindow)instance;

                    window.SetSellCardsPool(new AutoPool<ResourceSellCard>(() => {
                        Array values = Enum.GetValues(typeof(ArmyInfo.WarriorClass));
                        int num = 0;

                        for (int i = 0; i < values.Length; i++) {
                            ArmyInfo.WarriorClass warriorClass = (ArmyInfo.WarriorClass)values.GetValue(i);
                            if (warriorClass != ArmyInfo.WarriorClass.Militiaman && SingletonMonoBehaviour<ResourceController>.THIS.IsResourceAvailable((int)warriorClass)) {
                                window.GetSellCardsPool()[num++].SetResource(SingletonMonoBehaviour<ResourceController>.THIS.GetResource((int)warriorClass));
                            }
                        }

                        // This is actually where the modded resources are added to the list of weapons
                        foreach (int modWarResource in modWarResources) {
                            if (SingletonMonoBehaviour<ResourceController>.THIS.IsResourceAvailable(modWarResource)) {
                                window.GetSellCardsPool()[num++].SetResource(SingletonMonoBehaviour<ResourceController>.THIS.GetResource(modWarResource));
                            }
                        }
                    }, window.GetSellCardPrefab(), window.GetSellCardsContainer(), (ResourceSellCard card) => {
                        card.onValueChanged += window.UpdateInfo;
                    }));
                }
            });
        }

        /// <summary>
        /// Registers a new resource, which allows you to create your own kind of resource.
        /// The ID will be assigned to nextResourceID automatically.
        /// </summary>
        /// <param name="staticResourceData">Resource Information</param>
        /// <returns>ID of the new resource</returns>
        public static int RegisterNewResource (StaticResourceData staticResourceData, bool isWarResource = false) {
            staticResourceData.id = nextResourceID;
            AddStaticResource(staticResourceData);
            modWarResources.Add(nextResourceID);

            return nextResourceID++;
        }

        public static int RegisterNewProductionResource (StaticResourceData staticResourceData, StaticResourceProductionData staticResourceProductionData, bool isWarResource = true) {
            int resourceID = RegisterNewResource(staticResourceData, isWarResource);

            staticResourceProductionData.id = nextResourceProductionID;
            staticResourceProductionData.resourse_id = resourceID;

            if (staticResourceProductionData.price_seeding_id1 != 0 && !modProductionResources.Contains(staticResourceProductionData.price_seeding_id1))
                modProductionResources.Add(staticResourceProductionData.price_seeding_id1);

            if (staticResourceProductionData.price_seeding_id2 != 0 && !modProductionResources.Contains(staticResourceProductionData.price_seeding_id2))
                modProductionResources.Add(staticResourceProductionData.price_seeding_id2);

            AddStaticResourceProduction(staticResourceProductionData);

            return nextResourceProductionID++;
        }

        private static void AddStaticResource(StaticResourceData resource) {
            StaticResource staticResource = Singletons.RESOURCE_CONTROLLER.GetStaticResource();

            StaticResourceData[] newData = new StaticResourceData[staticResource.staticResourceDataArr.Length + 1];
            staticResource.staticResourceDataArr.CopyTo(newData, 0);
            newData[newData.Length - 1] = resource;

            staticResource.staticResourceDataArr = newData;
        }

        private static void AddStaticResourceProduction(StaticResourceProductionData resourceProduction) {
            StaticResourceProduction staticResourceProduction = Singletons.RESOURCE_CONTROLLER.GetStaticResourceProduction();

            StaticResourceProductionData[] newData = new StaticResourceProductionData[staticResourceProduction.staticResourceProductionDataArr.Length + 1];
            staticResourceProduction.staticResourceProductionDataArr.CopyTo(newData, 0);
            newData[newData.Length - 1] = resourceProduction;

            staticResourceProduction.staticResourceProductionDataArr = newData;
        }

    }

}
