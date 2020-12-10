using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using CryptTrackerLib;

namespace CryptTrackerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8733/Design_Time_Addresses/CryptTrackerLib/Service1/");

            // Create a ServiceHost instance.
            ServiceHost selfHost = new ServiceHost(typeof(Service1), baseAddress);

            try
            {
                // Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(IService1), new WSHttpBinding(), "CalculatorService");

                // Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");

                // Close the ServiceHost to stop the service.
                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}