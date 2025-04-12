using System;
using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;

namespace UpmAuto
{
    public class GitBashInterface
    {
        public void Execute(string command)
        {
            Bash(command);
        }


        private void Bash(string command)
        {
            try
            {
                using Process gitProcess = new Process();
                gitProcess.StartInfo.FileName = UpmAutoConfigs.gitBashExe;
                gitProcess.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();

                gitProcess.StartInfo.Arguments = $"-c \"{command}\"";

                Debug.Log(gitProcess.StartInfo.Arguments);
                gitProcess.StartInfo.UseShellExecute = false;
                gitProcess.StartInfo.RedirectStandardOutput = true;
                gitProcess.StartInfo.RedirectStandardError = true;
                gitProcess.StartInfo.CreateNoWindow = true;

                gitProcess.Start();
                gitProcess.WaitForExit();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error from bash: {e}");
                throw;
            }
        }
    }
}