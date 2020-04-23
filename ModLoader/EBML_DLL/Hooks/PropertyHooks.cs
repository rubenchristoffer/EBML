using HarmonyLib;
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
		public static HookSystem<Property, ReturnValue<Sprite>> GetIcon = new HookSystem<Property, ReturnValue<Sprite>> ();

#pragma warning disable IDE0051

		[HarmonyPatch (typeof (Property))]
		class Patch {

			[HarmonyPatch ("GetIcon")]
			[HarmonyPrefix]
			static bool GetIconPre (Property __instance, ref Sprite __result) {
				ReturnValue<Sprite> returnValue = new ReturnValue<Sprite> (__result);
				GetIcon.InvokePreHooks (__instance, returnValue);

				return GetIcon.GetHarmonyReturnValue<Sprite> (ref __result, returnValue);
			}

		}

#pragma warning restore IDE0051

	}

}