using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Static;

namespace EBML.ModManagers {

    public static class ModResources {

        public delegate void ResourceDelegate(int id, string name, int resource_type, int base_price, int turn_discovery);
        public static event ResourceDelegate onRegisteredNewResource;

        /// <summary>
        /// Registers a new resource, which allows you to create your own kind of resource.
        /// </summary>
        /// <param name="resource"></param>
        public static void RegisterNewResource (int id, string name, int resource_type, int base_price, int turn_discovery) {
            /*StaticResourceData resource;
            resource.id = id;
            resource.name = name;
            resource.resourse_type = resource_type;
            resource.base_price = base_price;
            resource.turn_discovery = turn_discovery;

            try {
                FieldInfo staticResourceField = typeof(ResourceController).GetField("staticResource", BindingFlags.NonPublic | BindingFlags.Instance);
                StaticResource staticResource = (StaticResource)staticResourceField.GetValue(Singletons.RESOURCE_CONTROLLER);

                StaticResourceData[] newData = new StaticResourceData[staticResource.staticResourceDataArr.Length + 1];
                staticResource.staticResourceDataArr.CopyTo(newData, 0);
                newData[newData.Length - 1] = resource;

                staticResource.staticResourceDataArr = newData;

                if (onRegisteredNewResource != null)
                    onRegisteredNewResource(id, name, resource_type, base_price, turn_discovery);
            } catch (Exception e) {
                ModLoader.Log(e.ToString());
            }*/
        }

        public static void ReInitResources () {
            Singletons.RESOURCE_CONTROLLER.Init();
        }

    }

}
