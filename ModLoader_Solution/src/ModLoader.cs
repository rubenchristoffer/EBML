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

        public static void Initialize () {
            LogToFile("Loading assembly Mono.Cecil.dll");
            Assembly.LoadFile(EBMLInfo.EBML_PATH + "Mono.Cecil.dll");

            LogToFile("Loading assembly 0Harmony.dll");
            Assembly.LoadFile(EBMLInfo.EBML_PATH + "0Harmony.dll");

            LogToFile("Creating new ModGUI");
            modGUI = new ModGUI();

            LogToFile("Adding Console GUI Object");
            modGUI.Add(new GUIBox("log", new Rect(Screen.width - 505, 5, 500, 500), ""));

            Log("ModLoader has been initialized!");
        }

        public static void LoadMods () {
            Log("Loading mods...");

            foreach (string dll in GetDLLsInModsFolder()) {
                LoadMod(dll);
            }
        }

        public static void LoadMod (string fullPath) {
            try {
                Assembly assembly = Assembly.LoadFile(fullPath);

                Type modType = assembly.GetTypes()
                    .Where(type => type.IsSubclassOf(typeof(Mod)))
                    .First();

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
        public static string[] GetDLLsInModsFolder () {
            return Directory
                .EnumerateFiles(EBMLInfo.MODS_PATH, "*.*", SearchOption.AllDirectories)
                .Where(file => Path.GetExtension(file).ToLowerInvariant().Equals(".dll"))
                .ToArray();
        }

        public static ModInfo[] GetLoadedModsInfo () {
            return loadedMods.Select(mod => mod.modInfo).ToArray();
        }

        public static void InstallMethodHooks () {
            LogToFile("Well, at least it called the function");
            Log("Injecting method hooks...");

            try {
                Harmony harmony = new Harmony("ModLoader");
                harmony.PatchAll();
            } catch (Exception e) {
                Log(e.ToString());
            }
        }

        public static void StartMods() {
            ModManagers.ModResources.ReInitResources();

            loadedMods.ForEach(mod => mod.OnStart());
        }

        public static void Log (string message) {
            LogToFile(message);
            modGUI.GetObject<GUIBox>("log").AppendLine(message);
        }

        public static void LogToFile (string message) {
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(System.IO.Path.Combine(EBMLInfo.LOG_PATH, DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), true)) {
                outputFile.WriteLine("[" + System.DateTime.Now.ToString() + "]: " + message);
            }
        }

    }

}
