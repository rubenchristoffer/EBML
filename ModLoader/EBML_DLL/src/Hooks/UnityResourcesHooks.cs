using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using System.Reflection;

namespace EBML.Hooks {

	public static class UnityResourcesHooks {

		/// <summary>
		/// The <code>Load(string path)</code> method.
		/// </summary>
		public static HookSystem<ReturnValue<UnityEngine.Sprite>, string> LoadSprite = new HookSystem<ReturnValue<UnityEngine.Sprite>, string>();

		internal static void CreateLoadHook() {
			ManualHooks.CreateAndRegisterHook(harmony => {
				MethodInfo methodInfo = typeof(Resources).GetMethods()
				.FirstOrDefault(m => m.Name.Equals("Load") && m.IsGenericMethod);
				MethodInfo spriteHookInfo = typeof(UnityResourcesHooks).GetMethod("LoadSpritePre", BindingFlags.NonPublic | BindingFlags.Static);

				harmony.Patch(methodInfo.MakeGenericMethod(typeof(UnityEngine.Sprite)), new HarmonyMethod(spriteHookInfo));
			});
		}

		static void LoadSpritePre (ref Sprite __result, ref string path) {
			ReturnValue<Sprite> returnValue = new ReturnValue<Sprite>();
			LoadSprite.InvokePreHooks(returnValue, path);

			if (returnValue.isSet) {
				// Seems to work here at least
				__result = returnValue.value;
			}
		}

	}

}
