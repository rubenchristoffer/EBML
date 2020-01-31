using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Reflection;
using System.Linq;

namespace EBML {

    /// <summary>
    /// This is the class that gets loaded
    /// by the AssemblyBootstrapper and is the
    /// starting point of the mod loader.
    /// </summary>
    public class ModLoaderEntry {

        private static Assembly csharpAssembly;
        private static GameObject gameObject;

        public static void OnInjection () {
            Directory.CreateDirectory(EBMLInfo.EBML_PATH);
            Directory.CreateDirectory(EBMLInfo.MODS_PATH);
            Directory.CreateDirectory(EBMLInfo.LOG_PATH);

            ModLoader.LogToFile("ModLoader has been injected.");

            if (Singletons.LOADER != null) {
                ModLoader.LogToFile("Loader is not null, so creating bootstrapper immediately");
                CreateBootstrapper();
            } else {
                ModLoader.LogToFile("Loader is null, so waiting a couple of seconds before trying again...");
                System.Threading.Thread.Sleep(2000);
                OnInjection();
            }
        }

        private static void CreateBootstrapper () {
            ModLoader.LogToFile("Creating new Bootstrapper GameObject...");
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