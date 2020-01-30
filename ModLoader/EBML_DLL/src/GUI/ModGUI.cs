using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GUI {

    public class ModGUI {

        private List<GUIObject> guiObjects = new List<GUIObject>();

        public ModGUI () {
            MonoBehaviourCallbacks.onGUI += OnGUI;
        }

        public void Add (GUIObject obj) {
            guiObjects.Add(obj);
        }

        public void Remove (string name) {
            guiObjects.RemoveAll(obj => obj.name.Equals(name));
        }

        public GUIObject GetObject (string name) {
            return guiObjects.FirstOrDefault(obj => obj.name.Equals(name));
        }

        public T GetObject<T> (string name) where T : GUIObject {
            return (T) GetObject(name);
        }

        private void OnGUI() {
            foreach (GUIObject obj in guiObjects) {
                obj.Render();
            }
        }

    }

}
