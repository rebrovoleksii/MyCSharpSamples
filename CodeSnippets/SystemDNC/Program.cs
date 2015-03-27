using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SystemDNC
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ipHostInfo = Dns.GetHostEntry("localhost");
            //var ipAddress = ipHostInfo.AddressList.SingleOrDefault<IPAddress>(addr => addr.AddressFamily.Equals(AddressFamily.InterNetwork));
            //Console.WriteLine(ipAddress);
            //Console.ReadLine();

            var proc = Process.GetProcessesByName("chromedriver").SingleOrDefault();
            proc.Kill();
            Console.ReadLine();
            
        }
    }
}
