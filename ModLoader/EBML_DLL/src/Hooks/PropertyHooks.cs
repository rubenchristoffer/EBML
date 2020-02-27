using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Static;
using UnityEngine;

namespace EBML.Hooks {

	/// <summary>
	/// Method hooks for <see cref="Property"/>.
	/// </summary>
	public static class PropertyHooks {

        /// <summary>
        /// The <code>GetIcon()</code> method.
        /// NOTE: There is no post hooks for this method
        /// since return value is return before it will
        /// get there.
        /// </summary>
        public static HookSystem<Property, ReturnValue<Sprite>> GetIcon = new HookSystem<Property, ReturnValue<Sprite>>();

        [HarmonyPatch(typeof(Property))]
        private class Patch {

            [HarmonyPatch("GetIcon")]
            [HarmonyPrefix]
            static bool GetIconPre(Property __instance, ref Sprite __result) {
                ReturnValue<Sprite> returnValue = new ReturnValue<Sprite>(__result);
                GetIcon.InvokePreHooks(__instance, returnValue);

                return GetIcon.GetHarmonyReturnValue<Sprite>(ref __result, returnValue);
            }

        }

    }

}
