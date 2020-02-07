using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GameAPI.Extensions {

	/// <summary>
	/// Extension methods for <see cref="Property"/>.
	/// </summary>
	public static class PropertyExtensions {

		private static Type type = typeof(Property);

		/// <summary>
		/// Sets the propertyIcons property.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <param name="icons">Array of sprite icons</param>
		public static void SetPropertyIcons (this Property instance, Sprite[] icons) {
			type.GetProperty("propertyIcons").SetValue(instance, icons);
		}

	}

}
