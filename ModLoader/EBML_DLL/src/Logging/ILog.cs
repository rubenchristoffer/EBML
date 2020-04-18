using System;

namespace EBML.Logging {

	public interface ILog {

		void Info(object message, Exception exception);
		void Info(object message);

		void Debug(object message);
		void Debug(object message, Exception exception);

		void Warn(object message);
		void Warn(object message, Exception exception);

		void Error(object message);
		void Error(object message, Exception exception);

	}

}
