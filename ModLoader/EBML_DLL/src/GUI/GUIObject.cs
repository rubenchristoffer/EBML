using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Initializes GUI Object with provided name.
        /// </summary>
        /// <param name="name">The name of the object used to retrieve it later.</param>
        protected GUIObject (string name) {
            this.name = name;
        }

        /// <summary>
        /// This will render the actual GUI Object.
        /// This is guaranteed to be called by the OnGUI
        /// function.
        /// </summary>
        public abstract void Render();

    }

}
