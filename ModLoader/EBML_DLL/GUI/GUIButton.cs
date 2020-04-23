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
		public Action OnClickAction { get; private set; }

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
		/// <param name="onClickAction">The action that should be performed after button is pressed</param>
		public GUIButton (string name, Rect bounds, string text, Action onClickAction) : base (name, bounds) {
			Text = text;
			OnClickAction = onClickAction;
		}

		/// <summary>
		/// See <see cref="GUIObject.Render"/>.
		/// </summary>
		public override void Render () {
			if (UnityEngine.GUI.Button (Bounds, Text)) {
				if (OnClickAction != null) {
					OnClickAction ();
				}
			}
		}

	}

}
