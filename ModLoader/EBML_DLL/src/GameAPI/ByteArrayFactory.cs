namespace EBML.GameAPI {

	/// <summary>
	/// Low-level lambda-based factory for creating byte arrays.
	/// </summary>
	public class ByteArrayFactory : Factory<ByteArrayFactory> {

		/// <summary>
		/// Create byte array by reading from file.
		/// </summary>
		/// <param name="relativeModsPath">The path you want relative to the Mods folder</param>
		/// <returns>Byte array read from disk</returns>
		public byte[] FromFile (string relativeModsPath) {
			return ModFiles.ReadFileFromDisk (relativeModsPath);
		}

	}

}
