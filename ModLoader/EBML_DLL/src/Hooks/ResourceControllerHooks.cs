using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace EBML.Hooks {

    /// <summary>
    /// Method hooks for <see cref="ResourceController"/>.
    /// </summary>
    public class ResourceControllerHooks {

        /// <summary>
        /// The <code>CreateResources()</code> method.
        /// </summary>
        public static HookSystem<ResourceController> CreateResources = new HookSystem<ResourceController>();

        [HarmonyPatch(typeof(ResourceController))]
        private class Patch {

            [HarmonyPatch("CreateResources")]
            [HarmonyPrefix]
            static bool CreateResourcesPre(ResourceController __instance) {
                CreateResources.InvokePreHooks(__instance);

                return CreateResources.ResetOriginalMethodSkip();
            }

            [HarmonyPatch("CreateResources")]
            [HarmonyPostfix]
            static void CreateResourcesPost(ResourceController __instance) {
                CreateResources.InvokePostHooks(__instance);
            }

        }

    }

}
