using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace EBML.Hooks {

	public static class UnityResourcesHooks {

		/// <summary>
		/// The <code>Load(string path)</code> method.
		/// </summary>
		public static HookSystem<ReturnValue<UnityEngine.Object>, string, Type> Load = new HookSystem<ReturnValue<UnityEngine.Object>, string, Type>();

		[HarmonyPatch(typeof(Resources))]
		private class Patch {

			[HarmonyPatch("Load")]
			[HarmonyPrefix]
			static bool LoadPre<T> (ref UnityEngine.Object __result, ref string path) where T : UnityEngine.Object {
				ReturnValue<UnityEngine.Object> returnValue = new ReturnValue<UnityEngine.Object>();
				Load.InvokePreHooks(returnValue, path, null);

				if (returnValue.isSet)
					__result = returnValue.value;

				// TODO: Check if this actually is necessary
				return Load.ResetOriginalMethodSkip();
			}


		}

	}

}
