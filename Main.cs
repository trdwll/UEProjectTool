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

using Microsoft.Win32;
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

        private string PathToEngineExe = "\\Engine\\Binaries\\Win64\\UE4Editor.exe";
        private bool bEngineExists = false;
        private string ProjectFile = "";

        private List<string> EngineInstalls = new List<string>();

        private void btnCleanProject_Click(object sender, EventArgs e)
        {
            if (bEngineExists)
            {
                string[] SearchDirectories = { "Intermediate", "Binaries", "Saved", "Build" };
                string[] dirs = Directory.GetDirectories(Path.GetDirectoryName(ProjectFile), "*", SearchOption.AllDirectories);
                int count = 0;
                foreach (string directory in dirs)
                {
                    if (SearchDirectories.Any(Path.GetFileName(directory).Equals))
                    {
                        if (Directory.Exists(directory))
                        {
                            Directory.Delete(directory, true);
                            count++;
                        }
                    }
                }

                MessageBox.Show($"Deleted {count} directories!");

                // #TODO: Generate new sln
            }
        }

        void TryGetEngineInstalls()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\EpicGames\\Unreal Engine"))
            {
                string[] keys = key.GetSubKeyNames();
                foreach (string k in keys)
                {
                    string EngineInstall = key.OpenSubKey(k).GetValue("InstalledDirectory").ToString();

                    if (Directory.Exists(EngineInstall))
                    {
                        cbSelectedEngine.Items.Add(EngineInstall);
                    }
                }

                key.Close();
            }

            if (cbSelectedEngine.Items.Count > 0)
            {
                cbSelectedEngine.SelectedIndex = 0;
                bEngineExists = true;
            }
        }

        protected override void OnLoad(System.EventArgs e)
        {
            TryGetEngineInstalls();

            string[] files = System.IO.Directory.GetFiles(Application.StartupPath, "*.uproject");
            if (files.Length > 0)
            {
                ProjectFile = files[0];
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
                case EJobType.TestServerProfiling:
                    JobCommand = $"\"{EnginePath}\" \"{ProjectFile}\" -server -log -Port=7777 -QueryPort={Port} -networkprofiler=true";
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
    }
}
