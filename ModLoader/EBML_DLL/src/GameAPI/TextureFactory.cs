using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EBML.GameAPI {

	public class TextureFactory : Factory<TextureFactory> {

		/// <summary>
		/// Creates a new texture object based on
		/// raw bytes. 
		/// </summary>
		/// <param name="bytes">Raw bytes</param>
		/// <returns>New texture or null if it couldn't create image</returns>
		public Texture2D GetTexture (Func<ByteArrayFactory, byte[]> byteArrayProvider) {
			Texture2D texture = new Texture2D (0, 0);
			texture.LoadImage (byteArrayProvider(ByteArrayFactory.Instance));

			return texture;
		}

	}

}
