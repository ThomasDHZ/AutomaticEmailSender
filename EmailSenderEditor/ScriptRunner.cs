using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSenderEditor
{
    public static class ScriptRunner
    {
        public static void RunEmailScript(string pythonExePath, string pythonScriptPath, string scriptArguments, bool silentSuccess = false)
        {
            try
            {
                if (!File.Exists(pythonExePath))
                {
                    MessageBox.Show("script.exe not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = pythonExePath,
                    Arguments = $@"{scriptArguments}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = Path.GetDirectoryName(pythonExePath)
                };

                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(output) &&
                        !silentSuccess)
                    {
                        MessageBox.Show("Output: " + output, "Python Script Output");
                    }
                        
                    if (!string.IsNullOrEmpty(error))
                        MessageBox.Show("Error: " + error, "Python Script Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
