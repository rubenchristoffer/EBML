using HarmonyLib;

namespace EBML.Hooks {

	/// <summary>
	/// Method hooks for <see cref="ResourceController"/>.
	/// </summary>
	public static class ResourceControllerHooks {

		/// <summary>
		/// The <code>CreateResources()</code> method.
		/// </summary>
		public static HookSystem<ResourceController> CreateResources = new HookSystem<ResourceController> ();

#pragma warning disable IDE0051

		[HarmonyPatch (typeof (ResourceController))]
		class Patch {

			[HarmonyPatch ("CreateResources")]
			[HarmonyPrefix]
			static bool CreateResourcesPre (ResourceController __instance) {
				CreateResources.InvokePreHooks (__instance);

				return CreateResources.ResetOriginalMethodSkip ();
			}

			[HarmonyPatch ("CreateResources")]
			[HarmonyPostfix]
			static void CreateResourcesPost (ResourceController __instance) {
				CreateResources.InvokePostHooks (__instance);
			}

		}

#pragma warning restore IDE0051

	}

}