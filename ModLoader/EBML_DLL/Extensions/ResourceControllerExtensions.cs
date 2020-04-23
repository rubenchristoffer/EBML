using System;
using System.Collections.Generic;
using System.Reflection;
using Static;

namespace EBML.Extensions {

	/// <summary>
	/// Extension methods for <see cref="ResourceController"/>.
	/// </summary>
	public static class ResourceControllerExtensions {

		private static readonly Type type = typeof (ResourceController);

		/// <summary>
		/// Gets the staticResource field.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <returns>StaticResource object</returns>
		public static StaticResource GetStaticResource (this ResourceController instance) {
			return (StaticResource) type
				.GetField ("staticResource", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue (instance);
		}

		/// <summary>
		/// Gets the staticResourceProduction field.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <returns>StaticResourceProduction object</returns>
		public static StaticResourceProduction GetStaticResourceProduction (this ResourceController instance) {
			return (StaticResourceProduction) type
				.GetField ("staticResourceProduction", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue (instance);
		}

		/// <summary>
		/// Gets the staticPropertyRecoupment field.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <returns>StaticPropertyRecoupment object</returns>
		public static StaticPropertyRecoupment GetStaticPropertyRecoupment (this ResourceController instance) {
			return (StaticPropertyRecoupment) type
				.GetField ("staticPropertyRecoupment", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue (instance);
		}

		/// <summary>
		/// Gets the resources field.
		/// This is all the resources that have been created.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <returns>Resource array</returns>
		public static Resource[] GetResources (this ResourceController instance) {
			return (Resource[]) type
				.GetField ("resources", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue (instance);
		}

		/// <summary>
		/// Gets the creatingResources field.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <returns>List of CreatingResourceInfo objects</returns>
		public static List<CreatingResourceInfo> GetCreatingResources (this ResourceController instance) {
			return (List<CreatingResourceInfo>) type
				.GetField ("creatingResources", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue (instance);
		}

	}

}
