using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBML.GameAPI.Extensions;
using Static;
using UnityEngine;

namespace EBML.GameAPI {

    /// <summary>
    /// This class should be used by mods to register new
    /// properties to the game.
    /// </summary>
    public static class ModProperties {

        /// <summary>
        /// The ID that the next modded property object will have
        /// </summary>
        public static int nextResourceBuildingID { get; private set; }

        static ModProperties () {
            nextResourceBuildingID = 42;
        }

        /// <summary>
        /// This will register a new property type. In other words,
        /// this allows you to create your own custom property.
        /// You can make it produce your own custom resource as well.
        /// Note that if you select the Luxury type it will only be available
        /// in countries that have that luxury. Note that there are 4
        /// different types of each property, each with their own name, that
        /// represents the level they are at. If you only want one level you
        /// can fill in the same name / icon sprites in all those fields.
        /// </summary>
        /// <param name="staticResourceBuildingsData">Property information</param>
        /// <param name="icons">Optional icons for the various stages of this property</param>
        /// <returns>ID of the new property type</returns>
        public static int RegisterNewPropertyType(StaticResourceBuildingsData staticResourceBuildingsData, ModAssetSet4<Sprite> icons = null) {
            staticResourceBuildingsData.id = nextResourceBuildingID;

            if (icons != null) {
                for (int i = 0; i < icons.assets.Length; i++) {
                    if (icons.assets[i] != null) {
                        int iconAssetID = icons.assets[i].id;
                        string resourceMapping = "Property/" + iconAssetID;

                        if (!ModAssets.DoesMappingExist(resourceMapping))
                            ModAssets.AddResourceMapping(resourceMapping, iconAssetID);

                        switch (i) {
                            case 0:
                                staticResourceBuildingsData.id_ico_lvl1 = iconAssetID;
                                break;
                            case 1:
                                staticResourceBuildingsData.id_ico_lvl2 = iconAssetID;
                                break;
                            case 2:
                                staticResourceBuildingsData.id_ico_lvl3 = iconAssetID;
                                break;
                            case 3:
                                staticResourceBuildingsData.id_ico_lvl4 = iconAssetID;
                                break;
                        }
                    }
                }
            }

            AddStaticResourceBuilding(staticResourceBuildingsData);

            return nextResourceBuildingID++;
        }

        private static void AddStaticResourceBuilding(StaticResourceBuildingsData staticResourceBuildingsData) {
            StaticResourceBuildings staticResourceBuildings = Singletons.PROPERTY_CONTROLLER.GetStaticResourceBuildings();

            StaticResourceBuildingsData[] newData = new StaticResourceBuildingsData[staticResourceBuildings.staticResourceBuildingsDataArr.Length + 1];
            staticResourceBuildings.staticResourceBuildingsDataArr.CopyTo(newData, 0);
            newData[newData.Length - 1] = staticResourceBuildingsData;

            staticResourceBuildings.staticResourceBuildingsDataArr = newData;
        }

    }

}
