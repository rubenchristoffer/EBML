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

namespace EBML_GUI {
    public partial class MainWindow : Form {

        private static bool processRunning = false;

        public MainWindow() {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e) {
            Update();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void tabPage1_Click(object sender, EventArgs e) {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e) {

        }

        private void timer1_Tick(object sender, EventArgs e) {
            Update();   
        }

        private void Update () {
            processRunning = Process.GetProcesses()
               .Select(p => p.ProcessName.ToLower())
               .Contains("evilbankmanager");

            label1.Text = processRunning ? "EvilBankManager process running" : "EvilBankManager process not running";
            label1.ForeColor = processRunning ? Color.Green : Color.Red;

            button1.Enabled = processRunning;

            button2.Text = processRunning ? "Game running" : "Start EBM";
            button2.Enabled = !processRunning;
        }

        private void button2_Click(object sender, EventArgs e) {
            if (!processRunning)
                Process.Start("steam://rungameid/896160"); 
        }
    }
}
