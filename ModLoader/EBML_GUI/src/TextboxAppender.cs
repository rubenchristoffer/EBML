using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Appender;
using log4net.Core;
using System.Windows.Forms;
using System.IO;

namespace EBML_GUI {

	class TextboxAppender : AppenderSkeleton {

		public TextBox TextBox { get; private set; }

		public TextboxAppender (string name, TextBox textBox) {
			Name = name;
			TextBox = textBox;
		}

		protected override void Append(LoggingEvent loggingEvent) {
			TextBox.AppendText(RenderLoggingEvent(loggingEvent));
		}

	}

}
