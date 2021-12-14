// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text;

string orgLink = args[0];
if(orgLink != null)
{
    orgLink = orgLink.Replace("org-protocol://capture/", "org-protocol://capture");
    byte[] bytes = Encoding.UTF8.GetBytes(orgLink);
    //Task logTask = File.WriteAllBytesAsync("C:\\Users\\kalle\\Org Capture.log", bytes);
    orgLink = Encoding.Latin1.GetString(bytes);
    Task logTask = File.WriteAllTextAsync("C:\\Users\\kalle\\Org Capture.log", orgLink);

    string emacsClient = @"C:\Users\kalle\scoop\shims\emacsclientw.exe";

    // Process.Start(emacsClient, orgLink);

    ProcessStartInfo processStartInfo = new ProcessStartInfo();

    processStartInfo.CreateNoWindow = true;
    processStartInfo.UseShellExecute = false;
    processStartInfo.FileName = emacsClient;
    processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    string arguments = "-n " + orgLink;
    processStartInfo.Arguments = arguments;
        
    Process? exeProcess = Process.Start(processStartInfo);
    if (exeProcess != null)
    {
        exeProcess.WaitForExit();
    }
    logTask.Wait();
}

