using System.Collections.Generic;
using System.Linq;

namespace EBML.GUI {

	/// <summary>
	/// This is a class used to make it easier to create a GUI.
	/// It allows multiple "GUI Objects" to be added and they
	/// will all be rendered when OnGUI is called.
	/// </summary>
	public class ModGUI {

		private List<GUIObject> guiObjects = new List<GUIObject> ();

		/// <summary>
		/// Creates a new ModGUI instance.
		/// </summary>
		public ModGUI () {
			MonoBehaviourCallbacks.OnGUIEvent += OnGUI;
		}

		/// <summary>
		/// Unsubscribes from the OnGUI callback.
		/// </summary>
		~ModGUI () {
			MonoBehaviourCallbacks.OnGUIEvent -= OnGUI;
		}

		/// <summary>
		/// Adds a new GUIObject to the GUI.
		/// </summary>
		/// <param name="obj">The object you want rendered.</param>
		/// <param name="additionalObjects">Additional (optional) objects</param>
		public void Add (GUIObject obj, params GUIObject[] additionalObjects) {
			guiObjects.Add (obj);
			guiObjects.AddRange (additionalObjects);
		}

		/// <summary>
		/// Removes a GUI object based on its name.
		/// </summary>
		/// <param name="name">The name of the GUIObject.</param>
		public void Remove (string name) {
			guiObjects.RemoveAll (obj => obj.Name.Equals (name));
		}

		/// <summary>
		/// Gets a GUIObject based on its name.
		/// </summary>
		/// <param name="name">The name of the GUIObject.</param>
		/// <returns>GUIObject if found or null.</returns>
		public GUIObject GetObject (string name) {
			return guiObjects.FirstOrDefault (obj => obj.Name.Equals (name));
		}

		/// <summary>
		/// Same as <see cref="GetObject(string)"/>, but casts to type T.
		/// </summary>
		public T GetObject<T> (string name) where T : GUIObject {
			return (T) GetObject (name);
		}

		private void OnGUI () {
			foreach (GUIObject obj in guiObjects) {
				if (obj.enabled) {
					obj.Render ();
				}
			}
		}

	}

}
