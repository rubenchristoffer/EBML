﻿using System;

namespace EBML.Logging {

	class Log : ILog {

		readonly string name;

		public Log (string name) {
			this.name = name;
		}

		enum Level {
			Info,
			Debug,
			Warning,
			Error
		}

		void DoLog (object message, Level level, Exception exception = null) {
			string formattedMessage = string.Format ("[{0}][{2}] {1}", DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss"), message, name);

			if (exception != null)
				formattedMessage += Environment.NewLine + exception.ToString ();

			using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter (System.IO.Path.Combine (Paths.LOG_PATH, DateTime.Now.ToString ("yyyy-MM-dd") + ".txt"), true)) {
				outputFile.WriteLine (formattedMessage);
			}

			if (level != Level.Debug && ModLoader.MainCanvas != null && ModLoader.MainCanvas.GetObject ("log") != null) {
				ModLoader.MainCanvas.GetObject<EBML.API.GUI.GUIBox> ("log").AppendLine (formattedMessage);
			}
		}

		public void Debug (object message) {
			DoLog (message, Level.Debug);
		}

		public void Debug (object message, Exception exception) {
			DoLog (message, Level.Debug, exception);
		}

		public void Error (object message) {
			DoLog (message, Level.Error);
		}

		public void Error (object message, Exception exception) {
			DoLog (message, Level.Error, exception);
		}

		public void Info (object message) {
			DoLog (message, Level.Info);
		}

		public void Info (object message, Exception exception) {
			DoLog (message, Level.Info, exception);
		}

		public void Warn (object message) {
			DoLog (message, Level.Warning);
		}

		public void Warn (object message, Exception exception) {
			DoLog (message, Level.Warning, exception);
		}

	}

}
