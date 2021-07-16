using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cuchi_lua_utils_v2
{
    public partial class App : Form
    {
        private static string pathToEdit = "";
        private static string logsFileText = "";
        private static bool logsEnabled = false;

        public App()
        {
            InitializeComponent();
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string FindFirstCharContainsString(string line)
        {
            string def = "unfinded";
            foreach (char c in line)
            {
                if (c == '"')
                {
                    return c.ToString();
                }
                else if (c == '\'')
                {
                    return c.ToString();
                }
            }
            return def;
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Extension == ".lua")
                {
                    string tempPath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(tempPath, false);
                }
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private static bool IsFivemEvent(string eventName)
        {
            string[] fivemEvents =
            {
                "gameEventTriggered",
                "onResourceStart",
                "populationPedCreating",
                "onClientResourceStart",
                "onResourceStop",
                "onClientResourceStop",
                "playerSpawned",
                "onClientMapStart",
                "onClientGameTypeStart",
                "onClientMapStop",
                "onClientGameTypeStop",
                "getMapDirectives",
                "onPlayerDied",
                "onPlayerKilled",
                "playerActivated",
                "sessionInitialized",
                "chatMessage",
                "chat:addMessage",
                "chat:addTemplate",
                "chat:removeSuggestion",
                "chat:clear",
                "entityCreated",
                "playerEnteredScope",
                "entityCreating",
                "entityRemoved",
                "onResourceListRefresh",
                "onServerResourceStart",
                "onServerResourceStop",
                "playerConnecting",
                "playerJoining",
                "playerLeftScope",
                "startProjectileEvent",
                "onResourceStarting",
                "playerDropped",
                "rconCommand",
                "weaponDamageEvent",
                "vehicleComponentControlEvent",
                "respawnPlayerPedEvent",
                "explosionEvent"
            };

            foreach (string fivemEventName in fivemEvents)
            {
                if (eventName == fivemEventName)
                {
                    return true;
                }
            }

            return false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pathToEdit) && string.IsNullOrEmpty(pathTextBox.Text))
            {
                MessageBox.Show("Please, select a folder to edit!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ResetOnNewStart();

            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(EventsChanger);
            worker.RunWorkerAsync();
        }

        private void ResetOnNewStart()
        {
            logsTextBox.Text = "";
            progressBar.Value = 0;
            percentLabel.Text = "0%";
        }

        private void EventsChanger(object sender, EventArgs e)
        {
            try
            {
                pathToEdit = pathTextBox.Text;

                Stopwatch watchFolder = new Stopwatch();
                watchFolder.Start();

                int filesCounter = 0;
                int linesCounter = 0;
                int totalLinesSkipped = 0;
                int totalLinesReplaced = 0;

                int iDir = 1;
                while (true)
                {
                    if (!Directory.Exists($@".\backups\backup-{iDir}\"))
                    {
                        Directory.CreateDirectory($@".\backups\backup-{iDir}\");
                        break;
                    }
                    iDir++;
                }

                if (logsEnabled)
                {
                    Stopwatch watchSave = new Stopwatch();
                    watchSave.Start();
                    var dirInfos = new DirectoryInfo(pathToEdit);
                    logsTextBox.Invoke(new Action(() => logsTextBox.Text += $"Saving {dirInfos.Name} to backups-{iDir}...\n"));
                    DirectoryCopy(pathToEdit, $@".\backups\backup-{iDir}\", true);
                    watchSave.Stop();
                    logsTextBox.Invoke(new Action(() => logsTextBox.Text += $"Saved to backups-{iDir}: took {Math.Round(watchSave.Elapsed.TotalSeconds, 2)} seconds\n"));
                }
                else
                {
                    DirectoryCopy(pathToEdit, $@".\backups\backup-{iDir}\", true);
                }

                string[] path = Directory.GetFiles(pathToEdit, "*.lua", SearchOption.AllDirectories);

                progressBar.Invoke(new Action(() => progressBar.Maximum = path.Length));

                foreach (string file in path)
                {
                    progressBar.Invoke(new Action(() => progressBar.Value = filesCounter));
                    double percent = (double)filesCounter / (double)path.Length * 100.0;

                    var currentFile = new FileInfo(file);

                    Stopwatch watchFile = new Stopwatch();
                    if (logsEnabled)
                    {
                        logsTextBox.Invoke(new Action(() => logsTextBox.Text += $"File: {currentFile.Name}\n"));
                        watchFile.Start();
                    }

                    string[] lines = File.ReadAllLines(file);
                    if (lines.Length > 0)
                    {
                        linesCounter += lines.Length;
                        using (StreamWriter f = new StreamWriter($@"{file}"))
                        {
                            for (int currLine = 0; currLine < lines.Length; currLine++)
                            {
                                if (!lines[currLine].StartsWith("--"))
                                {
                                    if (lines[currLine].Contains("AddEventHandler(") || lines[currLine].Contains("RegisterNetEvent(") || lines[currLine].Contains("TriggerServerEvent(") || lines[currLine].Contains("TriggerClientEvent(") || lines[currLine].Contains("TriggerEvent(") || lines[currLine].Contains("RegisterServerEvent("))
                                    {
                                        string[] linesSp = { };
                                        if (lines[currLine].Contains('"') && !lines[currLine].Contains('\''))
                                        {
                                            linesSp = lines[currLine].Split('"');
                                        }
                                        else if (lines[currLine].Contains('\'') && !lines[currLine].Contains('"'))
                                        {
                                            linesSp = lines[currLine].Split('\'');
                                        }
                                        else
                                        {
                                            if (FindFirstCharContainsString(lines[currLine]) == "\"")
                                            {
                                                linesSp = lines[currLine].Split('"');
                                            }
                                            else if (FindFirstCharContainsString(lines[currLine]) == "\'")
                                            {
                                                linesSp = lines[currLine].Split('\'');
                                            }
                                            else if (FindFirstCharContainsString(lines[currLine]) == "unfinded" && logsEnabled)
                                            {
                                                logsTextBox.Invoke(new Action(() => logsTextBox.Text += $"{currLine + 1}: skipped event. ({lines[currLine]})\n"));
                                            }
                                        }

                                        try
                                        {
                                            string nameOfEvent = linesSp[1];
                                            if (!IsFivemEvent(nameOfEvent))
                                            {
                                                lines[currLine] = lines[currLine].Replace(nameOfEvent, Base64Encode(nameOfEvent));
                                                totalLinesReplaced++;
                                            }
                                            else
                                            {
                                                totalLinesSkipped++;
                                                if (logsEnabled)
                                                {
                                                    logsTextBox.Invoke(new Action(() => logsTextBox.Text += $"{currLine + 1}: skipped event (FiveM event).\n"));
                                                }
                                            }
                                        }
                                        catch (IndexOutOfRangeException)
                                        {
                                            totalLinesSkipped++;
                                            if (logsEnabled)
                                            {
                                                logsTextBox.Invoke(new Action(() => logsTextBox.Text += $"{currLine + 1}: skipped event (out of range). ({lines[currLine]})\n"));
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                            return;
                                        }
                                    }
                                }
                            }
                        }

                        File.WriteAllLines(file, lines);
                        if (logsEnabled)
                        {
                            watchFile.Stop();
                            logsTextBox.Invoke(new Action(() => logsTextBox.Text += $"Replaced for {currentFile.Name}\nProcess (replaced {lines.Length} lines) took: {Math.Round(watchFile.Elapsed.TotalSeconds, 5)} seconds\n"));
                        }
                    }
                    progressBar.Invoke(new Action(() => progressBar.Refresh()));
                    percentLabel.Invoke(new Action(() =>
                    {
                        percentLabel.Text = $"{Math.Round(percent, 2)}%";
                        percentLabel.Refresh();
                    }));
                    logsTextBox.Invoke(new Action(() => logsTextBox.Refresh()));
                    filesCounter++;
                }
                watchFolder.Stop();

                progressBar.Invoke(new Action(() => progressBar.Value = progressBar.Maximum));
                percentLabel.Invoke(new Action(() => percentLabel.Text = $"100.00%"));
                logsTextBox.Invoke(new Action(() =>
                {
                    logsTextBox.Text += $"--------------------------------------------------------------\n";
                    logsTextBox.Text += $"Process took: {Math.Round(watchFolder.Elapsed.TotalSeconds, 2)} seconds\n";
                    logsTextBox.Text += $"Total files: {filesCounter}\n";
                    logsTextBox.Text += $"Total lines: {linesCounter}\n";
                    logsTextBox.Text += $"Total lines skipped: {totalLinesSkipped}\n";
                    logsTextBox.Text += $"Total lines replaced: {totalLinesReplaced}\n";
                    logsTextBox.Text += $"Total lines replaced: {totalLinesReplaced}\n";
                    logsTextBox.Text += $"--------------------------------------------------------------\n";
                    logsFileText = logsTextBox.Text;
                    LogsCreator();
                }));
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"{ex}", "ERROR: UnauthorizedAccessException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetOnNewStart();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetOnNewStart();
                return;
            }
        }

        private void LogsCreator()
        {
            if (saveLogsCheckBox.CheckState == CheckState.Checked)
            {
                if (!Directory.Exists(@".\logs\"))
                {
                    Directory.CreateDirectory(@".\logs\");
                }

                int iFil = 1;
                while (true)
                {
                    if (!File.Exists($@".\logs\logs-{iFil}.log"))
                    {
                        File.WriteAllText($@".\logs\logs-{iFil}.log", logsFileText);
                        break;
                    }
                    iFil++;
                }
            }
        }

        private void pathPickerButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                pathTextBox.Text = folderDlg.SelectedPath;
                pathToEdit = folderDlg.SelectedPath;
            }
        }

        private void logsButton_CheckStateChanged(object sender, EventArgs e)
        {
            if (logsButton.CheckState == CheckState.Checked)
            {
                logsEnabled = true;
            }
            else
            {
                logsEnabled = false;
            }
        }

        private void logsTextBox_TextChanged(object sender, EventArgs e)
        {
            logsTextBox.SelectionStart = logsTextBox.Text.Length;
            logsTextBox.ScrollToCaret();
        }

    }
}