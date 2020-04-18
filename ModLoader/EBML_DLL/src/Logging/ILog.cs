using System;

namespace EBML.Logging {

	/// <summary>
	/// Logger interface used for logging.
	/// </summary>
	public interface ILog {

		/// <summary>
		/// Logs using Info level and includes exception.
		/// </summary>
		/// <param name="message">Message to log</param>
		/// <param name="exception">Exception to include</param>
		void Info (object message, Exception exception);

		/// <summary>
		/// Logs using Info level.
		/// </summary>
		/// <param name="message">Message to log</param>
		void Info (object message);

		/// <summary>
		/// Logs using Debug level.
		/// </summary>
		/// <param name="message">Message to log</param>
		void Debug (object message);

		/// <summary>
		/// Logs using Debug level and includes exception.
		/// </summary>
		/// <param name="message">Message to log</param>
		/// <param name="exception">Exception to include</param>
		void Debug (object message, Exception exception);

		/// <summary>
		/// Logs using Warning level.
		/// </summary>
		/// <param name="message">Message to log</param>
		void Warn (object message);

		/// <summary>
		/// Logs using Warning level and includes exception.
		/// </summary>
		/// <param name="message">Message to log</param>
		/// <param name="exception">Exception to include</param>
		void Warn (object message, Exception exception);

		/// <summary>
		/// Logs using Error level.
		/// </summary>
		/// <param name="message">Message to log</param>
		void Error (object message);

		/// <summary>
		/// Logs using Error level and includes exception.
		/// </summary>
		/// <param name="message">Message to log</param>
		/// <param name="exception">Exception to include</param>
		void Error (object message, Exception exception);

	}

}
