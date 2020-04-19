using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML.GameAPI {

	public class ByteArrayFactory : Factory<ByteArrayFactory> {

		public byte[] FromFile (string relativeModsPath) {
			return ModFiles.ReadFileFromDisk (relativeModsPath);
		}

	}

}
