using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GUI {

	/// <summary>
	/// Class containing extension methods related to GUI.
	/// </summary>
	public static class GUIExtensionMethods {

		public enum AnchorX {
			LEFT,
			CENTER,
			RIGHT
		}

		public enum AnchorY {
			UPPER,
			CENTER,
			LOWER
		}

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

			return new Rect(roundPositionToInt ? (int) x : x, roundPositionToInt ? (int) y : y, size.x, size.y);
		}

	}

}
