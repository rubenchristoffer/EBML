using System;
using System.Collections.Generic;

namespace EBML.Logging {

	/// <summary>
	/// Factory class for EBML Logging.
	/// </summary>
	public static class LogFactory {

		static readonly Dictionary<string, ILog> loggerDB = new Dictionary<string, ILog> ();

		/// <summary>
		/// Gets an existing logger if it exists or creates a new one.
		/// </summary>
		/// <param name="type">The class type where you want to use this logger</param>
		/// <returns>Logger interface</returns>
		public static ILog GetLogger (Type type) {
			return GetLogger (type.Name);
		}

		/// <summary>
		/// Gets an existing logger if it exists or creates a new one.
		/// </summary>
		/// <param name="name">Preferably the name of the class type where you want to use this logger</param>
		/// <returns>Logger interface</returns>
		public static ILog GetLogger (string name) {
			if (!loggerDB.ContainsKey (name))
				loggerDB.Add (name, new Log (name));

			return loggerDB[name];
		}

	}

}
