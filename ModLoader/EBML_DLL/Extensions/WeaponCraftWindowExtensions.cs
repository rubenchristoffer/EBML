using System;
using System.Collections.Generic;
using System.Reflection;

namespace EBML.Extensions {

	/// <summary>
	/// Extension methods for <see cref="WeaponCraftWindow"/>.
	/// </summary>
	public static class WeaponCraftWindowExtensions {

		static readonly Type type = typeof (WeaponCraftWindow);

		/// <summary>
		/// Gets the usedResources field.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <returns>Dictionary with resource ID as key and amount as value</returns>
		public static Dictionary<int, long> GetUsedResources (this WeaponCraftWindow instance) {
			return (Dictionary<int, long>) type
				.GetField ("usedResources", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue (instance);
		}

	}

}
