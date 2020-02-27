using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GUI {

    /// <summary>
    /// This is the base class for all GUI objects.
    /// </summary>
    public abstract class GUIObject {

        /// <summary>
        /// The name of the object used to retrieve it later.
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// The bounds of the box.
        /// </summary>
        public Rect bounds { get; private set; }

        /// <summary>
        /// Determines whether or not GUI Object should render or not
        /// </summary>
        public bool enabled = true;

        /// <summary>
        /// Initializes GUI Object with provided name.
        /// </summary>
        /// <param name="name">The name of the object used to retrieve it later.</param>
        /// <param name="bounds">The bounds of the GUI object</param>
        protected GUIObject (string name, Rect bounds) {
            this.name = name;
            this.bounds = bounds;
        }

        /// <summary>
        /// This will render the actual GUI Object.
        /// This is guaranteed to be called by the OnGUI
        /// function.
        /// </summary>
        public abstract void Render();

    }

}
