using System;
using System.Diagnostics;
using System.Text;

namespace PackOptimizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // No comment here anymore, everything is explained in the readme. Also: regions.
        }
        private string targetDirectory;
        private string extractionDirectory;

        #region Main Code (Non-Async)

        // All of this needs to go, and it will, eventually.
        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    targetDirectory = folderDialog.SelectedPath;
                    string[] files = Directory.GetFiles(targetDirectory, "*.gma", SearchOption.AllDirectories);

                    richTextBox1.Clear();

                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        richTextBox1.AppendText("Loaded " + fileName + Environment.NewLine);
                    }
                }

                richTextBox1.AppendText("---------------FINISHED LOADING FILES---------------");
            }
        }

        string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private async void button2_Click(object sender, EventArgs e)
        {
            if (asyncExtractCheckBox.Checked == true)
            {
                string gmadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gmad.exe");
                string[] gmaFiles = Directory.GetFiles(targetDirectory, "*.gma", SearchOption.AllDirectories);
                string exeLocation = AppDomain.CurrentDomain.BaseDirectory;
                string directoryName = "extracted";
                string newDirectoryPath = Path.Combine(exeLocation, directoryName);

                await ExtractGMAsAsync(gmaFiles, newDirectoryPath, gmadPath);
            }
            else
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                if (!string.IsNullOrEmpty(targetDirectory))
                {
                    string gmadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gmad.exe");
                    string[] gmaFiles = Directory.GetFiles(targetDirectory, "*.gma", SearchOption.AllDirectories);

                    string exeLocation = AppDomain.CurrentDomain.BaseDirectory;
                    string directoryName = "extracted";

                    string newDirectoryPath = Path.Combine(exeLocation, directoryName);

                    // Create the extraction directory if it doesn't exist
                    if (!Directory.Exists(newDirectoryPath))
                    {
                        Directory.CreateDirectory(newDirectoryPath);
                    }

                    foreach (string gmaFile in gmaFiles)
                    {
                        string extractedFolder = Path.GetFileNameWithoutExtension(gmaFile);
                        string addonFolderPath = Path.Combine(newDirectoryPath, extractedFolder);

                        // Create the addon folder within the "extracted" directory
                        Directory.CreateDirectory(addonFolderPath);

                        string addonFileName = Path.GetFileName(gmaFile);
                        if (addonFileName.Equals("gmpublisher.gma", StringComparison.OrdinalIgnoreCase))
                        {
                            string parentFolderName = Path.GetFileName(Path.GetDirectoryName(gmaFile));
                            addonFolderPath = Path.Combine(newDirectoryPath, parentFolderName);
                        }

                        string gmadArguments = $"extract -file \"{gmaFile}\" -out \"{addonFolderPath}\"";

                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = gmadPath,
                            Arguments = gmadArguments,
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true
                        };

                        using (Process process = new Process())
                        {
                            process.StartInfo = startInfo;

                            process.ErrorDataReceived += Process_ErrorDataReceived;
                            process.OutputDataReceived += Process_OutputDataReceived;

                            process.Start();
                            process.BeginOutputReadLine();
                            process.BeginErrorReadLine();

                            await Task.Run(() => process.WaitForExit());
                        }

                        // Create the addon.json file within the extracted folder
                        string addonJsonPath = Path.Combine(addonFolderPath, "addon.json");

                        // Construct the addon.json content
                        string addonJsonContent = @"{
                ""title"": ""gch Extracted Addon"",
                ""type"": ""tool"",
                ""ignore"": [""*.psd""],
                ""description"": ""This addon was extracted using gch."",
                ""author_name"": ""gch"",
                ""author_email"": ""gch@example.com"",
                ""author_website"": ""https://gcpo-website.com"",
                ""version"": ""1.0""
            }";

                        await Task.Run(() => File.WriteAllText(addonJsonPath, addonJsonContent));
                    }

                    richTextBox1.AppendText("File processing completed. Extracted files are stored in the 'extracted' directory." + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("Please select a target directory first.", "Directory Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                sw.Stop();
                richTextBox1.AppendText($"Extraction Time: {sw.Elapsed.TotalSeconds} seconds");
            }

        }



        private async void button3_Click(object sender, EventArgs e)
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string extractionDirectory = Path.Combine(workingDirectory, "extracted");
            string compressedDirectory = Path.Combine(workingDirectory, "compressed");

            // Create the 'compressed' directory if it doesn't exist
            if (!Directory.Exists(compressedDirectory))
            {
                Directory.CreateDirectory(compressedDirectory);
            }

            string[] addonDirectories = Directory.GetDirectories(extractionDirectory);

            foreach (string addonDirectory in addonDirectories)
            {
                string addonName = Path.GetFileName(addonDirectory);
                string gmaFilePath = Path.Combine(compressedDirectory, $"{addonName}.gma");
                string gmadArguments = $"create -folder \"{addonDirectory}\" -out \"{gmaFilePath}\"";

                string gmadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gmad.exe");

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = gmadPath,
                    Arguments = gmadArguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory // Set the working directory to the application's base directory
                };

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;

                    process.ErrorDataReceived += Process_ErrorDataReceived;
                    process.OutputDataReceived += Process_OutputDataReceived;

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    await Task.Run(() => process.WaitForExit());

                    if (process.ExitCode != 0)
                    {
                        richTextBox1.AppendText($"Failed to compress addon folder '{addonName}'." + Environment.NewLine);
                    }
                }
            }

            MessageBox.Show("Folder compression completed. Compressed .gma files are stored in the 'compressed' directory.", "Compression Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Error Handling
        private async void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                await Task.Run(() =>
                {
                    richTextBox1.Invoke((MethodInvoker)(() =>
                    {
                        richTextBox1.AppendText(e.Data + " (gmad Output)" + Environment.NewLine);
                    }));
                });
            }
        }

        private async void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                await Task.Run(() =>
                {
                    richTextBox1.Invoke((MethodInvoker)(() =>
                    {
                        richTextBox1.AppendText(e.Data + " (gmad Error)" + Environment.NewLine);
                    }));
                });
            }
        }
        #endregion

        #region Experimental

        /* 
         * This function is HIGHLY experimental and should not be used for production of content packs yet. 
         * Please understand that you should always make backups of your extracted .gmas using the Pack button before you Create your pack.
         * This feature is not entirely supported and should be considered not working properly until then.
         */
        private async void CreateContentPack()
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string binFolderPath = Path.Combine(workingDirectory, "bin");
            string sourceDirectory = Path.Combine(workingDirectory, "release");
            string targetFilePath = Path.Combine(binFolderPath, "gchcontentpack.gma");

            if (!Directory.Exists(binFolderPath))
            {
                Directory.CreateDirectory(binFolderPath);
            }

            if (File.Exists(targetFilePath))
            {
                File.Delete(targetFilePath);
            }

            string addonJsonPath = Path.Combine(sourceDirectory, "addon.json");
            if (!File.Exists(addonJsonPath))
            {
                string addonJsonContent = @"{
            ""title"": ""gch Content Pack"",
            ""type"": ""tool"",
            ""ignore"": [""*.psd""],
            ""description"": ""This content pack was created using gch."",
            ""author_name"": ""gch"",
            ""author_email"": ""gch@example.com"",
            ""author_website"": ""https://gcpo-website.com"",
            ""version"": ""1.0""
        }";

                File.WriteAllText(addonJsonPath, addonJsonContent);
            }

            string gmadPath = Path.Combine(workingDirectory, "gmad.exe");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = gmadPath,
                Arguments = $"create -folder \"{sourceDirectory}\" -out \"{targetFilePath}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = workingDirectory
            };

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;

                // Asynchronously read output and error streams
                Task<string> outputTask = process.StandardOutput.ReadToEndAsync();
                Task<string> errorTask = process.StandardError.ReadToEndAsync();

                process.Start();

                // Wait for the process to exit
                await process.WaitForExitAsync();

                string output = await outputTask;
                string error = await errorTask;

                if (process.ExitCode == 0)
                {
                    MessageBox.Show("Addon packing completed. The merged addon is stored in the 'bin' folder as 'gchcontentpack.gma'.", "Packing Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string errorMessage = "GMAD did not report an error to GCH, but there was an error. Sorry.";

                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        errorMessage += Environment.NewLine + Environment.NewLine + "Error Message:" + Environment.NewLine + error;
                    }

                    richTextBox1.Text += errorMessage;
                }
            }
        }

        // SPEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEED!
        private async void MergeAddons()
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sourceDirectory = Path.Combine(workingDirectory, "extracted");
            string targetDirectory = Path.Combine(workingDirectory, "release");

            // Create the target directory if it doesn't exist
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string[] addonDirectories = Directory.GetDirectories(sourceDirectory);

            await MergeAddonsAsync(addonDirectories, targetDirectory);
        }

        #endregion

        #region AsyncFunctions1.0

        private async Task MergeAddonsAsync(string[] addonDirectories, string targetDirectory)
        {
            // Dictionary to keep track of filenames and their occurrences
            Dictionary<string, int> filenameOccurrences = new Dictionary<string, int>();

            // Concurrently merge the addons using multiple tasks
            await Task.WhenAll(addonDirectories.Select(addonDirectory => Task.Run(() =>
            {
                string addonName = Path.GetFileName(addonDirectory);

                // Get all subdirectories within the addon directory
                string[] subdirectories = Directory.GetDirectories(addonDirectory, "*", SearchOption.AllDirectories);

                foreach (string subdirectoryPath in subdirectories)
                {
                    // Create the corresponding subdirectory in the target directory
                    string relativePath = Path.GetRelativePath(addonDirectory, subdirectoryPath);
                    string targetSubdirectoryPath = Path.Combine(targetDirectory, relativePath);

                    if (!Directory.Exists(targetSubdirectoryPath))
                    {
                        Directory.CreateDirectory(targetSubdirectoryPath);
                    }

                    // Copy files within the subdirectory
                    string[] files = Directory.GetFiles(subdirectoryPath);

                    foreach (string filePath in files)
                    {
                        string fileName = Path.GetFileName(filePath);
                        string targetFilePath = Path.Combine(targetSubdirectoryPath, fileName);

                        // Check if the file already exists in the target subfolder
                        if (File.Exists(targetFilePath))
                        {
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                            string fileExtension = Path.GetExtension(fileName);
                            int counter = 1;

                            // Generate a new filename by appending a number to the filename
                            while (File.Exists(targetFilePath))
                            {
                                string newFileName = $"{fileNameWithoutExtension}{counter}{fileExtension}";
                                targetFilePath = Path.Combine(targetSubdirectoryPath, newFileName);
                                counter++;
                            }

                            richTextBox1.AppendText($"Filename conflict found: {fileName}. Renamed to {Path.GetFileName(targetFilePath)}." + Environment.NewLine);
                        }

                        // Copy the file to the target subfolder
                        File.Copy(filePath, targetFilePath);

                        // Add the filename to the occurrences dictionary
                        lock (filenameOccurrences)
                        {
                            if (!filenameOccurrences.ContainsKey(fileName))
                            {
                                filenameOccurrences[fileName] = 1;
                            }
                            else
                            {
                                filenameOccurrences[fileName]++;
                            }
                        }
                    }
                }
            })));

            // Rename files in the target directory if conflicts occurred during merging
            foreach (KeyValuePair<string, int> kvp in filenameOccurrences)
            {
                string fileName = kvp.Key;
                int occurrenceCount = kvp.Value;

                if (occurrenceCount > 1)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    string fileExtension = Path.GetExtension(fileName);

                    for (int i = 1; i <= occurrenceCount; i++)
                    {
                        string targetFilePath = Path.Combine(targetDirectory, $"{fileNameWithoutExtension}{i}{fileExtension}");

                        if (File.Exists(targetFilePath))
                        {
                            string newFileName = $"{fileNameWithoutExtension}{i + 1}{fileExtension}";
                            string newTargetFilePath = Path.Combine(targetDirectory, newFileName);

                            File.Move(targetFilePath, newTargetFilePath);

                            richTextBox1.AppendText($"Filename conflict found: {fileNameWithoutExtension}{i}{fileExtension}. Renamed to {newFileName}.");
                        }
                    }
                }
            }

            richTextBox1.AppendText("Addon merging completed. Merged files are stored in the 'release' directory.");
            await Task.Run(() => { CreateContentPack(); });
        }
        private async Task ExtractGMAsAsync(string[] gmaFiles, string newDirectoryPath, string gmadPath)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // Create the extraction directory if it doesn't exist
            if (!Directory.Exists(newDirectoryPath))
            {
                Directory.CreateDirectory(newDirectoryPath);
            }

            // Concurrently extract the GMA files using multiple tasks
            await Task.WhenAll(gmaFiles.Select(gmaFile => Task.Run(async () =>
            {
                string extractedFolder = Path.GetFileNameWithoutExtension(gmaFile);
                string addonFolderPath = Path.Combine(newDirectoryPath, extractedFolder);

                // Create the addon folder within the "extracted" directory
                Directory.CreateDirectory(addonFolderPath);

                string addonFileName = Path.GetFileName(gmaFile);
                if (addonFileName.Equals("gmpublisher.gma", StringComparison.OrdinalIgnoreCase))
                {
                    string parentFolderName = Path.GetFileName(Path.GetDirectoryName(gmaFile));
                    addonFolderPath = Path.Combine(newDirectoryPath, parentFolderName);
                }

                string gmadArguments = $"extract -file \"{gmaFile}\" -out \"{addonFolderPath}\"";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = gmadPath,
                    Arguments = gmadArguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.ErrorDataReceived += Process_ErrorDataReceived;
                    process.OutputDataReceived += Process_OutputDataReceived;

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    await Task.Run(() => process.WaitForExit());
                }

                // Create the addon.json file within the extracted folder
                string addonJsonPath = Path.Combine(addonFolderPath, "addon.json");

                // Construct the addon.json content
                string addonJsonContent = @"{
            ""title"": ""gch Extracted Addon"",
            ""type"": ""tool"",
            ""ignore"": [""*.psd""],
            ""description"": ""This addon was extracted using gch."",
            ""author_name"": ""gch"",
            ""author_email"": ""gch@example.com"",
            ""author_website"": ""https://gcpo-website.com"",
            ""version"": ""1.0""
        }";

                File.WriteAllText(addonJsonPath, addonJsonContent);
            })));
            sw.Stop();
            richTextBox1.AppendText($"Extraction Time: {sw.Elapsed.TotalSeconds} seconds");
        }


        private async Task PackAddonsAsync(string[] addonDirectories, string compressedDirectory, string gmadPath)
        {
            // Concurrently pack the addon folders using multiple tasks
            await Task.WhenAll(addonDirectories.Select(addonDirectory => Task.Run(async () =>
            {
                string addonName = Path.GetFileName(addonDirectory);
                string gmaFilePath = Path.Combine(compressedDirectory, $"{addonName}.gma");
                string gmadArguments = $"create -folder \"{addonDirectory}\" -out \"{gmaFilePath}\"";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = gmadPath,
                    Arguments = gmadArguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
                };

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.ErrorDataReceived += Process_ErrorDataReceived;
                    process.OutputDataReceived += Process_OutputDataReceived;

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    await Task.Run(() => process.WaitForExit());

                    if (process.ExitCode != 0)
                    {
                        richTextBox1.AppendText($"Failed to compress addon folder '{addonName}'." + Environment.NewLine);
                    }
                }
            })));
        }


        private async void button4_Click(object sender, EventArgs e)
        {
            // This is rough, however MergeAddons takes a very long time and I'd like to debug other things while it runs.
            await Task.Run(() => { MergeAddons(); });
        }

        #endregion

        #region IDontRememberWhatR4
        private void expirementalFeaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to enable this? It could break the entire application.", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                expirementalFeaturesToolStripMenuItem.Checked = true;
                button4.Enabled = true;
                button4.BackColor = Color.White;
            }
            else
            {
                return;
            }
        }


        #endregion

        private void label5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }
    }
}