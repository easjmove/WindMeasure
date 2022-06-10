using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WindMeasureUDPBroadcast
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UDP Broadcast");

            UdpClient socket = new UdpClient();
            WindDataGenerator generator = new WindDataGenerator();

            while (true)
            {
                string direction = generator.NextDirection();
                SendMessage(socket, generator.NextDirection(), generator.NextSpeed());
                Thread.Sleep(2000);
            }
        }

        public static void SendMessage(UdpClient socket, string windDirection, int windSpeed)
        {
            string message = windDirection + " " + windSpeed;
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            socket.Send(messageBytes, messageBytes.Length, "255.255.255.255", 7499);
        }
    }
}
