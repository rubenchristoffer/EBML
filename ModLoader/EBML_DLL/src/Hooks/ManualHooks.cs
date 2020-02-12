using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace EBML.Hooks {

	/// <summary>
	/// This is used to create 'manual hooks',
	/// in other words it's a way to create hooks using
	/// Harmony without using attributes and allows
	/// more freedom. It also keeps track of them
	/// in order to unpatch them when they should be
	/// unpatched.
	/// </summary>
	public static class ManualHooks {

		public static int currentID { get; private set; }

		private static List<Harmony> harmonyList = new List<Harmony>();

		internal delegate void HooksDelegate();
		internal static event HooksDelegate createInternalHooksEvent;

		internal static void InvokeInternalHooksEvent () {
			if (createInternalHooksEvent != null)
				createInternalHooksEvent();
		}

		public static Harmony GetHookReference (int id) {
			return harmonyList.FirstOrDefault(h => h.Id.Equals("ManualHook" + id));
		}

		public static void Register (Harmony harmony) {
			harmonyList.Add(harmony);
		}

		public static int CreateAndRegisterHook (Action<Harmony> createHookFunction) {
			Harmony harmony = new Harmony("ManualHook" + currentID);
			createHookFunction(harmony);

			Register(harmony);

			return currentID++;
		}

		internal static void UnpatchAll () {
			harmonyList.ForEach(h => h.UnpatchAll());
		}

	}

}
