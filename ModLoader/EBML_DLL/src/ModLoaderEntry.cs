using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Reflection;
using System.Linq;

namespace EBML {

    /// <summary>
    /// This is the entry point for the EBML DLL
    /// and API
    /// </summary>
    public class ModLoaderEntry {

        /// <summary>
        /// The 'Bootstrapper' gameObject that is used to ensure
        /// that the ModLoader code is executed on the Unity thread.
        /// The MonoBehaviourCallbacks component is attached to this gameObject.
        /// </summary>
        public static GameObject bootstrapperGameObject { get; private set; }

        /// <summary>
        /// This will be called by injector
        /// after assembly is injected.
        /// </summary>
        static void OnInjection () {
            Directory.CreateDirectory(ModPaths.EBML_PATH);
            Directory.CreateDirectory(ModPaths.MODS_PATH);
            Directory.CreateDirectory(ModPaths.LOG_PATH);

            ModLoader.LogToFile("", false);
            ModLoader.LogToFile("### New Session ###");
            ModLoader.LogToFile("ModLoader has been injected.");

            WaitUntilLoaderIsPresent();

            ModLoader.LogToFile("Loader is present (not null), so creating bootstrapper");
            CreateBootstrapper();
        }

        /// <summary>
        /// This will simply wait until the Loader
        /// singleton is initialized. This is to ensure
        /// that nothing is affecting game before it is 
        /// properly loaded.
        /// </summary>
        private static void WaitUntilLoaderIsPresent () {
            if (Singletons.LOADER == null) {
                ModLoader.LogToFile("Loader is null, so waiting a couple of seconds before checking again...");
                System.Threading.Thread.Sleep(2000);
                WaitUntilLoaderIsPresent();
            }
        }

        /// <summary>
        /// Create a Bootstrapper gameobject in order to ensure
        /// that code will be executed by the Unity Thread
        /// </summary>
        private static void CreateBootstrapper () {
            ModLoader.LogToFile("Creating new Bootstrapper GameObject...");
            bootstrapperGameObject = new GameObject("ModLoader");

            ModLoader.LogToFile("Enabling DontDestroyOnLoad");
            MonoBehaviour.DontDestroyOnLoad(bootstrapperGameObject);

            ModLoader.LogToFile("Setting up MonoBehaviour callbacks");
            MonoBehaviourCallbacks.start += Bootstrapper_Start;

            // Initialize mono behaviour callbacks
            bootstrapperGameObject.AddComponent<MonoBehaviourCallbacks>();
        }

        /// <summary>
        /// This is called using a MonoBehaviourCallback
        /// and is therefore guaranteed to be run on the Unity
        /// thread.
        /// </summary>
        private static void Bootstrapper_Start () {
            ModLoader.LogToFile("ModLoaderEntry Start has been invoked");

            // We only want to call this code ONCE
            MonoBehaviourCallbacks.start -= Bootstrapper_Start;

            ModLoader.LogToFile("Initializing ModLoader...");
            ModLoader.__Initialize();

            try {
                // Wrap all of this in a try-catch in order to
                // try and prevent game from crashing if anything goes wrong
                // (there is a real possibility that it will crash anyway)

                ModLoader.Log("Attemping to install method hooks...");
                ModLoader.__InstallMethodHooks();

                ModLoader.Log("Loading mods...");
                ModLoader.__LoadMods();

                ModLoader.LogToFile("Initializing mods...");
                ModLoader.__InitializeMods();
            } catch (Exception e) {
                ModLoader.Log(e.ToString());
            }
        }

        /// <summary>
        /// This will be called by ejector
        /// before assembly is ejected.
        /// </summary>
        static void OnEjection () {
            ModLoader.__UninstallMethodHooks();
            MonoBehaviour.Destroy(bootstrapperGameObject);
        }

    }

}