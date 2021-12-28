using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;
using Microsoft.Win32;

namespace FichaTecnicaServer
{
    class Program
    {
        static void Main(string[] args)
        {

            SystemInfo si = new SystemInfo();       //Create an object of SystemInfo class.
            si.getOperatingSystemInfo();            //Call get operating system info method which will display operating system information.
            si.getDiskDriveInfo();
            si.getProcessorInfo();                  //Call get  processor info method which will display processor info.
            Console.ReadLine();

            /* Process cmd = new Process();
             cmd.StartInfo.FileName = "cmd.exe";
             cmd.StartInfo.RedirectStandardInput = true;
             cmd.StartInfo.RedirectStandardOutput = true;
             cmd.StartInfo.CreateNoWindow = true;
             cmd.StartInfo.UseShellExecute = false;
             cmd.Start();

             cmd.StandardInput.WriteLine("systeminfo");
             cmd.StandardInput.Flush();
             cmd.StandardInput.Close();
             cmd.WaitForExit();
             var x = cmd.StandardOutput.ReadToEnd();
             Console.WriteLine(x);
            */
            Console.ReadLine();



        }

        public class SystemInfo
        {
            public void getOperatingSystemInfo()
            {
                Console.WriteLine("Displaying operating system info....\n");
                //Create an object of ManagementObjectSearcher class and pass query as parameter.
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                foreach (ManagementObject managementObject in mos.Get())
                {
                    foreach (var algo in managementObject.Properties) {
                        Console.WriteLine($"Name: {algo.Name}    Value: {algo.Value}");
                    }
                    /*
                    if (managementObject["Caption"] != null)
                    {
                        Console.WriteLine("Operating System Name  :  " + managementObject["Caption"].ToString());   //Display operating system caption
                    }
                    if (managementObject["OSArchitecture"] != null)
                    {
                        Console.WriteLine("Operating System Architecture  :  " + managementObject["OSArchitecture"].ToString());   //Display operating system architecture.
                    }
                    if (managementObject["CSDVersion"] != null)
                    {
                        Console.WriteLine("Operating System Service Pack   :  " + managementObject["CSDVersion"].ToString());     //Display operating system version.
                    }*/
                }
            }

            public void getDiskDriveInfo()
            {
                Console.WriteLine("Displaying operating system info....\n");
                //Create an object of ManagementObjectSearcher class and pass query as parameter.
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_DiskDrive");
                foreach (ManagementObject managementObject in mos.Get())
                {
                    foreach (var algo in managementObject.Properties)
                    {
                        Console.WriteLine($"Name: {algo.Name}    Value: {algo.Value}");
                    }
                    
                }
            }

            public void getProcessorInfo()
            {
                Console.WriteLine("\n\nDisplaying Processor Name....");
                RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

                if (processor_name != null)
                {
                    if (processor_name.GetValue("ProcessorNameString") != null)
                    {
                        Console.WriteLine(processor_name.GetValue("ProcessorNameString"));   //Display processor ingo.
                    }
                }
            }

            public void getSystemDevices()
            {
                Console.WriteLine("\n\nDisplaying Devices Name...");
                RegistryKey Devices_name = Registry.LocalMachine.OpenSubKey("@")


            }

        }
    }
}