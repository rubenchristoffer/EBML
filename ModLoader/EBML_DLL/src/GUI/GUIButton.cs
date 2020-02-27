using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GUI {

	/// <summary>
	/// Creates a new GUI Button that performs
	/// an action when clicked.
	/// </summary>
	public class GUIButton : GUIObject {

		/// <summary>
		/// The action that should be performed
		/// when clicking the button.
		/// </summary>
		public Action action { get; private set; }

		/// <summary>
		/// The text inside the button.
		/// </summary>
		public string text { get; private set; }

		/// <summary>
		/// Creates a new GUIButton.
		/// </summary>
		/// <param name="name">The name of the object used to retrieve it later.</param>
		/// <param name="bounds">The bounds of the button</param>
		/// <param name="text">The text inside the button</param>
		/// <param name="action">The action that should be performed when clicking button</param>
		public GUIButton (string name, Rect bounds, string text, Action action) : base (name, bounds) {
			this.text = text;
			this.action = action;
		}

		/// <summary>
		/// See <see cref="GUIObject.Render"/>.
		/// </summary>
		public override void Render() {
			if (UnityEngine.GUI.Button (bounds, text)) {
				if (action != null) {
					action();
				}
			}
		}

	}

}
