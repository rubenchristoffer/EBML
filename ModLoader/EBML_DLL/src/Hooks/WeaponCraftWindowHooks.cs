using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace EBML.Hooks {

    /// <summary>
    /// Method hooks for <see cref="WeaponCraftWindow"/>.
    /// </summary>
	public class WeaponCraftWindowHooks {

        /// <summary>
        /// The Unity <code>Awake()</code> method.
        /// </summary>
		public static HookSystem<WeaponCraftWindow> Awake = new HookSystem<WeaponCraftWindow>();

        /// <summary>
        /// <code>GetResourceUsedCount(int resourceID) : long</code>.
        /// </summary>
        public static HookSystem<WeaponCraftWindow, long, int> GetResourceUsedCount = new HookSystem<WeaponCraftWindow, long, int>();

        [HarmonyPatch(typeof (WeaponCraftWindow))]
		private class Patch {

            [HarmonyPatch("Awake")]
            [HarmonyPrefix]
            static void AwakePre(WeaponCraftWindow __instance) {
                Awake.InvokePreHooks(__instance);
            }

            [HarmonyPatch("Awake")]
            [HarmonyPostfix]
            static void AwakePost(WeaponCraftWindow __instance) {
                Awake.InvokePostHooks(__instance);
            }

            [HarmonyPatch("GetResourceUsedCount")]
            [HarmonyPrefix]
            static void GetResourceUsedCountPre(WeaponCraftWindow __instance, ref long __result, ref int resourceId) {
                GetResourceUsedCount.InvokePreHooks(__instance, __result, resourceId);
            }

            [HarmonyPatch("GetResourceUsedCount")]
            [HarmonyPostfix]
            static void GetResourceUsedCountPost(WeaponCraftWindow __instance, ref long __result, ref int resourceId) {
                GetResourceUsedCount.InvokePostHooks(__instance, __result, resourceId);
            }

        }

	}

}
