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

        private static Dictionary<int, Tuple<Sprite, Sprite, Sprite, Sprite>> modPropertiesIcons = new Dictionary<int, Tuple<Sprite, Sprite, Sprite, Sprite>>();

        static ModProperties () {
            nextResourceBuildingID = 42;

            Hooks.PropertyHooks.GetIcon.skipOriginalMethod = true;

            // TODO: Create sprite init hook
            Hooks.PropertyHooks.GetIcon.AddPreHook((instance, returnValue) => {
                ModLoader.Log("GetIcon hook here");

                if (modPropertiesIcons.ContainsKey (instance.id)) {
                    returnValue.SetValue(modPropertiesIcons[instance.id].Item1);
                }

                ModLoader.Log("Is return null: " + returnValue.isSet);
            });
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
        /// <param name="icon1Sprite">Optional icon for type 1</param>
        /// <param name="icon2Sprite">Optional icon for type 2</param>
        /// <param name="icon3Sprite">Optional icon for type 3</param>
        /// <param name="icon4Sprite">Optional icon for type 4</param>
        /// <returns>ID of the new property type</returns>
        public static int RegisterNewPropertyType(StaticResourceBuildingsData staticResourceBuildingsData, Sprite icon1Sprite = null, Sprite icon2Sprite = null, Sprite icon3Sprite = null, Sprite icon4Sprite = null) {
            staticResourceBuildingsData.id = nextResourceBuildingID;
            AddStaticResourceBuilding(staticResourceBuildingsData);
            modPropertiesIcons.Add(nextResourceBuildingID, new Tuple<Sprite, Sprite, Sprite, Sprite>(icon1Sprite, icon2Sprite, icon3Sprite, icon4Sprite));

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
