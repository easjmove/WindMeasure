using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;

namespace WindMeasureUDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UDP Server");

            using (UdpClient socket = new UdpClient())
            {
                socket.Client.Bind(new IPEndPoint(IPAddress.Any, 7499));
                while (true)
                {
                    IPEndPoint from = null;
                    byte[] messageBytes = socket.Receive(ref from);
                    Console.WriteLine(HandleMessage(messageBytes));
                }
            }
        }

        public static string HandleMessage(byte[] messageBytes)
        {
            string message = Encoding.UTF8.GetString(messageBytes);
            string[] splitMessage = message.Split(" ");
            if (splitMessage.Length == 2)
            {
                string windDirection = splitMessage[0];
                int windSpeed = int.Parse(splitMessage[1]);

                using (HttpClient client = new HttpClient())
                {
                    WindMeasureData newData = new WindMeasureData() { WindDirection = windDirection, WindSpeed = windSpeed };
                    HttpContent content = JsonContent.Create<WindMeasureData>(newData);
                    _ = client.PostAsync("http://localhost:50927/api/WindMeasure", content).Result;
                }

                return $"WindDirection:{windDirection} \r\nWindSpeed: {windSpeed}";
            }
            else
            {
                return "Message not understood!";
            }
        }
    }
}
