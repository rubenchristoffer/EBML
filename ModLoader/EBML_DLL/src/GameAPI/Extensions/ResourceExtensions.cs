using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GameAPI.Extensions {

	public static class ResourceExtensions {

		private static Type type = typeof(Resource);

		public static void SetIcon (this Resource instance, Sprite sprite) {
			type.GetProperty("icon").SetValue(instance, sprite);
		}

	}

}
