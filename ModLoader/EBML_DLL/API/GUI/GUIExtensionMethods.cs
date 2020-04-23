using UnityEngine;

namespace EBML.API.GUI {

	/// <summary>
	/// Class containing extension methods related to GUI.
	/// </summary>
	public static class GUIExtensionMethods {

		/// <summary>
		/// Horizontal anchor
		/// </summary>
		public enum AnchorX {
			/// <summary>
			/// Left anchor
			/// </summary>
			LEFT,

			/// <summary>
			/// Center anchor
			/// </summary>
			CENTER,

			/// <summary>
			/// Right anchor
			/// </summary>
			RIGHT
		}

		/// <summary>
		/// Vertical anchor
		/// </summary>
		public enum AnchorY {
			/// <summary>
			/// Upper (top) anchor
			/// </summary>
			UPPER,

			/// <summary>
			/// Center anchor
			/// </summary>
			CENTER,

			/// <summary>
			/// Lower (bottom) anchor
			/// </summary>
			LOWER
		}

		/// <summary>
		/// Creates a new Rect where the position is based on reference Rect and horizontal and vertical anchor points.
		/// Useful if you for example want a button in the corner of a box.
		/// </summary>
		/// <param name="instance">The reference Rect</param>
		/// <param name="anchorX">Horizontal anchor</param>
		/// <param name="anchorY">Vertical anchor</param>
		/// <param name="size">Size of new rect</param>
		/// <param name="roundPositionToInt">Determines whether position should be cast to integer</param>
		/// <returns></returns>
		public static Rect FromAnchor (this Rect instance, AnchorX anchorX, AnchorY anchorY, Vector2 size, bool roundPositionToInt = true) {
			float x = 0f;
			float y = 0f;

			switch (anchorX) {
				case AnchorX.LEFT:
					x = instance.x;
					break;
				case AnchorX.CENTER:
					x = instance.x + (instance.width - size.x) / 2f;
					break;
				case AnchorX.RIGHT:
					x = instance.x + instance.width - size.x;
					break;
			}

			switch (anchorY) {
				case AnchorY.UPPER:
					y = instance.y;
					break;
				case AnchorY.CENTER:
					y = instance.y + (instance.height - size.y) / 2f;
					break;
				case AnchorY.LOWER:
					y = instance.y + instance.height - size.y;
					break;
			}

			return new Rect (roundPositionToInt ? (int) x : x, roundPositionToInt ? (int) y : y, size.x, size.y);
		}

	}

}
