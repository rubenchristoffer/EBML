using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace EBML.Hooks {

	public class GameWindowHooks {

		public static HookSystem<GameWindow> Start = new HookSystem<GameWindow>();
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
