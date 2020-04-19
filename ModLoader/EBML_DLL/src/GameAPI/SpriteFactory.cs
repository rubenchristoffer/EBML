using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GameAPI {

	public class SpriteFactory : Factory<SpriteFactory> {

		/// <summary>
		/// Creates a new sprite using the provided texture.
		/// </summary>
		/// <param name="texture">The texture you want to create sprite from</param>
		/// <returns>New sprite</returns>
		public Sprite GetSprite (Func<TextureFactory, Texture2D> textureProvider) {
			Texture2D texture = textureProvider (TextureFactory.Instance);

			return Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), Vector2.zero);
		}

	}

}
