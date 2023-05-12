using System.Diagnostics;

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
            /*
             * GCH (Gmod Content Helper)
             * 
             * Note: This tool is meant to be used in conjunction with GAC (Gmod Addon Compressor) and does not perform addon compression itself.
             * GCH provides various utilities and functions to assist in the process of preparing addons for compression with GAC.
             * 
             * Developer's Note: Please be aware that this tool does not support on-load functions and code. The project developer has intentionally excluded support for on-load functionality to ensure compatibility and reliability with GAC and its compression process.
             * 
             * Usage:
             * 1. Prepare your addon files by organizing and optimizing them using GCH.
             * 2. Once your addons are ready, use GAC to compress them into the final format.
             * 
             * For more information and documentation, please refer to the GCH GitHub repository: 
             * 
             * If you have any questions or encounter issues, please feel free to open an issue on the repository or reach out to the project developer.
             * 
             * Happy compressing!
             */
        }
        private string targetDirectory;
        private string extractionDirectory;
        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    targetDirectory = folderDialog.SelectedPath;
                    string[] files = Directory.GetFiles(targetDirectory, "*.gma");

                    richTextBox1.Clear();

                    foreach (string file in files)
                    {
                        richTextBox1.AppendText(file + Environment.NewLine);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(targetDirectory))
            {
                string gmadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gmad.exe");
                string[] gmaFiles = Directory.GetFiles(targetDirectory, "*.gma");

                string exeLocation = AppDomain.CurrentDomain.BaseDirectory;
                string directoryName = "final";

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

                    // Create the addon folder within the "final" directory
                    Directory.CreateDirectory(addonFolderPath);

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

                        /* This is for debugging errors in GMAD, not GCPO
                            -- process.ErrorDataReceived += Process_ErrorDataReceived;
                            -- process.OutputDataReceived += Process_OutputDataReceived;
                        */
                        process.Start();
                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();

                        process.WaitForExit();
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
                }

                MessageBox.Show("File processing completed. Extracted files are stored in the 'final' directory.", "Extraction Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a target directory first.", "Directory Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string extractionDirectory = Path.Combine(workingDirectory, "final");
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
                    /* This is for debugging errors in GMAD, not GCPO
                        -- process.ErrorDataReceived += Process_ErrorDataReceived;
                        -- process.OutputDataReceived += Process_OutputDataReceived;
                    */
                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        MessageBox.Show($"Failed to compress addon folder '{addonName}'.", "Compression Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            MessageBox.Show("Folder compression completed. Compressed .gma files are stored in the 'compressed' directory.", "Compression Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                MessageBox.Show(e.Data, "gmad Output", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                MessageBox.Show(e.Data, "gmad Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}