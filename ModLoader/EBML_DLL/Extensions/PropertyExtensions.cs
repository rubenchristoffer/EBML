using System;
using UnityEngine;

namespace EBML.Extensions {

	/// <summary>
	/// Extension methods for <see cref="Property"/>.
	/// </summary>
	public static class PropertyExtensions {

		static readonly Type type = typeof (Property);

		/// <summary>
		/// Sets the propertyIcons property.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <param name="icons">Array of sprite icons</param>
		public static void SetPropertyIcons (this Property instance, Sprite[] icons) {
			type.GetProperty ("propertyIcons").SetValue (instance, icons);
		}

	}

}
