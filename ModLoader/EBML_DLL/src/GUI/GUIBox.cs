using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GUI {

    /// <summary>
    /// GUI Object that renders a standard Unity Box.
    /// </summary>
    public class GUIBox : GUIObject {

        /// <summary>
        /// The text inside the box.
        /// </summary>
        public string text { get; private set; }

        /// <summary>
        /// Creates a new GUIBox instance.
        /// </summary>
        /// <param name="name">The name of the object used to retrieve it later.</param>
        /// <param name="bounds">The bounds of the box</param>
        /// <param name="text">The text inside the box.</param>
        public GUIBox (string name, Rect bounds, String text) : base(name, bounds) {
            this.text = text;
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="text">The text inside the box.</param>
        public void SetText (string text) {
            this.text = text;
        }

        /// <summary>
        /// Appends text to the text it already has.
        /// </summary>
        /// <param name="appendText">The text to append inside the box.</param>
        public void AppendText (string appendText) {
            SetText(text + appendText);
        }

        /// <summary>
        /// Appends text to the text it already has and adds
        /// a line break.
        /// </summary>
        /// <param name="appendText">The text to append inside the box.</param>
        public void AppendLine (string appendText) {
            AppendText(appendText + "\n");
        }

        /// <summary>
		/// See <see cref="GUIObject.Render"/>.
		/// </summary>
        public override void Render() {
            UnityEngine.GUI.Box(bounds, text);   
        }

    }

}
