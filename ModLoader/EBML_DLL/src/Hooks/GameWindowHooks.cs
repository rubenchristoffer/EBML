using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace EBML.Hooks {

    /// <summary>
    /// Method hooks for <see cref="GameWindow"/>.
    /// </summary>
	public class GameWindowHooks {

        /// <summary>
        /// The Unity <code>Start()</code> method.
        /// </summary>
        public static HookSystem<GameWindow> Start = new HookSystem<GameWindow>();

        /// <summary>
        /// <code>OnWindowShowing(object windowData)</code>. 
        /// This is shared by EVERY game window, so you could
        /// hook this and check if it's the type of window you are looking
        /// to actually hook using <see cref="GameWindow.type"/>.
        /// </summary>
        public static HookSystem<GameWindow, object> OnWindowShowing = new HookSystem<GameWindow, object>();

        [HarmonyPatch(typeof(GameWindow))]
		private class Patch {

            [HarmonyPatch("Start")]
            [HarmonyPrefix]
            static void StartPre(GameWindow __instance) {
                Start.InvokePreHooks(__instance);
            }

            [HarmonyPatch("Start")]
            [HarmonyPostfix]
            static void StartPost(GameWindow __instance) {
                Start.InvokePostHooks(__instance);
            }

            [HarmonyPatch("OnWindowShowing")]
            [HarmonyPrefix]
            static void OnWindowShowingPre(GameWindow __instance, ref object windowData) {
                OnWindowShowing.InvokePreHooks(__instance, windowData);
            }

            [HarmonyPatch("OnWindowShowing")]
            [HarmonyPostfix]
            static void OnWindowShowingPost(GameWindow __instance, ref object windowData) {
                OnWindowShowing.InvokePostHooks(__instance, windowData);
            }

        }

	}

}
