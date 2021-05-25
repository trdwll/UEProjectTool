﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Reflection;
using System.Drawing;

using Microsoft.Win32;
using Microsoft.VisualBasic.FileIO;
using SearchOption = System.IO.SearchOption;

namespace UEProjectTool
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private enum EJobType
        {
            TestClient,
            TestServer,
            TestServerProfiling,
            BatchServer,
            CompileBP
        }

        private struct EngineInstall
        {
            public string Name;
            public string Path;
            public bool bIsSourceBuild;

            public EngineInstall(string name, string path, bool bSource)
            {
                Name = name;
                Path = path;
                bIsSourceBuild = bSource;
            }
        }


        private bool bEngineExists = false;
        private string ProjectFile = "";
        private List<EngineInstall> EngineInstalls = new List<EngineInstall>();
        private EngineInstall CurrentSelectedEngine = new EngineInstall();
        private string CurrentProjectEngine;

        private Color DefaultBackgroundColor = System.Drawing.ColorTranslator.FromHtml("#313131");
        private Color DefaultTextColor = System.Drawing.ColorTranslator.FromHtml("#DDDDDD");
        private Color DefaultBackColor2 = System.Drawing.ColorTranslator.FromHtml("#222222");
        private Color DefaultHoverColor = System.Drawing.ColorTranslator.FromHtml("#DEA309");
        private Color DefaultPressedColor = System.Drawing.ColorTranslator.FromHtml("#DA8209");
        private Color DefaultBorderColor = System.Drawing.ColorTranslator.FromHtml("#161616");

        private void btnCleanProject_Click(object sender, EventArgs e)
        {
            if (bEngineExists)
            {
                string[] SearchDirectories = { "Intermediate", "Binaries", "Saved" };
                string[] dirs = Directory.GetDirectories(Path.GetDirectoryName(ProjectFile), "*", SearchOption.AllDirectories);
                int count = 0;
                foreach (string directory in dirs)
                {
                    if (SearchDirectories.Any(Path.GetFileName(directory).Equals))
                    {
                        if (Directory.Exists(directory))
                        {
                            if (cbRecycle.Checked)
                            {
                                FileSystem.DeleteDirectory(directory, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                            }
                            else
                            {
                                Directory.Delete(directory, true);
                            }
                            count++;
                        }
                    }
                }

                MessageBox.Show($"{(cbRecycle.Checked ? "Recycled" : "Deleted")} {count} directories!");

                if (cbGenSolution.Checked)
                {
                    RegenerateSolution();
                }
            }
        }

        void RegenerateSolution()
        {
            string UBT = $"{CurrentSelectedEngine.Path}\\Engine\\Binaries\\DotNET\\UnrealBuildTool.exe";
            if (File.Exists(UBT))
            {
                string ProjectSln = $@"{Application.StartupPath}\\{Path.GetFileNameWithoutExtension(ProjectFile)}.sln";

                if (File.Exists(ProjectSln))
                {
                    File.Delete(ProjectSln);
                }

                string command = $"\"{UBT}\" -projectfiles -project=\"{ProjectFile}\" -game -rocket -progress & exit";
                ProcessStartInfo process = new ProcessStartInfo();
                process.WindowStyle = ProcessWindowStyle.Normal;
                process.FileName = "cmd.exe";
                process.Arguments = $"/k \"{command}\"";
                Process.Start(process);

                // Update the uproject to be the new engine since UBT isn't updating it...
            }
        }

        void TryGetEngineInstalls()
        {
            string[] files = System.IO.Directory.GetFiles(Application.StartupPath, "*.uproject");
            if (files.Length > 0)
            {
                ProjectFile = files[0];
            }

            if (string.IsNullOrEmpty(ProjectFile))
            {
                MessageBox.Show("Sorry, but no project file was found!");
                Application.Exit();
            }

            // Finds Epic Launcher installs
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\EpicGames\\Unreal Engine"))
            {
                string[] keys = key.GetSubKeyNames();
                foreach (string k in keys)
                {
                    string EnginePath = key.OpenSubKey(k).GetValue("InstalledDirectory").ToString();

                    if (Directory.Exists(EnginePath))
                    {
                        cbSelectedEngine.Items.Add(EnginePath);
                        EngineInstalls.Add(new EngineInstall(k, EnginePath, false));
                    }
                }

                key.Close();
            }

            // Finds source installs
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Epic Games\\Unreal Engine\\Builds"))
            {
                string[] keys = key.GetValueNames();
                foreach (string k in keys)
                {
                    string EnginePath = key.GetValue(k).ToString().Replace('/', '\\');

                    if (Directory.Exists(EnginePath))
                    {
                        cbSelectedEngine.Items.Add(EnginePath);
                        EngineInstalls.Add(new EngineInstall(k, EnginePath, true));
                    }
                }

                key.Close();
            }

            bEngineExists = EngineInstalls.Count > 0;
        }

        void InitTheme()
        {
            this.BackColor = DefaultBackgroundColor;

            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.FlatAppearance.MouseOverBackColor = DefaultHoverColor;
                button.FlatAppearance.MouseDownBackColor = DefaultPressedColor;
                button.FlatAppearance.BorderColor = DefaultBorderColor;
                button.ForeColor = DefaultTextColor;
            }

            foreach (GroupBox groupbox in this.Controls.OfType<GroupBox>())
            {
                groupbox.ForeColor = DefaultTextColor;

                foreach (Button button in groupbox.Controls.OfType<Button>())
                {
                    button.FlatAppearance.MouseOverBackColor = DefaultHoverColor;
                    button.FlatAppearance.MouseDownBackColor = DefaultPressedColor;
                    button.FlatAppearance.BorderColor = DefaultBorderColor;
                    button.ForeColor = DefaultTextColor;
                }
            }

            foreach (CheckBox checkbox in this.Controls.OfType<CheckBox>())
            {
                checkbox.ForeColor = DefaultTextColor;
            }

            cbSelectedEngine.BackColor = DefaultBackColor2;
            cbSelectedEngine.ForeColor = DefaultTextColor;

            numericUpDown1.BackColor = DefaultBackColor2;
            numericUpDown1.ForeColor = DefaultTextColor;

            linkLabel1.LinkColor = System.Drawing.ColorTranslator.FromHtml("#DA8209");
        }

        protected override void OnLoad(System.EventArgs e)
        {
            // set up the theme
            InitTheme();

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Text = $"UEProjectTool - v{fileVersionInfo.ProductVersion}";

            TryGetEngineInstalls();

            // Parses the uproject to get the current engine identifier for the project
            string CurEnginePath = "";
            using (StreamReader r = new StreamReader(ProjectFile))
            {
                string json = r.ReadToEnd();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dynamic array = serializer.Deserialize<dynamic>(json);

                foreach (var a in array)
                {
                    if (a.Key == "EngineAssociation")
                    {
                        CurEnginePath = a.Value.ToString();
                        CurrentProjectEngine = a.Key.ToString();
                        break;
                    }
                }

                r.Close();
            }

            if (!string.IsNullOrEmpty(CurEnginePath))
            {
                // Set the selected engine to the one defined in the uproject
                cbSelectedEngine.SelectedItem = EngineInstalls.Where(x => x.Name == CurEnginePath).Select(x => x.Path).Single().ToString();
            }
            else
            {
                cbSelectedEngine.SelectedIndex = 0;
            }

            cbRecycle.Checked = Properties.Settings.Default.Recycle;
            cbGenSolution.Checked = Properties.Settings.Default.GenSolution;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://trdwll.com");
        }

        void RunCmd(EJobType Command, int Port = 0)
        {
            string EnginePath = "\\Engine\\Binaries\\Win64\\UE4Editor.exe";

            string JobCommand = "";
            switch (Command)
            {
                case EJobType.BatchServer:
                    JobCommand = $"\"{CurrentSelectedEngine.Path}{EnginePath}\" \"{ProjectFile}\" -server -log -Port=7777 -QueryPort={Port}";
                    break;
                case EJobType.CompileBP:
                    JobCommand = $"\"{CurrentSelectedEngine.Path}{EnginePath}\" \"{ProjectFile}\" -run=CompileAllBlueprints";
                    break;
                case EJobType.TestClient:
                    JobCommand = $"\"{CurrentSelectedEngine.Path}{EnginePath}\" \"{ProjectFile}\" -game -log -resX=900 -resY=700 -windowed";
                    break;
                case EJobType.TestServer:
                    JobCommand = $"\"{CurrentSelectedEngine.Path}{EnginePath}\" \"{ProjectFile}\" -server -log -Port=7777 -QueryPort={Port}";
                    break;
                case EJobType.TestServerProfiling:
                    JobCommand = $"\"{CurrentSelectedEngine.Path}{EnginePath}\" \"{ProjectFile}\" -server -log -Port=7777 -QueryPort={Port} -networkprofiler=true";
                    break;
            }

            ProcessStartInfo process = new ProcessStartInfo();
            process.WindowStyle = ProcessWindowStyle.Normal;
            process.FileName = "cmd.exe";
            process.Arguments = $"/k \"{JobCommand}\"";
            Process.Start(process);
        }

        private void btnCompileBP_Click(object sender, EventArgs e)
        {
            RunCmd(EJobType.CompileBP);
        }

        private void btnTestServer_Click(object sender, EventArgs e)
        {
            RunCmd(EJobType.TestServer, 27015);
        }
        private void btnRunServerProfiling_Click(object sender, EventArgs e)
        {
            RunCmd(EJobType.TestServerProfiling, 27015);
        }

        private void btnTestClient_Click(object sender, EventArgs e)
        {
            RunCmd(EJobType.TestClient);
        }

        private void btnBatchServer_Click(object sender, EventArgs e)
        {
            int SteamPort = 27015;
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                RunCmd(EJobType.BatchServer, SteamPort);
                SteamPort++;
            }
        }

        private void btnKillUE4_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("UE4Editor"))
            {
                process.Kill();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Recycle = cbRecycle.Checked;
            Properties.Settings.Default.GenSolution = cbGenSolution.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnRegenerate_Click(object sender, EventArgs e)
        {
            RegenerateSolution();
        }

        private void btnOpenEngineDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(cbSelectedEngine.SelectedItem.ToString());
        }

        private void cbSelectedEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bIsSourceBuild = EngineInstalls.Any(x => x.Path == cbSelectedEngine.SelectedItem.ToString() && x.bIsSourceBuild);
            //btnCleanEngine.Enabled = bIsSourceBuild;

            string EngineName = EngineInstalls.Where(x => x.Path == cbSelectedEngine.SelectedItem.ToString()).Single().Name;

            CurrentSelectedEngine.Name = EngineName;
            CurrentSelectedEngine.Path = cbSelectedEngine.SelectedItem.ToString();
            CurrentSelectedEngine.bIsSourceBuild = bIsSourceBuild;
        }

        private void btnCleanEngine_Click(object sender, EventArgs e)
        {
            // do a cleanup of the engine ... 150GB is insane
        }
    }
}
