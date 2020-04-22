using System;
using UnityEngine;

namespace EBML.GameAPI {

	/// <summary>
	/// Simple texture factory useful for creating Texture2D objects.
	/// </summary>
	public static class SimpleTextureFactory {

		/// <summary>
		/// Create a new texture from image bytes.
		/// </summary>
		/// <param name="imageBytes">Raw image byte array</param>
		/// <returns>Texture2D object</returns>
		public static Texture2D CreateFromImage (byte[] imageBytes) {
			Texture2D texture = new Texture2D (0, 0);
			texture.LoadImage (imageBytes);
			
			return texture;
		}

		/// <summary>
		/// Create a new texture from image located on disk.
		/// </summary>
		/// <param name="relativeFilePath">Path relative to Mods folder</param>
		/// <returns>Texture2D object</returns>
		/// 
		/// <seealso cref="CreateFromImage(byte[])"/>
		public static Texture2D CreateFromImageFile (string relativeFilePath) {
			return CreateFromImage (ModFiles.ReadFileFromDisk (relativeFilePath));
		}

	}

}
