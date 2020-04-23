using System;
using UnityEngine;

namespace EBML.Extensions {

	/// <summary>
	/// Extension methods for <see cref="Resource"/>.
	/// </summary>
	public static class ResourceExtensions {

		static readonly Type type = typeof (Resource);

		/// <summary>
		/// Sets the icon property.
		/// This is the image that will be displayed
		/// everywhere the resource is represented.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <param name="sprite">The icon image</param>
		public static void SetIcon (this Resource instance, Sprite sprite) {
			type.GetProperty ("icon").SetValue (instance, sprite);
		}

	}

}
