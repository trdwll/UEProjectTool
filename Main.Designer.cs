namespace UEProjectTool
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbSelectedEngine = new System.Windows.Forms.ComboBox();
            this.btnCleanProject = new System.Windows.Forms.Button();
            this.btnTestServer = new System.Windows.Forms.Button();
            this.btnTestClient = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRunServerProfiling = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnBatchServer = new System.Windows.Forms.Button();
            this.btnCompileBP = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnKillUnreal = new System.Windows.Forms.Button();
            this.cbRecycle = new System.Windows.Forms.CheckBox();
            this.cbGenSolution = new System.Windows.Forms.CheckBox();
            this.btnRegenerate = new System.Windows.Forms.Button();
            this.btnOpenEngineDir = new System.Windows.Forms.Button();
            this.btnCleanEngine = new System.Windows.Forms.Button();
            this.cbUpdateUProject = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnIgnores = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSelectedEngine
            // 
            this.cbSelectedEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectedEngine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectedEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectedEngine.Location = new System.Drawing.Point(12, 12);
            this.cbSelectedEngine.Name = "cbSelectedEngine";
            this.cbSelectedEngine.Size = new System.Drawing.Size(451, 32);
            this.cbSelectedEngine.TabIndex = 0;
            this.cbSelectedEngine.SelectedIndexChanged += new System.EventHandler(this.cbSelectedEngine_SelectedIndexChanged);
            // 
            // btnCleanProject
            // 
            this.btnCleanProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCleanProject.Location = new System.Drawing.Point(6, 19);
            this.btnCleanProject.Name = "btnCleanProject";
            this.btnCleanProject.Size = new System.Drawing.Size(111, 32);
            this.btnCleanProject.TabIndex = 3;
            this.btnCleanProject.Text = "Clean Project";
            this.btnCleanProject.UseVisualStyleBackColor = true;
            this.btnCleanProject.Click += new System.EventHandler(this.btnCleanProject_Click);
            // 
            // btnTestServer
            // 
            this.btnTestServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestServer.Location = new System.Drawing.Point(6, 19);
            this.btnTestServer.Name = "btnTestServer";
            this.btnTestServer.Size = new System.Drawing.Size(109, 32);
            this.btnTestServer.TabIndex = 4;
            this.btnTestServer.Text = "Run Test Server";
            this.btnTestServer.UseVisualStyleBackColor = true;
            this.btnTestServer.Click += new System.EventHandler(this.btnTestServer_Click);
            // 
            // btnTestClient
            // 
            this.btnTestClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestClient.Location = new System.Drawing.Point(6, 124);
            this.btnTestClient.Name = "btnTestClient";
            this.btnTestClient.Size = new System.Drawing.Size(109, 32);
            this.btnTestClient.TabIndex = 5;
            this.btnTestClient.Text = "Run Test Client";
            this.btnTestClient.UseVisualStyleBackColor = true;
            this.btnTestClient.Click += new System.EventHandler(this.btnTestClient_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRunServerProfiling);
            this.groupBox1.Controls.Add(this.btnTestServer);
            this.groupBox1.Controls.Add(this.btnTestClient);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 162);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Testing";
            // 
            // btnRunServerProfiling
            // 
            this.btnRunServerProfiling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunServerProfiling.Location = new System.Drawing.Point(6, 57);
            this.btnRunServerProfiling.Name = "btnRunServerProfiling";
            this.btnRunServerProfiling.Size = new System.Drawing.Size(109, 32);
            this.btnRunServerProfiling.TabIndex = 6;
            this.btnRunServerProfiling.Text = "RTS Profiling";
            this.btnRunServerProfiling.UseVisualStyleBackColor = true;
            this.btnRunServerProfiling.Click += new System.EventHandler(this.btnRunServerProfiling_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.btnBatchServer);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(348, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Batch";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.Location = new System.Drawing.Point(121, 27);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnBatchServer
            // 
            this.btnBatchServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchServer.Location = new System.Drawing.Point(6, 19);
            this.btnBatchServer.Name = "btnBatchServer";
            this.btnBatchServer.Size = new System.Drawing.Size(109, 32);
            this.btnBatchServer.TabIndex = 5;
            this.btnBatchServer.Text = "Batch Run Server";
            this.btnBatchServer.UseVisualStyleBackColor = true;
            this.btnBatchServer.Click += new System.EventHandler(this.btnBatchServer_Click);
            // 
            // btnCompileBP
            // 
            this.btnCompileBP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompileBP.Location = new System.Drawing.Point(222, 72);
            this.btnCompileBP.Name = "btnCompileBP";
            this.btnCompileBP.Size = new System.Drawing.Size(88, 32);
            this.btnCompileBP.TabIndex = 8;
            this.btnCompileBP.Text = "Compile BPs";
            this.btnCompileBP.UseVisualStyleBackColor = true;
            this.btnCompileBP.Click += new System.EventHandler(this.btnCompileBP_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(395, 286);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(126, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "By Russ \'trdwll\' Treadwell";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnKillUnreal
            // 
            this.btnKillUnreal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKillUnreal.Location = new System.Drawing.Point(316, 72);
            this.btnKillUnreal.Name = "btnKillUnreal";
            this.btnKillUnreal.Size = new System.Drawing.Size(88, 32);
            this.btnKillUnreal.TabIndex = 11;
            this.btnKillUnreal.Text = "Kill Unreal";
            this.btnKillUnreal.UseVisualStyleBackColor = true;
            this.btnKillUnreal.Click += new System.EventHandler(this.btnKillUE4_Click);
            // 
            // cbRecycle
            // 
            this.cbRecycle.AutoSize = true;
            this.cbRecycle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRecycle.Location = new System.Drawing.Point(348, 216);
            this.cbRecycle.Name = "cbRecycle";
            this.cbRecycle.Size = new System.Drawing.Size(179, 17);
            this.cbRecycle.TabIndex = 12;
            this.cbRecycle.Text = "Move To Recycling Bin on Clean";
            this.cbRecycle.UseVisualStyleBackColor = true;
            // 
            // cbGenSolution
            // 
            this.cbGenSolution.AutoSize = true;
            this.cbGenSolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGenSolution.Location = new System.Drawing.Point(348, 239);
            this.cbGenSolution.Name = "cbGenSolution";
            this.cbGenSolution.Size = new System.Drawing.Size(165, 17);
            this.cbGenSolution.TabIndex = 13;
            this.cbGenSolution.Text = "Regenerate Solution on Clean";
            this.cbGenSolution.UseVisualStyleBackColor = true;
            // 
            // btnRegenerate
            // 
            this.btnRegenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegenerate.Location = new System.Drawing.Point(128, 72);
            this.btnRegenerate.Name = "btnRegenerate";
            this.btnRegenerate.Size = new System.Drawing.Size(88, 32);
            this.btnRegenerate.TabIndex = 14;
            this.btnRegenerate.Text = "Regenerate";
            this.btnRegenerate.UseVisualStyleBackColor = true;
            this.btnRegenerate.Click += new System.EventHandler(this.btnRegenerate_Click);
            // 
            // btnOpenEngineDir
            // 
            this.btnOpenEngineDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenEngineDir.Location = new System.Drawing.Point(469, 13);
            this.btnOpenEngineDir.Name = "btnOpenEngineDir";
            this.btnOpenEngineDir.Size = new System.Drawing.Size(52, 32);
            this.btnOpenEngineDir.TabIndex = 15;
            this.btnOpenEngineDir.Text = "Open";
            this.btnOpenEngineDir.UseVisualStyleBackColor = true;
            this.btnOpenEngineDir.Click += new System.EventHandler(this.btnOpenEngineDir_Click);
            // 
            // btnCleanEngine
            // 
            this.btnCleanEngine.Enabled = false;
            this.btnCleanEngine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCleanEngine.Location = new System.Drawing.Point(6, 95);
            this.btnCleanEngine.Name = "btnCleanEngine";
            this.btnCleanEngine.Size = new System.Drawing.Size(111, 32);
            this.btnCleanEngine.TabIndex = 16;
            this.btnCleanEngine.Text = "Clean Engine";
            this.btnCleanEngine.UseVisualStyleBackColor = true;
            this.btnCleanEngine.Click += new System.EventHandler(this.btnCleanEngine_Click);
            // 
            // cbUpdateUProject
            // 
            this.cbUpdateUProject.AutoSize = true;
            this.cbUpdateUProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbUpdateUProject.Location = new System.Drawing.Point(348, 262);
            this.cbUpdateUProject.Name = "cbUpdateUProject";
            this.cbUpdateUProject.Size = new System.Drawing.Size(181, 17);
            this.cbUpdateUProject.TabIndex = 17;
            this.cbUpdateUProject.Text = "Update uproject on Regeneration";
            this.cbUpdateUProject.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(6, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "Clean DDC";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCleanProject);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnCleanEngine);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(141, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(123, 162);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cleaning";
            // 
            // btnIgnores
            // 
            this.btnIgnores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIgnores.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgnores.Location = new System.Drawing.Point(147, 278);
            this.btnIgnores.Name = "btnIgnores";
            this.btnIgnores.Size = new System.Drawing.Size(111, 22);
            this.btnIgnores.TabIndex = 19;
            this.btnIgnores.Text = "Ignores";
            this.btnIgnores.UseVisualStyleBackColor = true;
            this.btnIgnores.Click += new System.EventHandler(this.btnIgnores_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 308);
            this.Controls.Add(this.btnIgnores);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cbUpdateUProject);
            this.Controls.Add(this.btnOpenEngineDir);
            this.Controls.Add(this.btnRegenerate);
            this.Controls.Add(this.cbGenSolution);
            this.Controls.Add(this.cbRecycle);
            this.Controls.Add(this.btnKillUnreal);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnCompileBP);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbSelectedEngine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UEProjectTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSelectedEngine;
        private System.Windows.Forms.Button btnCleanProject;
        private System.Windows.Forms.Button btnTestServer;
        private System.Windows.Forms.Button btnTestClient;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBatchServer;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnCompileBP;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnKillUnreal;
        private System.Windows.Forms.Button btnRunServerProfiling;
        private System.Windows.Forms.CheckBox cbRecycle;
        private System.Windows.Forms.CheckBox cbGenSolution;
        private System.Windows.Forms.Button btnRegenerate;
        private System.Windows.Forms.Button btnOpenEngineDir;
        private System.Windows.Forms.Button btnCleanEngine;
        private System.Windows.Forms.CheckBox cbUpdateUProject;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnIgnores;
    }
}

