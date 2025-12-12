using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BankServer
{
    class Program
    {
        const int PORT = 8888;

        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, PORT);
                server.Start();

                Console.WriteLine($"Bank Server started on port {PORT}...");
                Console.WriteLine("Waiting for requests from 'Personal Accounting'...");

                while (true)
                {
                    using (TcpClient client = server.AcceptTcpClient())
                    using (NetworkStream stream = client.GetStream())
                    {
                        Console.WriteLine("Client connected!");

                        byte[] buffer = new byte[256];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        Console.WriteLine($"Data received: {data}");

                        string response = CalculateDeposit(data);

                        byte[] responseData = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseData, 0, responseData.Length);

                        Console.WriteLine($"Result sent: {response}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                server?.Stop();
            }
        }

        static string CalculateDeposit(string input)
        {
            try
            {
                string[] parts = input.Split('|');
                decimal principal = decimal.Parse(parts[0]);
                double rate = double.Parse(parts[1]);
                int months = int.Parse(parts[2]);

                decimal profit = principal * (decimal)(rate / 100) * months / 12;
                decimal total = principal + profit;

                return $"{total:F2}";
            }
            catch
            {
                return "Error";
            }
        }
    }
}