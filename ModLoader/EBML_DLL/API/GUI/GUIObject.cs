using UnityEngine;

namespace EBML.API.GUI {

	/// <summary>
	/// This is the base class for all GUI objects.
	/// </summary>
	public abstract class GUIObject {

		/// <summary>
		/// The name of the object used to retrieve it later.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// The bounds of the box.
		/// </summary>
		public Rect Bounds { get; private set; }

		/// <summary>
		/// Determines whether or not GUI Object should render or not
		/// </summary>
		public bool Enabled { get; set; }

		/// <summary>
		/// Initializes GUI Object with provided name.
		/// </summary>
		/// <param name="name">The name of the object used to retrieve it later.</param>
		/// <param name="bounds">The bounds of the GUI object</param>
		protected GUIObject (string name, Rect bounds) {
			Name = name;
			Bounds = bounds;
			Enabled = true;
		}

		/// <summary>
		/// This will render the actual GUI Object.
		/// This is guaranteed to be called by the OnGUI
		/// function.
		/// </summary>
		public abstract void Render ();

	}

}
