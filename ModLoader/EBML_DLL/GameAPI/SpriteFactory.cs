using System;
using UnityEngine;

namespace EBML.GameAPI {

	/// <summary>
	/// Lambda-based factory for creating Sprite objects in various ways.
	/// </summary>
	public class SpriteFactory : Factory<SpriteFactory> {

		/// <summary>
		/// Creates a new sprite using the provided texture.
		/// </summary>
		/// <param name="textureProvider">Type <code>usingTexture => usingTexture.[OPTION]</code></param>
		/// <returns>New sprite</returns>
		public static Sprite CreateSprite (Func<TextureFactory, Texture2D> textureProvider) {
			return Instance.FromTexture (textureProvider);
		}

		/// <summary>
		/// Intermediary function used for creating a higher-level object.
		/// </summary>
		/// <param name="textureProvider"></param>
		/// <returns>New sprite or null if it couldn't create image</returns>
		public Sprite FromTexture (Func<TextureFactory, Texture2D> textureProvider) {
			Texture2D texture = textureProvider (TextureFactory.Instance);

			return Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), Vector2.zero);
		}

	}

}
