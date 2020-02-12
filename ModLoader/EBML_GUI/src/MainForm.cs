using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace EBML_GUI {

    public partial class MainWindow : Form {

        public static string GAME_PATH = new DirectoryInfo(@".\").FullName;
        public static string EBML_PATH = GAME_PATH + @"EBML\";
        public static string LOG_PATH = EBML_PATH + @"GUI_Logs\";

        private static bool processRunning = false;
        private static bool injected = false;
        private static string injectorProcessOutput;
        private static string injectedAssemblyAddress;
        private static bool hasAutoInjected = false;

        public MainWindow() {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e) {
            // Create required directories if they do not exist
            Directory.CreateDirectory(GAME_PATH);
            Directory.CreateDirectory(EBML_PATH);
            Directory.CreateDirectory(LOG_PATH);

            LogToFile("", false);
            LogToFile("### New Session ###");

            PerformUpdate();
            updateTimer.Start();
        }

        private void updateTimer_Tick(object sender, EventArgs e) {
            PerformUpdate();   
        }

        private void PerformUpdate () {
            processRunning = Process.GetProcesses()
               .Select(p => p.ProcessName.ToLower())
               .Contains("evilbankmanager");

            if (!processRunning && injected) {
                injected = false;
                hasAutoInjected = false;
                injectedAssemblyAddress = null;
                Log("Game process with injected DLL has stopped");
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

                injectorWaitTimer.Start();
            }
        }

        public void InjectModLoaderDLL () {
            Log("Attempting to inject ModLoader DLL...");
            Log("Starting injector process...");
            statusLabel.Text = "Injecting DLL...";
            statusProgressBar.Visible = true;

            // Run injection async because injection may
            // take some time if game is not properly loaded
            injectorWorker.RunWorkerAsync();
        }

        public void EjectModLoaderDLL () {
            Log("Attempting to eject ModLoader DLL...");

            Process ejector = new Process() {
                StartInfo = new ProcessStartInfo {
                    FileName = "EBML/smi.exe",
                    Arguments = "eject -p EvilBankManager -a " + injectedAssemblyAddress + " -n EBML -c ModLoaderEntry -m OnEjection",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            Log("Starting ejector process...");
            string ejectorProcessOutput = "";

            try {
                ejector.Start();

                // Should only be one line, so no StringBuilder necessary
                while (!ejector.StandardOutput.EndOfStream) {
                    ejectorProcessOutput += ejector.StandardOutput.ReadLine();
                }

                Log("Ejector Output: " + ejectorProcessOutput);

                injected = !ejectorProcessOutput.StartsWith("Ejection successful");
            } catch (Exception e) {
                Log(e.ToString());
            }

            if (!injected)
                statusLabel.Text = "Ready - ModLoader not injected";
        }

        public void StartGameProcess () {
            Log("Starting game process using steam URL ('steam://rungameid/896160')...");
            Process.Start("steam://rungameid/896160");
        }

        private void button1_Click(object sender, EventArgs e) {
            if (!injected)
                InjectModLoaderDLL();
            else
                EjectModLoaderDLL();
        }

        private void button2_Click(object sender, EventArgs e) {
            if (!processRunning)
                StartGameProcess();
        }

        public void Log (string message) {
            LogToFile(message);

            textBox1.AppendText(String.Format("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message) + Environment.NewLine);
        }

        public void LogToFile (string message, bool includeTimestamp = true) {
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(System.IO.Path.Combine(LOG_PATH, DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), true)) {
                if (includeTimestamp)
                    outputFile.WriteLine(String.Format("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
                else
                    outputFile.WriteLine(message);
            }
        }

        private void injectorWorker_DoWork(object sender, DoWorkEventArgs args) {
            injectorProcessOutput = "";

            Process injector = new Process() {
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
                injector.Start();

                // Should only be one line, so no StringBuilder necessary
                while (!injector.StandardOutput.EndOfStream) {
                    injectorProcessOutput += injector.StandardOutput.ReadLine();
                }

                injected = injectorProcessOutput.StartsWith("EBML.dll");
            } catch (Exception e) {
                Log("Something went wrong with injector: " + e.ToString());
            }
        }

        private void injectorWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            Log("Injector Output: " + injectorProcessOutput);

            if (injected)
                injectedAssemblyAddress = injectorProcessOutput.Split(' ')[1];

            Log(injected ? "DLL has been successfully injected at address " + injectedAssemblyAddress : "An error occured while injecting DLL!");
            statusLabel.Text = injected ? "ModLoader DLL injected at memory address " + injectedAssemblyAddress : "Could not inject ModLoader DLL. Try restarting game.";
            statusProgressBar.Visible = false;
        }

        private void injectorWaitTimer_Tick(object sender, EventArgs e) {
            injectorWaitTimer.Stop();
            InjectModLoaderDLL();
        }

    }

}
