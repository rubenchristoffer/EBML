using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;

namespace EBML {

	/// <summary>
	/// ModFiles is a utility class that you use for loading external resources
	/// into the game from files such as textures / sprites. 
	/// </summary>
	public static class ModFiles {

		/// <summary>
		/// Creates a new sprite using the provided texture.
		/// </summary>
		/// <param name="texture">The texture you want to create sprite from</param>
		/// <returns>New sprite</returns>
		public static Sprite CreateSprite (Texture2D texture) {
			ModLoader.LogToFile("Is texture null: " + (texture == null));

			return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
		}

		/// <summary>
		/// Creates a new texture object based on
		/// raw bytes. 
		/// </summary>
		/// <param name="bytes">Raw bytes</param>
		/// <returns>New texture or null if it couldn't create image</returns>
		public static Texture2D CreateTexture (byte[] bytes) {
			Texture2D texture = new Texture2D(0, 0);

			ModLoader.LogToFile("CreateTexture: Loading image data...");
			texture.LoadImage(bytes);

			return texture;
		}

		/// <summary>
		/// Reads a file from disk and stores the data in a byte array.
		/// </summary>
		/// <param name="relativeModsPath">The path preceding the mods directory</param>
		/// <returns>A raw byte array if file exists or null otherwise</returns>
		public static byte[] ReadFileFromDisk (string relativeModsPath) {
			string fullPath = GetFullPath(relativeModsPath);

			ModLoader.LogToFile(string.Format("Reading file from disk: {0}...", fullPath));

			if (!File.Exists(fullPath))
				return null;
			
			return File.ReadAllBytes(fullPath);
		}

		/// <summary>
		/// Gets the full path based on relative mods path.
		/// </summary>
		/// <param name="relativeModsPath">The path preceding the mods directory</param>
		/// <returns>String containing full path</returns>
		public static string GetFullPath (string relativeModsPath) {
			return Path.Combine(EBMLPaths.MODS_PATH, relativeModsPath);
		}

	}

}
