using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EBML.GameAPI.Extensions {

	/// <summary>
	/// Extension methods for <see cref="WeaponCraftWindow"/>.
	/// </summary>
	public static class WeaponCraftWindowExtensions {

		private static Type type = typeof(WeaponCraftWindow);

		/// <summary>
		/// Gets the usedResources field.
		/// </summary>
		/// <param name="instance">Instance</param>
		/// <returns>Dictionary with resource ID as key and amount as value</returns>
		public static Dictionary<int, long> GetUsedResources (this WeaponCraftWindow instance) {
			return (Dictionary<int, long>) type
				.GetField("usedResources", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(instance);
		}

	}

}
