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

        public static StaticResourceData CreateStaticResourceData (string name, Resource.ResourceType resourceType, int basePrice, int turnDiscovery) {
            return CreateStaticResourceData(name, (int)resourceType, basePrice, turnDiscovery);
        }

        public static StaticResourceData CreateStaticResourceData(string name, int resourceType, int basePrice, int turnDiscovery) {
            StaticResourceData staticResourceData = new StaticResourceData();

            staticResourceData.id = -1;
            staticResourceData.name = name;
            staticResourceData.resourse_type = resourceType;
            staticResourceData.base_price = basePrice;
            staticResourceData.turn_discovery = turnDiscovery;

            return staticResourceData;
        }

        public static StaticResourceProductionData CreateStaticResourceProductionData (int workAmount, Turn.Season autoseedingSeason, int turnMaturation, int priceSeedingID1, float priceSeedingID1Amount, int priceSeedingID2, float priceSeedingID2Amount) {
            return CreateStaticResourceProductionData(workAmount, (int)autoseedingSeason, turnMaturation, priceSeedingID1, priceSeedingID1Amount, priceSeedingID2, priceSeedingID2Amount);
        }

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

    }

}
