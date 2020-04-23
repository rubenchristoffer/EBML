using HarmonyLib;

namespace EBML.Hooks {

	/// <summary>
	/// Method hooks for <see cref="WeaponCraftWindow"/>.
	/// </summary>
	public static class WeaponCraftWindowHooks {

		/// <summary>
		/// The Unity <code>Awake()</code> method.
		/// </summary>
		public static HookSystem<WeaponCraftWindow> Awake = new HookSystem<WeaponCraftWindow> ();

		/// <summary>
		/// <code>GetResourceUsedCount(int resourceID) : long</code>.
		/// </summary>
		public static HookSystem<WeaponCraftWindow, ReturnValue<long>, int> GetResourceUsedCount = new HookSystem<WeaponCraftWindow, ReturnValue<long>, int> ();

#pragma warning disable IDE0051

		[HarmonyPatch (typeof (WeaponCraftWindow))]
		private class Patch {

			[HarmonyPatch ("Awake")]
			[HarmonyPrefix]
			static bool AwakePre (WeaponCraftWindow __instance) {
				Awake.InvokePreHooks (__instance);

				return Awake.ResetOriginalMethodSkip ();
			}

			[HarmonyPatch ("Awake")]
			[HarmonyPostfix]
			static void AwakePost (WeaponCraftWindow __instance) {
				Awake.InvokePostHooks (__instance);
			}

			[HarmonyPatch ("GetResourceUsedCount")]
			[HarmonyPrefix]
			static bool GetResourceUsedCountPre (WeaponCraftWindow __instance, ref long __result, int resourceId) {
				ReturnValue<long> returnValue = new ReturnValue<long> (__result);
				GetResourceUsedCount.InvokePreHooks (__instance, returnValue, resourceId);

				return GetResourceUsedCount.GetHarmonyReturnValue<long> (ref __result, returnValue);
			}

			[HarmonyPatch ("GetResourceUsedCount")]
			[HarmonyPostfix]
			static void GetResourceUsedCountPost (WeaponCraftWindow __instance, ref long __result, int resourceId) {
				GetResourceUsedCount.InvokePostHooks (__instance, new ReturnValue<long> (__result), resourceId);
			}

		}

#pragma warning restore IDE0051

	}

}

