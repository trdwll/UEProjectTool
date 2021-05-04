using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Reflection;

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

        private string PathToEngineExe = "\\Engine\\Binaries\\Win64\\UE4Editor.exe";
        private bool bEngineExists = false;
        private string ProjectFile = "";
        private Dictionary<string, string> EngineInstalls = new Dictionary<string, string>();

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
                    string UBT = $"{cbSelectedEngine.Text}\\Engine\\Binaries\\DotNET\\UnrealBuildTool.exe";
                    if (File.Exists(UBT))
                    {
                        string ProjectSln = $@"{Application.StartupPath}\\{Path.GetFileNameWithoutExtension(ProjectFile)}.sln";

                        if (File.Exists(ProjectSln))
                        {
                            File.Delete(ProjectSln);
                        }

                        string command = $"\"{UBT}\" -projectfiles -project=\"{ProjectFile}\" -game -rocket";
                        ProcessStartInfo process = new ProcessStartInfo();
                        process.WindowStyle = ProcessWindowStyle.Normal;
                        process.FileName = "cmd.exe";
                        process.Arguments = $"/k \"{command}\"";
                        Process.Start(process);
                    }
                }
            }
        }

        void TryGetEngineInstalls()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Text = $"UEProjectTool - v{fileVersionInfo.ProductVersion}";


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
                    string EngineInstall = key.OpenSubKey(k).GetValue("InstalledDirectory").ToString();

                    if (Directory.Exists(EngineInstall))
                    {
                        cbSelectedEngine.Items.Add(EngineInstall);
                        EngineInstalls.Add(k, EngineInstall);
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
                    string EngineInstall = key.GetValue(k).ToString();

                    if (Directory.Exists(EngineInstall))
                    {
                        cbSelectedEngine.Items.Add(EngineInstall);
                        EngineInstalls.Add(k, EngineInstall);
                    }
                }

                key.Close();
            }

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
                        break;
                    }
                }

                r.Close();
            }

            if (!string.IsNullOrEmpty(CurEnginePath))
            {
                // Set the selected engine to the one defined in the uproject
                cbSelectedEngine.SelectedItem = EngineInstalls.Where(x => x.Key == CurEnginePath).Select(x => x.Value).Single().ToString();
            }
            else
            {
                cbSelectedEngine.SelectedIndex = 0;
            }
        }

        protected override void OnLoad(System.EventArgs e)
        {
            TryGetEngineInstalls();

            cbRecycle.Checked = Properties.Settings.Default.Recycle;
            cbGenSolution.Checked = Properties.Settings.Default.GenSolution;
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Recycle = cbRecycle.Checked;
            Properties.Settings.Default.GenSolution = cbGenSolution.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
