using System;
using CryptTrackerClient.ServiceReference1;


namespace CryptTrackerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the WCF proxy.
            Service1Client client = new Service1Client();

            // Call the service operations.
            // Call the Parse service operation.
            Console.Write("Enter get(Token): ");
            string input = Console.ReadLine();

            string output = client.Parse(input);
            Console.WriteLine("Parse{0}", output);

       
            // Close the client to gracefully close the connection and clean up resources.
            Console.WriteLine("\nPress <Enter> to terminate the client.");
            Console.ReadLine();
            client.Close();
        }
    }
}