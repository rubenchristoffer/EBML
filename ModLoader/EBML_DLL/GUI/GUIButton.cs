using System;
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
		public Action Action { get; private set; }

		/// <summary>
		/// The text inside the button.
		/// </summary>
		public string Text { get; private set; }

		/// <summary>
		/// Creates a new GUIButton.
		/// </summary>
		/// <param name="name">The name of the object used to retrieve it later.</param>
		/// <param name="bounds">The bounds of the button</param>
		/// <param name="text">The text inside the button</param>
		/// <param name="action">The action that should be performed when clicking button</param>
		public GUIButton (string name, Rect bounds, string text, Action action) : base (name, bounds) {
			this.Text = text;
			this.Action = action;
		}

		/// <summary>
		/// See <see cref="GUIObject.Render"/>.
		/// </summary>
		public override void Render () {
			if (UnityEngine.GUI.Button (Bounds, Text)) {
				if (Action != null) {
					Action ();
				}
			}
		}

	}

}
