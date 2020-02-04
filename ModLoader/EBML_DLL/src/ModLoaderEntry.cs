using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Reflection;
using System.Linq;
using EBML.GameAPI.Extensions;

namespace EBML {

    /// <summary>
    /// This is the class that gets loaded
    /// by the AssemblyBootstrapper and is the
    /// starting point of the mod loader.
    /// </summary>
    public class ModLoaderEntry {

        /// <summary>
        /// The 'Bootstrapper' gameObject that is used to ensure
        /// that the ModLoader code is executed on the Unity thread
        /// </summary>
        public static GameObject bootstrapperGameObject { get; private set; }

        private static void OnInjection () {
            Directory.CreateDirectory(EBMLInfo.EBML_PATH);
            Directory.CreateDirectory(EBMLInfo.MODS_PATH);
            Directory.CreateDirectory(EBMLInfo.LOG_PATH);

            ModLoader.LogToFile("", false);
            ModLoader.LogToFile("### New Session ###");
            ModLoader.LogToFile("ModLoader has been injected.");

            WaitUntilLoaderIsPresent();

            ModLoader.LogToFile("Loader is present (not null), so creating bootstrapper");
            CreateBootstrapper();
        }

        private static void WaitUntilLoaderIsPresent () {
            if (Singletons.LOADER == null) {
                ModLoader.LogToFile("Loader is null, so waiting a couple of seconds before checking again...");
                System.Threading.Thread.Sleep(2000);
                WaitUntilLoaderIsPresent();
            }
        }

        // Create a Bootstrapper gameobject in order to ensure
        // that code will be executed by the Unity Thread
        private static void CreateBootstrapper () {
            ModLoader.LogToFile("Creating new Bootstrapper GameObject...");
            bootstrapperGameObject = new GameObject("ModLoader");

            ModLoader.LogToFile("Enabling DontDestroyOnLoad");
            MonoBehaviour.DontDestroyOnLoad(bootstrapperGameObject);

            ModLoader.LogToFile("Setting up MonoBehaviour callbacks");
            MonoBehaviourCallbacks.awake += Bootstrapper_Awake;

            // Initialize mono behaviour callbacks
            bootstrapperGameObject.AddComponent<MonoBehaviourCallbacks>();
        }

        private static void Bootstrapper_Awake () {
            ModLoader.LogToFile("ModLoaderEntry Awake has been invoked");

            // We only want to call this code ONCE
            MonoBehaviourCallbacks.awake -= Bootstrapper_Awake;

            // Initialize ModLoader
            ModLoader.__Initialize();

            ModLoader.LogToFile("Attemping to install method hooks...");

            try {
                // Inject method hooks into game assembly
                ModLoader.__InstallMethodHooks();

                // Load mods into memory
                ModLoader.__LoadMods();

                ModLoader.LogToFile("Initializing mods...");

                // Initialize mods
                ModLoader.__InitMods();
            } catch (Exception e) {
                ModLoader.Log(e.ToString());
            }

            Hooks.MapControllerHooks.GenerateStartMap.AddPostHook((instance) => {
                ModLoader.LogToFile(SceneMapper.GetAllMonobehavioursInScene());
            });

            /*Singletons.RESOURCE_CONTROLLER.GetStaticResourceProduction().staticResourceProductionDataArr
                .ToList()
                .ForEach(srp => ModLoader.Log(String.Format("ID: {0}, RES_ID: {1}, WORK: {2}, TURN_MAT: {3}, PRICE_ID1: {4}, PRICE_ID1_AMOUNT: {5}, PRICE_ID2: {6}, PRICE_ID2_AMOUNT: {7}", srp.id, srp.resourse_id, srp.work_amount, srp.turn_maturation, srp.price_seeding_id1, srp.price_seeding_id1_amount, srp.price_seeding_id2, srp.price_seeding_id2_amount)));

            Singletons.RESOURCE_CONTROLLER.GetStaticResource().staticResourceDataArr
                .ToList()
                .ForEach(sr => ModLoader.Log(String.Format("Res: {0}, {1}", sr.id, Singletons.LOCALIZATION_CONTROLLER.GetText(sr.name))));*/
        }

        public static void OnEjection () {
            MonoBehaviour.Destroy(bootstrapperGameObject);
        }

    }

}