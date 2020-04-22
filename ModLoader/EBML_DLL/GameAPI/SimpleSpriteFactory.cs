using System;
using UnityEngine;

namespace EBML.GameAPI {

	/// <summary>
	/// Simple factory for creating Sprite objects.
	/// </summary>
	public static class SimpleSpriteFactory {

		/// <summary>
		/// Create a new sprite from texture.
		/// </summary>
		/// <param name="texture">sprite texture</param>
		/// <returns>Sprite object</returns>
		/// 
		/// <seealso cref="Sprite.Create(Texture2D, Rect, Vector2, float)"/>
		/// <seealso cref="SimpleTextureFactory"/>
		public static Sprite CreateFromTexture (Texture2D texture) {
			return Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), Vector2.zero);
		}

		/// <summary>
		/// Create a new sprite from image bytes
		/// </summary>
		/// <param name="imageBytes">Raw image byte array</param>
		/// <returns>Sprite object</returns>
		/// <seealso cref="CreateFromTexture(Texture2D)"/>
		/// <seealso cref="SimpleTextureFactory.CreateFromImage(byte[])"/>
		public static Sprite CreateFromImage (byte[] imageBytes) {
			return CreateFromTexture (SimpleTextureFactory.CreateFromImage (imageBytes));
		}

		/// <summary>
		/// Create a new sprite from image located on disk.
		/// </summary>
		/// <param name="relativeFilePath">Path relative to Mods folder</param>
		/// <returns>Sprite object</returns>
		/// 
		/// <seealso cref="CreateFromTexture(Texture2D)"/>
		/// <seealso cref="SimpleTextureFactory.CreateFromImageFile(string)"/>
		public static Sprite CreateFromImageFile (string relativeFilePath) {
			return CreateFromTexture (SimpleTextureFactory.CreateFromImageFile (relativeFilePath));
		}

	}

}
