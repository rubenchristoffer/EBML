using System;
using UnityEngine;

namespace EBML.GameAPI {

	/// <summary>
	/// Lambda-based factory for creating Texture2D objects in various ways.
	/// </summary>
	public class TextureFactory : Factory<TextureFactory> {

		/// <summary>
		/// Creates a new texture object based on byte array.
		/// </summary>
		/// <param name="byteArrayProvider">Type <code>usingBytes => usingBytes.[OPTION]</code></param>
		/// <returns>New texture or null if it couldn't create image</returns>
		public static Texture2D CreateTexture (Func<ByteArrayFactory, byte[]> byteArrayProvider) {
			return Instance.FromBytes (byteArrayProvider);
		}

		/// <summary>
		/// Intermediary function used for creating a higher-level object.
		/// </summary>
		/// <param name="byteArrayProvider">Type <code>usingBytes => usingBytes.[OPTION]</code></param>
		/// <returns>New texture or null if it couldn't create image</returns>
		public Texture2D FromBytes (Func<ByteArrayFactory, byte[]> byteArrayProvider) {
			Texture2D texture = new Texture2D (0, 0);
			texture.LoadImage (byteArrayProvider (ByteArrayFactory.Instance));

			return texture;
		}

	}

}
