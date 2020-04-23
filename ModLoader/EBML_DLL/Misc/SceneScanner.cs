using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EBML.Misc {

	/// <summary>
	/// Utility class containing various functions
	/// that collects information about the current scene.
	/// </summary>
	public static class SceneScanner {

		/// <summary>
		/// Creates a scene tree of all the gameobjects that exists.
		/// </summary>
		/// <returns>String in form of a tree with tabs indicating level</returns>
		public static string GetAllGameObjectsInScene () {
			StringBuilder builder = new StringBuilder ();

			foreach (GameObject root in SceneManager.GetActiveScene ().GetRootGameObjects ()) {
				AppendGameobjectsRecursively (root, builder, 0);
			}

			return builder.ToString ();
		}

		private static void AppendGameobjectsRecursively (GameObject obj, StringBuilder builder, int level) {
			for (int i = 0; i < level; i++) {
				builder.Append ("\t");
			}

			builder.AppendLine (obj.name);

			foreach (Transform child in obj.transform) {
				AppendGameobjectsRecursively (child.gameObject, builder, level + 1);
			}
		}

		/// <summary>
		/// Creates a list of all the names of MonoBehaviours attached
		/// to gameobjects in the scene.
		/// </summary>
		/// <returns>String containing lines of monobehaviour names</returns>
		public static string GetAllMonobehavioursInScene () {
			StringBuilder builder = new StringBuilder ();

			foreach (MonoBehaviour behaviour in MonoBehaviour.FindObjectsOfType<MonoBehaviour> ()) {
				builder.AppendLine (behaviour.ToString ());
			}

			return builder.ToString ();
		}

	}

}
