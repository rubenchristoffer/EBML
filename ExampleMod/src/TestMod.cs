using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBML;
using EBML.GameAPI;

namespace MyMod {

    public class TestMod : Mod {

        public override ModInfo modInfo {
            get {
                return new ModInfo("ExampleMod", "Mod to test out ModLoader", "v1.0");
            }
        }

        public override void OnLoad() {

        }

        public override void OnInit() {
            ModLoader.Log("Initializing new resource");

            int id = ModResources.RegisterNewResource(
                StructFactory.CreateStaticResourceData("Uranium", Resource.ResourceType.Luxury, 5, 0),
                ModFiles.CreateSprite(ModFiles.CreateTexture(ModFiles.ReadFileFromDisk(@"ExampleMod\uranium.png"))),
                true
            );

            ModResources.RegisterNewProductionResource(
                StructFactory.CreateStaticResourceData("Atom Bomb", Resource.ResourceType.Weapon, 1000000, 0),
                StructFactory.CreateStaticResourceProductionData (5, Turn.Season.None, 0, id, 5, 0, 0),
                ModFiles.CreateSprite(ModFiles.CreateTexture(ModFiles.ReadFileFromDisk(@"ExampleMod\atombomb.png")))
            );
        }

        public override void OnPostInit() {
            
        }

    }

}
