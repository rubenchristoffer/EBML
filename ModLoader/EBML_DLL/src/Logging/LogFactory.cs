using System;
using System.Collections.Generic;

namespace EBML.Logging {

	/// <summary>
	/// Factory class for EBML Logging
	/// </summary>
	public static class LogFactory {

		private static Dictionary<Type, ILog> loggerDB = new Dictionary<Type, ILog> ();

		/// <summary>
		/// Gets an existing logger if it exists or creates a new one.
		/// </summary>
		/// <param name="type">The class type where you want to use this logger</param>
		/// <returns>Logger interface</returns>
		public static ILog GetLogger (Type type) {
			if (!loggerDB.ContainsKey (type))
				loggerDB.Add (type, new Log (type));

			return loggerDB[type];
		}

	}

}
