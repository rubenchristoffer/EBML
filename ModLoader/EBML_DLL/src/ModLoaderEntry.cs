using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Reflection;
using System.Linq;
using EBML.Logging;

namespace EBML {

    /// <summary>
    /// This is the entry point for the EBML DLL
    /// and API
    /// </summary>
    static class ModLoaderEntry {

        private static readonly ILog log = LogFactory.GetLogger(typeof(ModLoaderEntry));

        /// <summary>
        /// The 'Bootstrapper' gameObject that is used to ensure
        /// that the ModLoader code is executed on the Unity thread.
        /// The MonoBehaviourCallbacks component is attached to this gameObject.
        /// </summary>
        static GameObject bootstrapperGameObject;

        /// <summary>
        /// This will be called by injector
        /// after assembly is injected.
        /// </summary>
        static void OnInjection () {
            // Create required directories if they do not exist
            ModPaths.CreateAllModPaths();

            log.Info("### New Session ###");
            log.Info("ModLoader has been injected.");

            WaitUntilLoaderIsPresent();

            log.Info("Loader is present (not null), so creating bootstrapper");
            CreateBootstrapper();
        }

        /// <summary>
        /// This will simply wait until the Loader
        /// singleton is initialized. This is to ensure
        /// that nothing is affecting game before it is 
        /// properly loaded.
        /// </summary>
        static void WaitUntilLoaderIsPresent () {
            if (Singletons.LOADER == null) {
                log.Info("Loader is null, so waiting a couple of seconds before checking again...");
                System.Threading.Thread.Sleep(2000);
                WaitUntilLoaderIsPresent();
            }
        }

        /// <summary>
        /// Create a Bootstrapper gameobject in order to ensure
        /// that code will be executed by the Unity Thread
        /// </summary>
        static void CreateBootstrapper () {
            log.Info("Creating new Bootstrapper GameObject...");
            bootstrapperGameObject = new GameObject("ModLoader");

            log.Info("Enabling DontDestroyOnLoad");
            MonoBehaviour.DontDestroyOnLoad(bootstrapperGameObject);

            log.Info("Setting up MonoBehaviour callbacks");
            MonoBehaviourCallbacks.start += Bootstrapper_Start;

            // Initialize mono behaviour callbacks
            bootstrapperGameObject.AddComponent<MonoBehaviourCallbacks>();
        }

        /// <summary>
        /// This is called using a MonoBehaviourCallback
        /// and is therefore guaranteed to be run on the Unity
        /// thread.
        /// </summary>
        static void Bootstrapper_Start () {
            log.Info("ModLoaderEntry Start has been invoked");

            // We only want to call this code ONCE
            MonoBehaviourCallbacks.start -= Bootstrapper_Start;

            log.Info("Initializing ModLoader...");
            ModLoader.__Initialize();

            try {
                // Wrap all of this in a try-catch in order to
                // try and prevent game from crashing if anything goes wrong
                // (there is a real possibility that it will crash anyway)

                log.Info("Attemping to install method hooks...");
                ModLoader.__InstallMethodHooks();

                log.Info("Loading mods...");
                ModLoader.__LoadMods();

                log.Info("Initializing mods...");
                ModLoader.__InitializeMods();
            } catch (Exception e) {
                log.Error("Something went wrong initializing ModLoader", e);
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