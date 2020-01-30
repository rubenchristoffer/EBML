using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBML;

namespace MyMod {

    public class TestMod : Mod {

        public override ModInfo modInfo {
            get {
                return new ModInfo("TestMod", "Mod to test out ModLoader", "v1.0");
            }
        }

        public override void OnLoad() {
            ModLoader.Log("TestMod: Setting up hooks");

            EBML.Hooks.LoaderHooks.StartLoadGameScene.AddPreHook((instance, isSavedGame) => {
                ModLoader.Log("Loading game scene...");
                ModLoader.Log(isSavedGame ? "It is a saved game" : "It is a brand new game");
            });

            EBML.Hooks.LoaderHooks.StartUnloadScene.AddPostHook((instance, sceneName, onUnloadFinished) => {
                ModLoader.Log("TestMod: Unloading scene " + sceneName);
            });

            EBML.Hooks.ResourceControllerHooks.CreateResources.AddPostHook((instance) => {
                ModLoader.Log("TestMod: Resources has been generated");
            });

            EBML.ModManagers.ModResources.onRegisteredNewResource += ModResources_onRegisteredNewResource;
                 
            ModLoader.Log("TestMod: Registering new resource");
            EBML.ModManagers.ModResources.RegisterNewResource (5000, "MyResource", 0, 500, 0);
        }

        private void ModResources_onRegisteredNewResource(int id, string name, int resource_type, int base_price, int turn_discovery) {
            ModLoader.Log("TestMod: Registered custom resource");
        }
    }

}
