// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Task logTask = File.WriteAllLinesAsync("C:\\Users\\kalle\\Org Capture.log", args);
string orgLink = args[0];

orgLink = orgLink.Replace("org-protocol://capture/", "org-protocol://capture");

string emacsClient = @"C:\Users\kalle\scoop\shims\emacsclientw.exe";

// Process.Start(emacsClient, orgLink);

ProcessStartInfo processStartInfo = new ProcessStartInfo();

processStartInfo.CreateNoWindow = true;
processStartInfo.UseShellExecute = false;
processStartInfo.FileName = emacsClient;
processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
processStartInfo.Arguments = "-n " + orgLink;

Process? exeProcess = Process.Start(processStartInfo);
if(exeProcess != null)
{
    exeProcess.WaitForExit();
}

logTask.Wait();
