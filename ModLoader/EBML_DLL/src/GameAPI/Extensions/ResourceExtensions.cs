using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GameAPI.Extensions {

	/// <summary>
	/// Extension methods for Resource.
	/// </summary>
	public static class ResourceExtensions {

		private static Type type = typeof(Resource);

		/// <summary>
		/// Sets the icon property.
		/// This is the image that will be displayed
		/// everywhere the resource is represented.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <param name="sprite">The icon image</param>
		public static void SetIcon (this Resource instance, Sprite sprite) {
			type.GetProperty("icon").SetValue(instance, sprite);
		}

	}

}
