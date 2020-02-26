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
		public static HookSystem<ReturnValue<UnityEngine.Object>, string> Load = new HookSystem<ReturnValue<UnityEngine.Object>, string>();

		public static HookSystem<ReturnValue<Sprite>, string> LoadSprite = new HookSystem<ReturnValue<Sprite>, string>();

		internal static void CreateLoadHook() {
			/*ManualHooks.CreateAndRegisterHook(harmony => {
				MethodInfo methodInfo = typeof(Resources).GetMethods()
				.FirstOrDefault(m => m.Name.Equals("Load") && !m.IsGenericMethod && m.CustomAttributes.Count() == 0);
				MethodInfo hookInfo = typeof(UnityResourcesHooks).GetMethod("LoadPre", BindingFlags.NonPublic | BindingFlags.Static);
				
				harmony.Patch(methodInfo, new HarmonyMethod(hookInfo));
			});*/
		}

		[HarmonyPatch]
		private class Patch_Load {

			static MethodInfo TargetMethod () {
				return typeof(Resources).GetMethods()
				.FirstOrDefault(m => m.Name.Equals("Load") && !m.IsGenericMethod && m.CustomAttributes.Count() == 0);
			}

			[HarmonyPrefix]
			static bool LoadPre(ref UnityEngine.Object __result, ref string path) {
				ReturnValue<UnityEngine.Object> returnValue = new ReturnValue<UnityEngine.Object>();
				Load.InvokePreHooks(returnValue, path);

				return Load.GetHarmonyReturnValue<UnityEngine.Object>(ref __result, returnValue);
			}

		}

		[HarmonyPatch]
		private class Patch_LoadSprite {

			static MethodInfo TargetMethod() {
				return typeof(Resources).GetMethods()
				.FirstOrDefault(m => m.Name.Equals("Load") && m.IsGenericMethod && m.CustomAttributes.Count() == 0)
				.MakeGenericMethod (typeof(Sprite));
			}

			[HarmonyPrefix]
			static bool LoadPre(ref Sprite __result, ref string path) {
				ReturnValue<Sprite> returnValue = new ReturnValue<Sprite>();
				LoadSprite.InvokePreHooks(returnValue, path);

				return LoadSprite.GetHarmonyReturnValue<Sprite>(ref __result, returnValue);
			}

		}

	}

}
