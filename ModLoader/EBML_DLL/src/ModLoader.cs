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

    public static class ModLoader {

        private static List<Mod> loadedMods = new List<Mod>();

        public static ModGUI modGUI { get; private set; }

        public static void __Initialize () {
            ModLoader.LogToFile("Loading assembly Mono.Cecil.dll");
            Assembly.LoadFile(EBMLInfo.EBML_PATH + "Mono.Cecil.dll");

            ModLoader.LogToFile("Loading assembly 0Harmony.dll");
            Assembly.LoadFile(EBMLInfo.EBML_PATH + "0Harmony.dll");

            LogToFile("Creating new ModGUI");
            modGUI = new ModGUI();

            LogToFile("Adding Console GUI Object");
            modGUI.Add(new GUIBox("log", new Rect(Screen.width - 505, 5, 500, 500), ""));

            Log("ModLoader has been initialized!");
        }

        public static void __LoadMods () {
            Log("Loading mods...");

            foreach (string dll in __GetDLLsInModsFolder()) {
                __LoadMod(dll);
            }
        }

        public static void __LoadMod (string fullPath) {
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

        // Later create a custom mod config file
        // because it might need dependencies that need to load first
        public static string[] __GetDLLsInModsFolder () {
            return Directory
                .EnumerateFiles(EBMLInfo.MODS_PATH, "*.*", SearchOption.AllDirectories)
                .Where(file => Path.GetExtension(file).ToLowerInvariant().Equals(".dll"))
                .ToArray();
        }

        public static ModInfo[] __GetLoadedModsInfo () {
            return loadedMods.Select(mod => mod.modInfo).ToArray();
        }

        public static void __InstallMethodHooks () {
            Log("Injecting method hooks...");

            try {
                Harmony harmony = new Harmony("ModLoader");
                harmony.PatchAll();
            } catch (Exception e) {
                Log(e.ToString());
            }
        }

        public static void __InitMods() {
            loadedMods.ForEach(mod => mod.OnInit());
            //ModManagers.ModResources.ReInitResources();
            loadedMods.ForEach(mod => mod.OnPostInit());
        }

        public static void Log (string message) {
            LogToFile(message);
            modGUI.GetObject<GUIBox>("log").AppendLine(message);
        }

        public static void LogToFile (string message, bool includeTimestamp = true) {
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(System.IO.Path.Combine(EBMLInfo.LOG_PATH, DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), true)) {
                if (includeTimestamp)
                    outputFile.WriteLine(String.Format("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
                else
                    outputFile.WriteLine(message);
            }
        }

    }

}
