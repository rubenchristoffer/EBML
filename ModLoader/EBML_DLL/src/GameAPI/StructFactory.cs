using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Static;

namespace EBML.GameAPI {

    /// <summary>
    /// Utility class that generates common structs in the game.
    /// ID fields are left out, since they should usually be assigned
    /// by the EBML API and not the Modder. 
    /// </summary>
    public static class StructFactory {

        /// <summary>
        /// See <see cref="CreateStaticResourceData(string, int, int, int)"/>
        /// </summary>
        public static StaticResourceData CreateStaticResourceData (string name, Resource.ResourceType resourceType, int basePrice, int turnDiscovery) {
            return CreateStaticResourceData(name, (int)resourceType, basePrice, turnDiscovery);
        }

        /// <summary>
        /// Creates Static Resource Data with invalid ID (-1).
        /// This is used by <see cref="ResourceController"/> when creating new resources.
        /// </summary>
        /// <param name="name">Name of the resource or key to name in <see cref="LocalizationController"/></param>
        /// <param name="resourceType">The type of resource it is</param>
        /// <param name="basePrice">The starting (selling) price.</param>
        /// <param name="turnDiscovery">At which turn will it be available? 0 indicates from beginning of game.</param>
        /// <returns>StaticResourceData struct</returns>
        public static StaticResourceData CreateStaticResourceData(string name, int resourceType, int basePrice, int turnDiscovery) {
            StaticResourceData staticResourceData = new StaticResourceData();
            staticResourceData.id = -1;
            staticResourceData.name = name;
            staticResourceData.resourse_type = resourceType;
            staticResourceData.base_price = basePrice;
            staticResourceData.turn_discovery = turnDiscovery;

            return staticResourceData;
        }

        /// <summary>
        /// See <see cref="CreateStaticResourceProductionData(int, int, int, int, float, int, float)"/>
        /// </summary>
        public static StaticResourceProductionData CreateStaticResourceProductionData (int workAmount, Turn.Season autoseedingSeason, int turnMaturation, int priceSeedingID1, float priceSeedingID1Amount, int priceSeedingID2, float priceSeedingID2Amount) {
            return CreateStaticResourceProductionData(workAmount, (int)autoseedingSeason, turnMaturation, priceSeedingID1, priceSeedingID1Amount, priceSeedingID2, priceSeedingID2Amount);
        }

        /// <summary>
        /// Creates Static Resource Production Data with invalid ID (-1) and Resource ID (-1).
        /// This is used by <see cref="ResourceController"/> when creating new production resources.
        /// </summary>
        /// <param name="workAmount">The amount of work required to produce 1 of this resource.</param>
        /// <param name="autoseedingSeason">Which season autoseeding will happen in. Use 0 / None 
        /// if there is no seeding (if it's a weapon instead)</param>
        /// <param name="turnMaturation"></param>
        /// <param name="priceSeedingID1">Resource nr 1. used as payment for seeding OR resource nr. 1 required to create weapon.</param>
        /// <param name="priceSeedingID1Amount">Amount of resource nr. 1 required.</param>
        /// <param name="priceSeedingID2">Resource nr 2. used as payment for seeding OR resource nr. 2 required to create weapon.</param>
        /// <param name="priceSeedingID2Amount">Amount of resource nr. 2 required.</param>
        /// <returns>StaticResourceProductionData struct</returns>
        public static StaticResourceProductionData CreateStaticResourceProductionData (int workAmount, int autoseedingSeason, int turnMaturation, int priceSeedingID1, float priceSeedingID1Amount, int priceSeedingID2, float priceSeedingID2Amount) {
            StaticResourceProductionData staticResourceProductionData = new StaticResourceProductionData();
            
            staticResourceProductionData.id = -1;
            staticResourceProductionData.resourse_id = -1;

            staticResourceProductionData.work_amount = workAmount;
            staticResourceProductionData.autoseeding_season = autoseedingSeason;
            staticResourceProductionData.turn_maturation = turnMaturation;
            staticResourceProductionData.price_seeding_id1 = priceSeedingID1;
            staticResourceProductionData.price_seeding_id1_amount = priceSeedingID1Amount;
            staticResourceProductionData.price_seeding_id2 = priceSeedingID2;
            staticResourceProductionData.price_seeding_id2_amount = priceSeedingID2Amount;

            return staticResourceProductionData;
        }

        /// <summary>
        /// See <see cref="CreateStaticResourceBuildingsData(string, string, string, string, string, int, int, float)"/>.
        /// </summary>
        public static StaticResourceBuildingsData CreateStaticResourceBuildingsData(string name1, string name2, string name3, string name4, string description, int resourceID, UserProperty.Type buildingType, float incomeBonus = 1f) {
            return CreateStaticResourceBuildingsData(name1, name2, name3, name4, description, resourceID, (int)buildingType, incomeBonus);
        }

        /// <summary>
        /// Creates StaticResourceBuildingsData with invalid ID (-1).
        /// This is used by <see cref="PropertyController"/> when creating
        /// new properties.
        /// </summary>
        /// <param name="name1">Name of lowest tier building type</param>
        /// <param name="name2">Name of second tier building type</param>
        /// <param name="name3">Name of third tier building type</param>
        /// <param name="name4">Name of highest tier building type</param>
        /// <param name="description">Description of building type</param>
        /// <param name="resourceID">The resource that this building will produce</param>
        /// <param name="buildingType">What type of building this is. Luxury type is bound to specific regions.</param>
        /// <param name="incomeBonus">Bonus that (probably) influences how many resources you get (needs verification)</param>
        /// <returns></returns>
        public static StaticResourceBuildingsData CreateStaticResourceBuildingsData (string name1, string name2, string name3, string name4, string description, int resourceID, int buildingType, float incomeBonus = 1f) {
            StaticResourceBuildingsData staticResourceBuildingsData = new StaticResourceBuildingsData();

            staticResourceBuildingsData.id = -1;
            staticResourceBuildingsData.id_ico_lvl1 = -1;
            staticResourceBuildingsData.id_ico_lvl2 = -1;
            staticResourceBuildingsData.id_ico_lvl3 = -1;
            staticResourceBuildingsData.id_ico_lvl4 = -1;

            staticResourceBuildingsData.name1 = name1;
            staticResourceBuildingsData.name2 = name2;
            staticResourceBuildingsData.name3 = name3;
            staticResourceBuildingsData.name4 = name4;
            staticResourceBuildingsData.des = description;
            staticResourceBuildingsData.resourse_id = resourceID;
            staticResourceBuildingsData.income_bonus = incomeBonus;
            staticResourceBuildingsData.building_type = buildingType;

            return staticResourceBuildingsData;
        }

    }

}
