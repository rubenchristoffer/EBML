using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using System.Reflection;

namespace EBML.Hooks {

    public class MapControllerHooks {

        public static HookSystem<MapController> GenerateStartMap = new HookSystem<MapController>();

        [HarmonyPatch(typeof(MapController))]
        private class Patch {

            [HarmonyPatch("GenerateStartMap")]
            [HarmonyPrefix]
            static void GenStartMapPre(MapController __instance) {
                GenerateStartMap.InvokePreHooks(__instance);
            }

            [HarmonyPatch("GenerateStartMap")]
            [HarmonyPostfix]
            static void GenStartMapPost(MapController __instance) {
                GenerateStartMap.InvokePostHooks(__instance);
            }

        }

    }

}
