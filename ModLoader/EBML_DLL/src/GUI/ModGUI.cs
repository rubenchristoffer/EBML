using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GUI {

    /// <summary>
    /// This is a class used to make it easier to create a GUI.
    /// It allows multiple "GUI Objects" to be added and they
    /// will all be rendered when OnGUI is called.
    /// </summary>
    public class ModGUI {

        private List<GUIObject> guiObjects = new List<GUIObject>();

        /// <summary>
        /// Creates a new ModGUI instance.
        /// </summary>
        public ModGUI () {
            MonoBehaviourCallbacks.onGUI += OnGUI;
        }

        /// <summary>
        /// Unsubscribes from the OnGUI callback.
        /// </summary>
        ~ModGUI () {
            MonoBehaviourCallbacks.onGUI -= OnGUI;
        }

        /// <summary>
        /// Adds a new GUIObject to the GUI.
        /// </summary>
        /// <param name="obj">The object you want rendered.</param>
        public void Add (GUIObject obj) {
            guiObjects.Add(obj);
        }

        /// <summary>
        /// Removes a GUI object based on its name.
        /// </summary>
        /// <param name="name">The name of the GUIObject.</param>
        public void Remove (string name) {
            guiObjects.RemoveAll(obj => obj.name.Equals(name));
        }

        /// <summary>
        /// Gets a GUIObject based on its name.
        /// </summary>
        /// <param name="name">The name of the GUIObject.</param>
        /// <returns>GUIObject if found or null.</returns>
        public GUIObject GetObject (string name) {
            return guiObjects.FirstOrDefault(obj => obj.name.Equals(name));
        }

        /// <summary>
        /// Same as <see cref="GetObject(string)"/>, but casts to type T.
        /// </summary>
        public T GetObject<T> (string name) where T : GUIObject {
            return (T) GetObject(name);
        }

        private void OnGUI() {
            guiObjects.ForEach(obj => obj.Render());
        }

    }

}
