using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML.Logging {

	public static class LogFactory {

		public static ILog GetLogger (Type type) {
			return new Log(type);
		}

	}

}
