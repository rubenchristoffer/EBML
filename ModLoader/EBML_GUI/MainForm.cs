using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;

namespace EBML_GUI {

	public partial class MainWindow : Form {

		static readonly ILog log = LogManager.GetLogger (typeof (MainWindow));

		public static readonly string GAME_PATH = new DirectoryInfo (@".\").FullName;
		public static readonly string EBML_PATH = GAME_PATH + @"EBML\";
		public static readonly string LOG_PATH = EBML_PATH + @"GUI_Logs\";

		static bool processRunning = false;
		static bool injected = false;
		static string injectorProcessOutput;
		static string injectedAssemblyAddress;
		static bool hasAutoInjected = false;

		public MainWindow () {
			InitializeComponent ();
		}

		void MainWindow_Load (object sender, EventArgs e) {
			// Create required directories if they do not exist
			Directory.CreateDirectory (GAME_PATH);
			Directory.CreateDirectory (EBML_PATH);
			Directory.CreateDirectory (LOG_PATH);

			// Configure logging
			PatternLayout fileLayout = new PatternLayout ();
			fileLayout.ConversionPattern = "[%date][%name] %-5level %logger - %message%newline";
			fileLayout.ActivateOptions ();

			PatternLayout textBoxLayout = new PatternLayout ();
			textBoxLayout.ConversionPattern = "[%date] - %message%newline";
			textBoxLayout.ActivateOptions ();

			FileAppender fileAppender = new FileAppender ();
			fileAppender.AppendToFile = true;
			fileAppender.ImmediateFlush = true;
			fileAppender.File = Path.Combine (LOG_PATH, DateTime.Now.ToString ("yyyy-MM-dd") + ".txt");
			fileAppender.Layout = fileLayout;
			fileAppender.ActivateOptions ();

			TextboxAppender textboxAppender = new TextboxAppender ("mainappender", textBox1);
			textboxAppender.Layout = textBoxLayout;
			textboxAppender.ActivateOptions ();
			BasicConfigurator.Configure (fileAppender, textboxAppender);

			log.Info ("### New Session ###");

			PerformUpdate ();
			updateTimer.Start ();
		}

		void updateTimer_Tick (object sender, EventArgs e) {
			PerformUpdate ();
		}

		void PerformUpdate () {
			processRunning = Process.GetProcesses ()
			   .Select (p => p.ProcessName.ToLower ())
			   .Contains ("evilbankmanager");

			if (!processRunning && injected) {
				injected = false;
				hasAutoInjected = false;
				injectedAssemblyAddress = null;
				log.Warn ("Game process with injected DLL has stopped");
				statusLabel.Text = "Ready - ModLoader not injected";
			}

			label1.Text = processRunning ? "EvilBankManager process running" : "EvilBankManager process not running";
			label1.ForeColor = processRunning ? Color.Green : Color.Red;

			button1.Enabled = processRunning;
			button1.Text = injected ? "Eject ModLoader DLL" : "Manually inject DLL";

			button2.Text = processRunning ? "Game running" : "Start EBM";
			button2.Enabled = !processRunning;

			if (!hasAutoInjected && processRunning && !injected && autoInjectCheckbox.Checked && !injectorWorker.IsBusy) {
				hasAutoInjected = true;

				injectorWaitTimer.Start ();
			}
		}

		public void InjectModLoaderDLL () {
			log.Info ("Attempting to inject ModLoader DLL...");
			log.Info ("Starting injector process...");
			statusLabel.Text = "Injecting DLL...";
			statusProgressBar.Visible = true;

			// Run injection async because injection may
			// take some time if game is not properly loaded
			injectorWorker.RunWorkerAsync ();
		}

		public void EjectModLoaderDLL () {
			log.Info ("Attempting to eject ModLoader DLL...");

			Process ejector = new Process () {
				StartInfo = new ProcessStartInfo {
					FileName = "EBML/smi.exe",
					Arguments = "eject -p EvilBankManager -a " + injectedAssemblyAddress + " -n EBML -c ModLoaderEntry -m OnEjection",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true
				}
			};

			log.Info ("Starting ejector process...");
			string ejectorProcessOutput = "";

			try {
				ejector.Start ();

				// Should only be one line, so no StringBuilder necessary
				while (!ejector.StandardOutput.EndOfStream) {
					ejectorProcessOutput += ejector.StandardOutput.ReadLine ();
				}

				log.Debug ("Ejector Output: " + ejectorProcessOutput);

				injected = !ejectorProcessOutput.StartsWith ("Ejection successful");
			} catch (Exception e) {
				log.Error ("Something went wrong with ejector process", e);
			}

			if (!injected)
				statusLabel.Text = "Ready - ModLoader not injected";
		}

		public void StartGameProcess () {
			log.Info ("Starting game process using steam URL ('steam://rungameid/896160')...");
			Process.Start ("steam://rungameid/896160");
		}

		void button1_Click (object sender, EventArgs e) {
			if (!injected)
				InjectModLoaderDLL ();
			else
				EjectModLoaderDLL ();
		}

		void button2_Click (object sender, EventArgs e) {
			if (!processRunning)
				StartGameProcess ();
		}

		void injectorWorker_DoWork (object sender, DoWorkEventArgs args) {
			injectorProcessOutput = "";

			Process injector = new Process () {
				StartInfo = new ProcessStartInfo {
					FileName = "EBML/smi.exe",
					Arguments = "inject -p EvilBankManager -a EBML/EBML.dll -n EBML -c ModLoaderEntry -m OnInjection",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true
				}
			};

			try {
				injector.Start ();

				// Should only be one line, so no StringBuilder necessary
				while (!injector.StandardOutput.EndOfStream) {
					injectorProcessOutput += injector.StandardOutput.ReadLine ();
				}

				injected = injectorProcessOutput.StartsWith ("EBML.dll");
			} catch (Exception e) {
				log.Error ("Something went wrong with injector process", e);
			}
		}

		void injectorWorker_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e) {
			log.Debug ("Injector Output: " + injectorProcessOutput);

			if (injected) {
				injectedAssemblyAddress = injectorProcessOutput.Split (' ')[1];

				log.Info ("DLL has been successfully injected at address " + injectedAssemblyAddress);
				statusLabel.Text = "ModLoader DLL injected at memory address " + injectedAssemblyAddress;
			} else {
				log.Error ("An error occured while injecting DLL!");
				statusLabel.Text = "Could not inject ModLoader DLL. Try restarting game.";
			}

			statusProgressBar.Visible = false;
		}

		void injectorWaitTimer_Tick (object sender, EventArgs e) {
			injectorWaitTimer.Stop ();
			InjectModLoaderDLL ();
		}

	}

}
