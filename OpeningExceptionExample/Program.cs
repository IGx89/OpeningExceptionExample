using ServiceReference1;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace OpeningExceptionExample
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Calling SOAP service...");

            var client = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);

            ((ICommunicationObject)client).Opening += (sender, a) => throw new Exception("Triggering Faulted state");

            await client.AddAsync(1, 1);

            Console.WriteLine("Succeeded");
        }
    }
}
