using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace EBML {

    /// <summary>
    /// This is the class that gets loaded
    /// by the AssemblyBootstrapper and is the
    /// starting point of the mod loader.
    /// </summary>
    public class ModLoaderEntry {

        private static GameObject gameObject;

        public static void OnInjection () {
            Directory.CreateDirectory(EBMLInfo.EBML_PATH);
            Directory.CreateDirectory(EBMLInfo.MODS_PATH);
            Directory.CreateDirectory(EBMLInfo.LOG_PATH);

            ModLoader.LogToFile("ModLoader has been injected");

            ModLoader.LogToFile("Creating new GameObject...");
            gameObject = new GameObject();

            ModLoader.LogToFile("Enabling DontDestroyOnLoad");
            MonoBehaviour.DontDestroyOnLoad(gameObject);

            ModLoader.LogToFile("Setting up MonoBehaviour callbacks");
            MonoBehaviourCallbacks.awake += Awake;

            // Initialize mono behaviour callbacks
            gameObject.AddComponent<MonoBehaviourCallbacks>();
        }

        private static void Awake () {
            ModLoader.LogToFile("ModLoaderEntry Awake has been invoked");

            // We only want to call this code ONCE
            MonoBehaviourCallbacks.awake -= Awake;

            // Initialize ModLoader
            ModLoader.Initialize();

            ModLoader.LogToFile("Attemping to install method hooks...");

            // Inject method hooks into game assembly
            ModLoader.InstallMethodHooks();

            // Load mods into memory
            ModLoader.LoadMods();

            // Start all mods
            //ModLoader.StartMods();
        }

        public static void OnEjection () {
            MonoBehaviour.Destroy(gameObject);
        }

    }

}