using System.Linq;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace EBML.Hooks {

	/// <summary>
	/// Method hooks for <see cref="Resources"/>.
	/// </summary>
	public static class UnityResourcesHooks {

		/// <summary>
		/// The <code>Load(string path)</code> (non-generic) method.
		/// </summary>
		public static HookSystem<ReturnValue<UnityEngine.Object>, string> Load = new HookSystem<ReturnValue<UnityEngine.Object>, string> ();

		/// <summary>
		/// The <code>Load&lt;Sprite&gt; (string path)</code> method.
		/// </summary>
		public static HookSystem<ReturnValue<Sprite>, string> LoadSprite = new HookSystem<ReturnValue<Sprite>, string> ();

#pragma warning disable IDE0051

		[HarmonyPatch]
		class Patch_Load {

			static MethodInfo TargetMethod () {
				return typeof (Resources).GetMethods ()
				.FirstOrDefault (m => m.Name.Equals ("Load") && !m.IsGenericMethod && m.CustomAttributes.Count () == 0);
			}

			[HarmonyPrefix]
			static bool LoadPre (ref UnityEngine.Object __result, string path) {
				ReturnValue<UnityEngine.Object> returnValue = new ReturnValue<UnityEngine.Object> (__result);
				Load.InvokePreHooks (returnValue, path);

				return Load.GetHarmonyReturnValue<UnityEngine.Object> (ref __result, returnValue);
			}

		}

		[HarmonyPatch]
		class Patch_LoadSprite {

			static MethodInfo TargetMethod () {
				return typeof (Resources).GetMethods ()
				.FirstOrDefault (m => m.Name.Equals ("Load") && m.IsGenericMethod && m.CustomAttributes.Count () == 0)
				.MakeGenericMethod (typeof (Sprite));
			}

			[HarmonyPrefix]
			static bool LoadPre (ref Sprite __result, ref string path) {
				ReturnValue<Sprite> returnValue = new ReturnValue<Sprite> (__result);
				LoadSprite.InvokePreHooks (returnValue, path);

				return LoadSprite.GetHarmonyReturnValue<Sprite> (ref __result, returnValue);
			}

		}

#pragma warning restore IDE0051

	}

}