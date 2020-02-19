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

namespace EBML {

    /// <summary>
    /// This is the class responsible for
    /// actually loading mods, but also
    /// logging debug information to console
    /// and log file. 
    /// </summary>
    public static class ModLoader {

        /// <summary>
        /// This list contains all the loaded Mod instances.
        /// </summary>
        private static List<Mod> loadedMods = new List<Mod>();

        /// <summary>
        /// The Harmony object that handles all the method patches.
        /// It is in object form so that it doens't crash after being injected.
        /// </summary>
        private static object harmony;

        /// <summary>
        /// The ModGUI instance responsible for rendering
        /// the Console / Log GUI.
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
        /// The default Log function.
        /// This will log info to the Console GUI, but also
        /// the log file and it includes a timestamp.
        /// </summary>
        /// <param name="message">The message you want to log</param>
        public static void Log (string message) {
            LogToFile(message);
            modGUI.GetObject<GUIBox>("log").AppendLine(message);
        }

        /// <summary>
        /// This will log info to the log file and NOT
        /// to the Console GUI.
        /// This can be called before the ModLoader is initialized.
        /// </summary>
        /// <param name="message">The message you want to log</param>
        /// <param name="includeTimestamp">Should the timestamp be included or not?</param>
        public static void LogToFile (string message, bool includeTimestamp = true) {
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(System.IO.Path.Combine(ModPaths.LOG_PATH, DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), true)) {
                if (includeTimestamp)
                    outputFile.WriteLine(String.Format("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
                else
                    outputFile.WriteLine(message);
            }
        }

        /// <summary>
        /// Initializes the ModLoader by loading required assemblies
        /// and creates a new Log GUI.
        /// </summary>
        internal static void __Initialize() {
            ModLoader.LogToFile("Loading assembly Mono.Cecil.dll");
            Assembly.LoadFile(ModPaths.EBML_PATH + "Mono.Cecil.dll");

            ModLoader.LogToFile("Loading assembly 0Harmony.dll");
            Assembly.LoadFile(ModPaths.EBML_PATH + "0Harmony.dll");

            LogToFile("Creating new ModGUI");
            modGUI = new ModGUI();

            LogToFile("Adding Console GUI Object");
            modGUI.Add(new GUIBox("log", new Rect(Screen.width - 505, 5, 500, 500), ""));

            Log("ModLoader has been initialized!");
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
                    Log("Could not find entry point of mod at " + fullPath);
                    return;
                }

                Mod mod = (Mod)Activator.CreateInstance(modType);
                loadedMods.Add(mod);
                mod.OnLoad();

                Log("Loaded " + mod.modInfo.ToString());
            } catch (Exception e) {
                Log(e.ToString());
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
            Log("Injecting method hooks...");

            try {
                harmony = new Harmony("ModLoader");
                ((Harmony)harmony).PatchAll();

                Hooks.ManualHooks.InvokeInternalHooksEvent();
                Hooks.UnityResourcesHooks.CreateLoadHook();
            } catch (Exception e) {
                Log(e.ToString());
            }
        }

        /// <summary>
        /// Uninstalls the method hooks installed by the 
        /// __InstallMethodHooks function and also the registered
        /// manual hooks.
        /// </summary>
        internal static void __UninstallMethodHooks () {
            Hooks.ManualHooks.UnpatchAll();
            ((Harmony)harmony).UnpatchAll();
        }

        /// <summary>
        /// First calls the OnInit method for all mods,
        /// then proceeds to call the OnPostInit method
        /// for all mods
        /// </summary>
        internal static void __InitializeMods() {
            loadedMods.ForEach(mod => mod.OnInit());
            loadedMods.ForEach(mod => mod.OnPostInit());
        }

    }

}
