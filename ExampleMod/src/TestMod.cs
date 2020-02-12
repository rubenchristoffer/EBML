using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBML;
using EBML.GameAPI;
using EBML.GameAPI.Extensions;

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

            Tuple<int, int> ids = ModResources.RegisterNewProductionResource(
                StructFactory.CreateStaticResourceData("Atom Bomb", Resource.ResourceType.Weapon, 1000000, 0),
                StructFactory.CreateStaticResourceProductionData (5, Turn.Season.None, 0, id, 5, 0, 0),
                ModFiles.CreateSprite(ModFiles.CreateTexture(ModFiles.ReadFileFromDisk(@"ExampleMod\atombomb.png")))
            );

            ModProperties.RegisterNewPropertyType(StructFactory.CreateStaticResourceBuildingsData(
                "n1", "n2", "n3", "n4", "custom property", id, Property.Type.Production),
                ModFiles.CreateSprite(ModFiles.CreateTexture(ModFiles.ReadFileFromDisk(@"ExampleMod\atombomb.png"))));
        }

        public override void OnPostInit() {
            Singletons.PROPERTY_CONTROLLER.GetStaticResourceBuildings().staticResourceBuildingsDataArr.ToList()
                .ForEach(srb => ModLoader.Log(string.Format("id: {0}, n1: {1}, n2: {2}, n3: {3}, n4: {4}, des: {5}, " +
                "res_id: {6}, income_bonus: {7}, building_type: {8}, id_lvl1: {9}, id_lvl2: {10}, id_lvl3: {11}, id_lvl4: {12}\n", srb.id, Singletons.LOCALIZATION_CONTROLLER.GetText(srb.name1), Singletons.LOCALIZATION_CONTROLLER.GetText(srb.name2), Singletons.LOCALIZATION_CONTROLLER.GetText(srb.name3), Singletons.LOCALIZATION_CONTROLLER.GetText(srb.name4),
                Singletons.LOCALIZATION_CONTROLLER.GetText(srb.des), srb.resourse_id, srb.income_bonus, (UserProperty.Type) srb.building_type, srb.id_ico_lvl1, srb.id_ico_lvl2, srb.id_ico_lvl3,
                srb.id_ico_lvl4)));
        }

    }

}
