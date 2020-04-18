using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using UnityEngine;
using HarmonyLib;
using EBML.GUI;
using EBML.Logging;

namespace EBML {

    /// <summary>
    /// This is the class responsible for
    /// actually loading mods
    /// </summary>
    public static class ModLoader {

        private static readonly ILog log = LogFactory.GetLogger(typeof(ModLoader));

        /// <summary>
        /// This list contains all the loaded Mod instances.
        /// </summary>
        private static List<Mod> loadedMods = new List<Mod>();

        /// <summary>
        /// The Harmony object that handles all the method patches.
        /// It is in object form so that it doesn't crash after being injected.
        /// </summary>
        private static object harmony;

        /// <summary>
        /// The ModGUI instance responsible for rendering
        /// the Console / log.Info GUI.
        /// </summary>
        public static ModGUI modGUI { get; private set; }

        /// <summary>
        /// Gets mod info for all the loaded mods.
        /// </summary>
        /// <returns>A ModInfo array containing info about loaded mods</returns>
        public static ModInfo[] GetLoadedModsInfo () {
            return loadedMods.Select(mod => mod.modInfo).ToArray();
        }

        /// <summary>
        /// Initializes the ModLoader by loading required assemblies
        /// and creates a new log.Info GUI.
        /// </summary>
        internal static void __Initialize() {
            log.Info("Loading assembly Mono.Cecil.dll");
            Assembly.LoadFile(ModPaths.EBML_PATH + "Mono.Cecil.dll");

            log.Info("Loading assembly 0Harmony.dll");
            Assembly.LoadFile(ModPaths.EBML_PATH + "0Harmony.dll");

            log.Info("Creating new ModGUI");
            modGUI = new ModGUI();

            log.Info("Adding Console GUI Object");
            GUIBox logBox = new GUIBox("log", new Rect(Screen.width - 505f, (int)((Screen.height - 500f) / 2f), 500, 500), "");

            GUIButton btn = new GUIButton("btn", logBox.bounds.FromAnchor(GUIExtensionMethods.AnchorX.RIGHT, GUIExtensionMethods.AnchorY.CENTER, new Vector2(20, 20)), "_", () => {
                logBox.enabled = !logBox.enabled;
            });

            modGUI.Add(logBox, btn);

            log.Info("Bounds: " + logBox.bounds.FromAnchor(GUIExtensionMethods.AnchorX.RIGHT, GUIExtensionMethods.AnchorY.CENTER, new Vector2(20, 20)));

            log.Info("ModLoader has been initialized!");
        }

        /// <summary>
        /// Loads all DLLs it can find in the Mods directory and sub-directories.
        /// </summary>
        internal static void __LoadMods() {
            foreach (string dll in __GetDLLsInModsFolder()) {
                __LoadMod(dll);
            }
        }

        /// <summary>
        /// Loads a single mod DLL based on full path
        /// </summary>
        /// <param name="fullPath">Full path to file</param>
        internal static void __LoadMod(string fullPath) {
            try {
                Assembly assembly = Assembly.LoadFile(fullPath);

                Type modType = assembly.GetTypes()
                    .Where(type => type.IsSubclassOf(typeof(Mod)))
                    .First();

                if (modType == null) {
                    log.Error("Could not find entry point of mod at " + fullPath);
                    return;
                }

                Mod mod = (Mod)Activator.CreateInstance(modType);
                loadedMods.Add(mod);
                mod.OnLoad();

                log.Info("Loaded " + mod.modInfo.ToString());
            } catch (Exception e) {
                log.Error(String.Format("Something went wrong loading mod '{0}'", fullPath), e);
            }
        }

        /// <summary>
        /// Gets all files with extension .dll in the mods
        /// directory and sub-directories.
        /// </summary>
        /// <returns>String array containing full paths to DLLs</returns>
        internal static string[] __GetDLLsInModsFolder() {
            return Directory
                .EnumerateFiles(ModPaths.MODS_PATH, "*.*", SearchOption.AllDirectories)
                .Where(file => Path.GetExtension(file).ToLowerInvariant().Equals(".dll"))
                .ToArray();
        }

        /// <summary>
        /// Install method hooks using the Harmony library.
        /// It will look for all [HarmonyPatch] attributes
        /// in order to decide what will get patched.
        /// All of these patches are done within the Hooks
        /// namespace.
        /// </summary>
        internal static void __InstallMethodHooks() {
            log.Info("Injecting method hooks...");

            try {
                harmony = new Harmony("ModLoader");
                ((Harmony)harmony).PatchAll();
            } catch (Exception e) {
                log.Error("Something went wrong installing method hooks", e);
            }
        }

        /// <summary>
        /// Uninstalls the method hooks installed by the 
        /// __InstallMethodHooks function
        /// </summary>
        internal static void __UninstallMethodHooks () {
            ((Harmony)harmony).UnpatchAll();
        }

        /// <summary>
        /// First calls the OnInit method for all mods,
        /// then proceeds to call the OnPostInit method
        /// for all mods
        /// </summary>
        internal static void __InitializeMods() {
            foreach (Mod mod in loadedMods) {
                try {
                    mod.OnInit();
                } catch (Exception e) {
                    log.Error("Something went wrong in OnInit method for mod " + mod.modInfo.name, e);
                }
            }

            foreach (Mod mod in loadedMods) {
                try {
                    mod.OnPostInit();
                } catch (Exception e) {
                    log.Error("Something went wrong in OnPostInit method for mod " + mod.modInfo.name, e);
                }
            }
        }

    }

}
