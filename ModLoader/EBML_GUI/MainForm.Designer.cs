namespace EBML_GUI {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.button2 = new System.Windows.Forms.Button();
			this.autoInjectCheckbox = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.updateTimer = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.injectorWorker = new System.ComponentModel.BackgroundWorker();
			this.injectorWaitTimer = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(100, 45);
			this.button2.TabIndex = 2;
			this.button2.Text = "Start EBM";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// autoInjectCheckbox
			// 
			this.autoInjectCheckbox.AutoSize = true;
			this.autoInjectCheckbox.Checked = true;
			this.autoInjectCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoInjectCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.autoInjectCheckbox.Location = new System.Drawing.Point(224, 33);
			this.autoInjectCheckbox.Name = "autoInjectCheckbox";
			this.autoInjectCheckbox.Size = new System.Drawing.Size(237, 24);
			this.autoInjectCheckbox.TabIndex = 3;
			this.autoInjectCheckbox.Text = "Try Auto-Injecting ModLoader";
			this.autoInjectCheckbox.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(118, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 45);
			this.button1.TabIndex = 4;
			this.button1.Text = "Manually Inject DLL";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// updateTimer
			// 
			this.updateTimer.Interval = 2000;
			this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(10, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(187, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "EvilBankManager process not running";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusProgressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 439);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(834, 22);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(177, 17);
			this.statusLabel.Text = "Ready - ModLoader not injected";
			// 
			// statusProgressBar
			// 
			this.statusProgressBar.MarqueeAnimationSpeed = 1;
			this.statusProgressBar.Name = "statusProgressBar";
			this.statusProgressBar.Size = new System.Drawing.Size(50, 16);
			this.statusProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.statusProgressBar.Value = 50;
			this.statusProgressBar.Visible = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 80);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.Padding = new System.Drawing.Point(10, 5);
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(810, 359);
			this.tabControl1.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(802, 329);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Manage mods";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.textBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(802, 329);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Log";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(3, 3);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(796, 323);
			this.textBox1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(224, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(349, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "- Make sure to wait until the game has loaded before attempting to inject!";
			// 
			// injectorWorker
			// 
			this.injectorWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.injectorWorker_DoWork);
			this.injectorWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.injectorWorker_RunWorkerCompleted);
			// 
			// injectorWaitTimer
			// 
			this.injectorWaitTimer.Interval = 5000;
			this.injectorWaitTimer.Tick += new System.EventHandler(this.injectorWaitTimer_Tick);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(834, 461);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.autoInjectCheckbox);
			this.Controls.Add(this.button2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(500, 500);
			this.Name = "MainWindow";
			this.Text = "Evil Bank Manager Mod Loader (EBML)";
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        System.Windows.Forms.Button button2;
        System.Windows.Forms.CheckBox autoInjectCheckbox;
        System.Windows.Forms.Button button1;
        System.Windows.Forms.Timer updateTimer;
        System.Windows.Forms.Label label1;
        System.Windows.Forms.StatusStrip statusStrip1;
        System.Windows.Forms.TabControl tabControl1;
        System.Windows.Forms.TabPage tabPage1;
        System.Windows.Forms.TabPage tabPage2;
        System.Windows.Forms.Label label2;
        System.Windows.Forms.TextBox textBox1;
        System.Windows.Forms.ToolStripStatusLabel statusLabel;
        System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        System.ComponentModel.BackgroundWorker injectorWorker;
        System.Windows.Forms.Timer injectorWaitTimer;
    }
}

