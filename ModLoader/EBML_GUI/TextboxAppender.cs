using System.Windows.Forms;
using log4net.Appender;
using log4net.Core;

namespace EBML_GUI {

	class TextboxAppender : AppenderSkeleton {

		public TextBox TextBox { get; private set; }

		public TextboxAppender (string name, TextBox textBox) {
			Name = name;
			TextBox = textBox;
		}

		protected override void Append (LoggingEvent loggingEvent) {
			TextBox.AppendText (RenderLoggingEvent (loggingEvent));
		}

	}

}
