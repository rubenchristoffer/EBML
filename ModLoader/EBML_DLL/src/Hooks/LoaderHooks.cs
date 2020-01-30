﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace EBML.Hooks {

    public class LoaderHooks {

        public static HookSystem<Loader> Start = new HookSystem<Loader>();

        /// <summary>
        /// bool stands for 'isSavedgame'.
        /// </summary>
        public static HookSystem<Loader, bool> StartLoadGameScene = new HookSystem<Loader, bool>();
        public static HookSystem<Loader> ContinueGame = new HookSystem<Loader>();
        public static HookSystem<Loader, string, System.Action> StartUnloadScene = new HookSystem<Loader, string, System.Action>();
        public static HookSystem<Loader, bool> SetActivity = new HookSystem<Loader, bool>();

        [HarmonyPatch(typeof(Loader))]
        private class Patch {

            [HarmonyPatch("Start")]
            [HarmonyPrefix]
            static void StartPre(Loader __instance) {
                Start.InvokePreHooks(__instance);
            }

            [HarmonyPatch("Start")]
            [HarmonyPostfix]
            static void StartPost(Loader __instance) {
                Start.InvokePostHooks(__instance);
            }

            [HarmonyPatch("StartLoadGameScene")]
            [HarmonyPrefix]
            static void StartLoadGameScenePre(Loader __instance, ref bool isSavedGame) {
                StartLoadGameScene.InvokePreHooks(__instance, isSavedGame);
            }

            [HarmonyPatch("StartLoadGameScene")]
            [HarmonyPostfix]
            static void StartLoadGameScenePost(Loader __instance, ref bool isSavedGame) {
                StartLoadGameScene.InvokePostHooks(__instance, isSavedGame);
            }

            [HarmonyPatch("ContinueGame")]
            [HarmonyPrefix]
            static void ContinueGamePre(Loader __instance) {
                ContinueGame.InvokePreHooks(__instance);
            }

            [HarmonyPatch("ContinueGame")]
            [HarmonyPostfix]
            static void ContinueGamePost(Loader __instance) {
                ContinueGame.InvokePostHooks(__instance);
            }

            [HarmonyPatch("StartUnloadScene")]
            [HarmonyPrefix]
            static void StartUnloadScenePre(Loader __instance, ref string sceneName, ref System.Action onUnloadFinished) {
                StartUnloadScene.InvokePreHooks(__instance, sceneName, onUnloadFinished);
            }

            [HarmonyPatch("StartUnloadScene")]
            [HarmonyPostfix]
            static void StartUnloadScenePost(Loader __instance, ref string sceneName, ref System.Action onUnloadFinished) {
                StartUnloadScene.InvokePostHooks(__instance, sceneName, onUnloadFinished);
            }

            [HarmonyPatch("SetActivity")]
            [HarmonyPrefix]
            static void SetActivityPre(Loader __instance, ref bool value) {
                SetActivity.InvokePreHooks(__instance, value);
            }

            [HarmonyPatch("SetActivity")]
            [HarmonyPostfix]
            static void SetActivityPost(Loader __instance, ref bool value) {
                SetActivity.InvokePostHooks(__instance, value);
            }

        }

    }

}