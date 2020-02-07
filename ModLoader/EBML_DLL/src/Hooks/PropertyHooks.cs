using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Static;

namespace EBML.Hooks {

	/// <summary>
	/// Method hooks for <see cref="Property"/>.
	/// </summary>
	public static class PropertyHooks {

        /// <summary>
        /// Constructor <code>Property()</code>.
        /// </summary>
        public static HookSystem<StaticResourceBuildingsData, Region, float> Constructor1 = new HookSystem<StaticResourceBuildingsData, Region, float>();

        [HarmonyPatch(typeof(Property))]
        private class Patch {

            [HarmonyPatch("Property")]
            [HarmonyPrefix]
            static void CreateConstructor1Pre(StaticResourceBuildingsData buildingData, Region region, float actualPriceBonus) {
                Constructor1.InvokePreHooks(buildingData, region, actualPriceBonus);
            }

            [HarmonyPatch("Property")]
            [HarmonyPostfix]
            static void CreateConstructor1Post(StaticResourceBuildingsData buildingData, Region region, float actualPriceBonus) {
                Constructor1.InvokePostHooks(buildingData, region, actualPriceBonus);
            }

        }

    }

}
