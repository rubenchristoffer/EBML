using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using System.Reflection;

namespace EBML.Hooks {

    /// <summary>
    /// Method hooks for <see cref="MapController"/>.
    /// </summary>
    public class MapControllerHooks {

        /// <summary>
        /// <code>GenerateStartMap()</code>.
        /// </summary>
        public static HookSystem<MapController> GenerateStartMap = new HookSystem<MapController>();

        [HarmonyPatch(typeof(MapController))]
        private class Patch {

            [HarmonyPatch("GenerateStartMap")]
            [HarmonyPrefix]
            static bool GenStartMapPre(MapController __instance) {
                GenerateStartMap.InvokePreHooks(__instance);

                return GenerateStartMap.ResetOriginalMethodSkip();
            }

            [HarmonyPatch("GenerateStartMap")]
            [HarmonyPostfix]
            static void GenStartMapPost(MapController __instance) {
                GenerateStartMap.InvokePostHooks(__instance);
            }

        }

    }

}
