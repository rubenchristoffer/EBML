using System.Collections.Generic;
using System.Linq;

namespace EBML.API.GUI {

	/// <summary>
	/// This is a class used to make it easier to create a GUI.
	/// It allows multiple "GUI Objects" to be added and they
	/// will all be rendered when OnGUI is called.
	/// </summary>
	public class GUICanvas {

		readonly List<GUIObject> guiObjects = new List<GUIObject> ();

		/// <summary>
		/// Creates a new ModGUI instance.
		/// </summary>
		public GUICanvas () {
			MonoBehaviourCallbacks.OnGUIEvent += OnGUI;
		}

		/// <summary>
		/// Unsubscribes from the OnGUI callback.
		/// </summary>
		~GUICanvas () {
			MonoBehaviourCallbacks.OnGUIEvent -= OnGUI;
		}

		/// <summary>
		/// Adds new GUI objects.
		/// </summary>
		/// <param name="objects">All the GUI objects you want rendered</param>
		public void Add (params GUIObject[] objects) {
			foreach (GUIObject obj in objects) {
				guiObjects.Add (obj);
			}
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

		void OnGUI () {
			foreach (GUIObject obj in guiObjects) {
				if (obj.Enabled) {
					obj.Render ();
				}
			}
		}

	}

}
