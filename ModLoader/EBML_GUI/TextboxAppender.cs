using System;
using System.Windows.Forms;
using log4net.Appender;
using log4net.Core;

namespace EBML_GUI {

	class TextboxAppender : AppenderSkeleton {

		private delegate void SafeCallDelegate (LoggingEvent loggingEvent);

		public TextBox TextBox { get; private set; }

		public TextboxAppender (string name, TextBox textBox) {
			Name = name;
			TextBox = textBox;
		}

		protected override void Append (LoggingEvent loggingEvent) {
			TextBox.Invoke (new SafeCallDelegate(ThreadSafeAppend), loggingEvent);
		}

		private void ThreadSafeAppend (LoggingEvent loggingEvent) {
			TextBox.AppendText (RenderLoggingEvent (loggingEvent));
		}

	}

}
