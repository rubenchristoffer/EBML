﻿using HarmonyLib;

namespace EBML.Hooks {

	/// <summary>
	/// Method hooks for <see cref="MapController"/>.
	/// </summary>
	public static class MapControllerHooks {

		/// <summary>
		/// <code>GenerateStartMap()</code>.
		/// </summary>
		public static HookSystem<MapController> GenerateStartMap = new HookSystem<MapController> ();

		[HarmonyPatch (typeof (MapController))]
		private class Patch {

			[HarmonyPatch ("GenerateStartMap")]
			[HarmonyPrefix]
			static bool GenStartMapPre (MapController __instance) {
				GenerateStartMap.InvokePreHooks (__instance);

				return GenerateStartMap.ResetOriginalMethodSkip ();
			}

			[HarmonyPatch ("GenerateStartMap")]
			[HarmonyPostfix]
			static void GenStartMapPost (MapController __instance) {
				GenerateStartMap.InvokePostHooks (__instance);
			}

		}

	}

}
