using HarmonyLib;

namespace EBML.Hooks {

	/// <summary>
	/// Method hooks for <see cref="Loader"/>.
	/// </summary>
	public static class LoaderHooks {

		/// <summary>
		/// The Unity <code>Start()</code> method.
		/// </summary>
		public static HookSystem<Loader> Start = new HookSystem<Loader> ();

		/// <summary>
		/// <code>StartLoadGameScene(bool isSavedGame)</code>.
		/// </summary>
		public static HookSystem<Loader, bool> StartLoadGameScene = new HookSystem<Loader, bool> ();

		/// <summary>
		/// <code>ContinueGame()</code>.
		/// </summary>
		public static HookSystem<Loader> ContinueGame = new HookSystem<Loader> ();

		/// <summary>
		/// <code>StartUnloadScene(string sceneName, System.Action onUnloadFinished)</code>.
		/// </summary>
		public static HookSystem<Loader, string, System.Action> StartUnloadScene = new HookSystem<Loader, string, System.Action> ();

		/// <summary>
		/// <code>SetActivity(bool value)</code>.
		/// </summary>
		public static HookSystem<Loader, bool> SetActivity = new HookSystem<Loader, bool> ();

#pragma warning disable IDE0051

		[HarmonyPatch (typeof (Loader))]
		class Patch {

			[HarmonyPatch ("StartLoadGameScene")]
			[HarmonyPrefix]
			static bool StartLoadGameScenePre (Loader __instance, ref bool isSavedGame) {
				StartLoadGameScene.InvokePreHooks (__instance, isSavedGame);

				return StartLoadGameScene.ResetOriginalMethodSkip ();
			}

			[HarmonyPatch ("StartLoadGameScene")]
			[HarmonyPostfix]
			static void StartLoadGameScenePost (Loader __instance, ref bool isSavedGame) {
				StartLoadGameScene.InvokePostHooks (__instance, isSavedGame);
			}

			[HarmonyPatch ("ContinueGame")]
			[HarmonyPrefix]
			static bool ContinueGamePre (Loader __instance) {
				ContinueGame.InvokePreHooks (__instance);

				return ContinueGame.ResetOriginalMethodSkip ();
			}

			[HarmonyPatch ("ContinueGame")]
			[HarmonyPostfix]
			static void ContinueGamePost (Loader __instance) {
				ContinueGame.InvokePostHooks (__instance);
			}

			[HarmonyPatch ("StartUnloadScene")]
			[HarmonyPrefix]
			static bool StartUnloadScenePre (Loader __instance, string sceneName, System.Action onUnloadFinished) {
				StartUnloadScene.InvokePreHooks (__instance, sceneName, onUnloadFinished);

				return StartUnloadScene.ResetOriginalMethodSkip ();
			}

			[HarmonyPatch ("StartUnloadScene")]
			[HarmonyPostfix]
			static void StartUnloadScenePost (Loader __instance, string sceneName, ref System.Action onUnloadFinished) {
				StartUnloadScene.InvokePostHooks (__instance, sceneName, onUnloadFinished);
			}

			[HarmonyPatch ("SetActivity")]
			[HarmonyPrefix]
			static bool SetActivityPre (Loader __instance, bool value) {
				SetActivity.InvokePreHooks (__instance, value);

				return SetActivity.ResetOriginalMethodSkip ();
			}

			[HarmonyPatch ("SetActivity")]
			[HarmonyPostfix]
			static void SetActivityPost (Loader __instance, bool value) {
				SetActivity.InvokePostHooks (__instance, value);
			}

		}

#pragma warning restore IDE0051

	}

}

