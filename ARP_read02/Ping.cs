using System.Net.NetworkInformation;
namespace ARP_read02
{
    class Pinger
    {
        public static void PingUp()
        {
            // get the IPs from the database so you can iterate over them
            System.Collections.Generic.List<string> ips = new System.Collections.Generic.List<string>();


            for (int i = 100; i < 100 + Form1.max_ip; i++)
            {
                ips.Add("192.168.1." + i);
            }

            foreach (var ip in ips)
            {
                // See http://stackoverflow.com/questions/4744630/unexpected-behaviour-for-threadpool-queueuserworkitem
                // for reason to use another variable in the loop
                string loopIp = ip;
                System.Threading.WaitCallback func = delegate (object state)
                {

                    if (PingIP(loopIp))
                    {
                        System.Console.WriteLine("Ping Success");
                    }
                    else
                    {
                        System.Console.WriteLine("Ping Failed");
                    }
                };
                System.Threading.ThreadPool.QueueUserWorkItem(func);
            }

        }



        public static bool PingIP(string IP)
        {
            bool result = false;
            try
            {
                Ping ping = new Ping();
                System.Net.NetworkInformation.PingReply pingReply = ping.Send(IP);

                if (pingReply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

    }
}
//http://stackoverflow.com/questions/8025532/the-fastest-way-to-ping-a-large-list-of-ip-adresses