using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EBML.GameAPI.Extensions {

	public static class WeaponCraftWindowExtensions {

		private static Type type = typeof(WeaponCraftWindow);

		public static Dictionary<int, long> GetUsedResources (this WeaponCraftWindow instance) {
			return (Dictionary<int, long>) type
				.GetField("usedResources", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(instance);
		}

	}

}
