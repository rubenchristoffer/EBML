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
		public static HookSystem<ReturnValue<UnityEngine.Object>, string, Type> Load = new HookSystem<ReturnValue<UnityEngine.Object>, string, Type>();

		static UnityResourcesHooks () {
			ManualHooks.createInternalHooksEvent += CreateLoadHook;
		}

		public static void CreateLoadHook() {
			ModLoader.LogToFile("### Manual hook here!!!");

			ManualHooks.CreateAndRegisterHook(harmony => {
				MethodInfo methodInfo = typeof(Resources).GetMethods()
				.FirstOrDefault(m => m.Name.Equals("Load") && m.IsGenericMethod);
				MethodInfo spriteHookInfo = typeof(UnityResourcesHooks).GetMethod("LoadSprite", BindingFlags.NonPublic | BindingFlags.Static);

				harmony.Patch(methodInfo.MakeGenericMethod(typeof(UnityEngine.Sprite)), new HarmonyMethod(spriteHookInfo));
			});
		}

		private static void LoadSprite (ref Sprite __result, ref string path) {
			ModLoader.LogToFile(String.Format("Loaded sprite: {0}", path));
		}

	}

}
