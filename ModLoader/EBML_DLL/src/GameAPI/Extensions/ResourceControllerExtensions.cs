using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Static;

namespace EBML.GameAPI.Extensions {

	public static class ResourceControllerExtensions {

        private static Type type = typeof(ResourceController);
       
        public static StaticResource GetStaticResource (this ResourceController instance) {
            return (StaticResource) type
                .GetField("staticResource", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);
        }

        public static StaticResourceProduction GetStaticResourceProduction (this ResourceController instance) {
            return (StaticResourceProduction) type
                .GetField("staticResourceProduction", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);
        }

        public static StaticPropertyRecoupment GetStaticPropertyRecoupment (this ResourceController instance) {
            return (StaticPropertyRecoupment) type
                .GetField("staticPropertyRecoupment", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);
        }

        public static Resource[] GetResources (this ResourceController instance) {
            return (Resource[]) type
                .GetField("resources", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);
        }

        public static List<CreatingResourceInfo> GetCreatingResources (this ResourceController instance) {
            return (List<CreatingResourceInfo>) type
                .GetField("creatingResources", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(instance);
        }

    }

}
