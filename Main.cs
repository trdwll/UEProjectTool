using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
            BatchServer,
            CompileBP
        }

        // TODO: default engine install paths
        // TODO: default selected install should be last selected

        private string PathToEngineExe = "\\Engine\\Binaries\\Win64\\UE4Editor.exe";
        private bool bEngineExists = false;
        private string ProjectFile = "";

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog()
            {
                Description = "Select your UE4 install path (Just the UE_4.x and not Engine etc)"
            };

            if (fdb.ShowDialog() == DialogResult.OK)
            {
                string EnginePath = fdb.SelectedPath;
                string EngineExe = $"{EnginePath}{PathToEngineExe}";

                if (System.IO.File.Exists(EngineExe))
                {
                    MessageBox.Show("Engine file exists!");
                    Properties.Settings.Default.EnginePath += Properties.Settings.Default.EnginePath != string.Empty ? $";{EnginePath}" : $"{EnginePath}";
                    Properties.Settings.Default.Save();
                    cbSelectedEngine.Items.Add(EnginePath);
                    cbSelectedEngine.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show($"You selected the path {EnginePath} and it shouldn't be this. No UE4Editor.exe was found.");
                }
            }
        }

        private void btnCleanProject_Click(object sender, EventArgs e)
        {
            if (bEngineExists)
            {
                string[] SearchDirectories = { "Intermediate", "Binaries", "Saved", "Build" };
                string[] dirs = Directory.GetDirectories(Path.GetDirectoryName(ProjectFile), "*", SearchOption.AllDirectories);

                foreach (string directory in dirs)
                {
                    if (SearchDirectories.Any(directory.Contains))
                    {
                        if (Directory.Exists(directory))
                        {
                            Directory.Delete(directory, true);
                        }
                    }
                }

                MessageBox.Show("Cleaned up the project!");
            }
        }

        protected override void OnLoad(System.EventArgs e)
        {
            foreach (string s in Properties.Settings.Default.EnginePath.Split(';'))
            {
                cbSelectedEngine.Items.Add(s);
            }
            if (cbSelectedEngine.Items.Count > 1)
            {
                if (cbSelectedEngine.Items[0].ToString() == string.Empty)
                {
                    cbSelectedEngine.Items.RemoveAt(0);
                }
                cbSelectedEngine.SelectedIndex = 0;
                bEngineExists = true;
            }
            string[] files = System.IO.Directory.GetFiles(Application.StartupPath, "*.uproject");
            if (files.Length > 0)
            {
                ProjectFile = files[0];
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string selected = "";
            foreach (string s in Properties.Settings.Default.EnginePath.Split(';'))
            {
                if (s == cbSelectedEngine.SelectedItem.ToString())
                {
                    continue;
                }

                selected += selected != string.Empty ? $";{s}" : $"{s}";
            }

            Properties.Settings.Default.EnginePath = selected;
            Properties.Settings.Default.Save();
            cbSelectedEngine.Items.RemoveAt(cbSelectedEngine.SelectedIndex);
            if (cbSelectedEngine.Items.Count > 0)
            {
                cbSelectedEngine.SelectedIndex = 0;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://trdwll.com");
        }

        void RunCmd(EJobType Command, int Port = 0)
        {
            string EnginePath = $"{cbSelectedEngine.SelectedItem}{PathToEngineExe}";
            string JobCommand = "";
            switch (Command)
            {
                case EJobType.BatchServer:
                    JobCommand = $"\"{EnginePath}\" \"{ProjectFile}\" -server -log -Port=7777 -QueryPort={Port}";
                    break;
                case EJobType.CompileBP:
                    JobCommand = $"\"{EnginePath}\" \"{ProjectFile}\" -run=CompileAllBlueprints";
                    break;
                case EJobType.TestClient:
                    JobCommand = $"\"{EnginePath}\" \"{ProjectFile}\" -game -log -resX=900 -resY=700 -windowed";
                    break;
                case EJobType.TestServer:
                    JobCommand = $"\"{EnginePath}\" \"{ProjectFile}\" -server -log -Port=7777 -QueryPort={Port}";
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
    }
}
