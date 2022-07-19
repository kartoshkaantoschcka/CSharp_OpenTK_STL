
namespace OpenTK_STL_WinForms
{
    partial class FormOpenTK
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogSTL = new System.Windows.Forms.OpenFileDialog();
            this.glControl = new OpenTK.WinForms.GLControl();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpenFile,
            this.toolStripSeparator2,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(59, 24);
            this.miFile.Text = "Файл";
            // 
            // miOpenFile
            // 
            this.miOpenFile.Name = "miOpenFile";
            this.miOpenFile.Size = new System.Drawing.Size(159, 26);
            this.miOpenFile.Text = "Открыть...";
            this.miOpenFile.Click += new System.EventHandler(this.miOpenFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(159, 26);
            this.miExit.Text = "Выход";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(81, 24);
            this.miHelp.Text = "Справка";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(187, 26);
            this.miAbout.Text = "О программе";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // openFileDialogSTL
            // 
            this.openFileDialogSTL.Filter = "\"stl файлы (*.stl)|*.stl|Все файлы (*.*)|*.*\"";
            this.openFileDialogSTL.ShowReadOnly = true;
            this.openFileDialogSTL.Title = "Открыть STL-файл...";
            // 
            // glControl
            // 
            this.glControl.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            this.glControl.APIVersion = new System.Version(3, 3, 0, 0);
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            this.glControl.IsEventDriven = true;
            this.glControl.Location = new System.Drawing.Point(0, 28);
            this.glControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.glControl.Name = "glControl";
            this.glControl.Profile = OpenTK.Windowing.Common.ContextProfile.Compatability;
            this.glControl.Size = new System.Drawing.Size(800, 422);
            this.glControl.TabIndex = 3;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseUp);
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarProgress});
            this.statusBar.Location = new System.Drawing.Point(0, 426);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(800, 24);
            this.statusBar.TabIndex = 4;
            // 
            // statusBarProgress
            // 
            this.statusBarProgress.Name = "statusBarProgress";
            this.statusBarProgress.Size = new System.Drawing.Size(200, 16);
            this.statusBarProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // FormOpenTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormOpenTK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STL";
            this.Load += new System.EventHandler(this.FormOpenTK_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.OpenFileDialog openFileDialogSTL;
        private OpenTK.WinForms.GLControl glControl;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripProgressBar statusBarProgress;
    }
}

