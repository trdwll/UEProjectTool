﻿namespace UEProjectTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.cbSelectedEngine = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCleanProject = new System.Windows.Forms.Button();
            this.btnTestServer = new System.Windows.Forms.Button();
            this.btnTestClient = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnBatchServer = new System.Windows.Forms.Button();
            this.btnCompileBP = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnKillUE4 = new System.Windows.Forms.Button();
            this.btnRunServerProfiling = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSelectedEngine
            // 
            this.cbSelectedEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectedEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectedEngine.Location = new System.Drawing.Point(12, 12);
            this.cbSelectedEngine.Name = "cbSelectedEngine";
            this.cbSelectedEngine.Size = new System.Drawing.Size(423, 32);
            this.cbSelectedEngine.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Location = new System.Drawing.Point(441, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemove.BackgroundImage")));
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemove.Location = new System.Drawing.Point(479, 13);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(32, 32);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCleanProject
            // 
            this.btnCleanProject.Location = new System.Drawing.Point(18, 72);
            this.btnCleanProject.Name = "btnCleanProject";
            this.btnCleanProject.Size = new System.Drawing.Size(88, 32);
            this.btnCleanProject.TabIndex = 3;
            this.btnCleanProject.Text = "Clean Project";
            this.btnCleanProject.UseVisualStyleBackColor = true;
            this.btnCleanProject.Click += new System.EventHandler(this.btnCleanProject_Click);
            // 
            // btnTestServer
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 162);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Testing";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.btnBatchServer);
            this.groupBox2.Location = new System.Drawing.Point(339, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Batch";
            // 
            // numericUpDown1
            // 
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
            this.btnCompileBP.Location = new System.Drawing.Point(112, 72);
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
            this.linkLabel1.Location = new System.Drawing.Point(385, 266);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(126, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "By Russ \'trdwll\' Treadwell";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnKillUE4
            // 
            this.btnKillUE4.Location = new System.Drawing.Point(206, 72);
            this.btnKillUE4.Name = "btnKillUE4";
            this.btnKillUE4.Size = new System.Drawing.Size(88, 32);
            this.btnKillUE4.TabIndex = 11;
            this.btnKillUE4.Text = "Kill UE4";
            this.btnKillUE4.UseVisualStyleBackColor = true;
            this.btnKillUE4.Click += new System.EventHandler(this.btnKillUE4_Click);
            // 
            // btnRunServerProfiling
            // 
            this.btnRunServerProfiling.Location = new System.Drawing.Point(6, 57);
            this.btnRunServerProfiling.Name = "btnRunServerProfiling";
            this.btnRunServerProfiling.Size = new System.Drawing.Size(109, 32);
            this.btnRunServerProfiling.TabIndex = 6;
            this.btnRunServerProfiling.Text = "RTS Profiling";
            this.btnRunServerProfiling.UseVisualStyleBackColor = true;
            this.btnRunServerProfiling.Click += new System.EventHandler(this.btnRunServerProfiling_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 288);
            this.Controls.Add(this.btnKillUE4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnCompileBP);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCleanProject);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbSelectedEngine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UEProjectTool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSelectedEngine;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCleanProject;
        private System.Windows.Forms.Button btnTestServer;
        private System.Windows.Forms.Button btnTestClient;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBatchServer;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnCompileBP;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnKillUE4;
        private System.Windows.Forms.Button btnRunServerProfiling;
    }
}

