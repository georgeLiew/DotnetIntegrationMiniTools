using MiniTools;
using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"StatCode: 00
                            StatName: captured
                            TranID: 35540257
                            Amount: 12.00
                            Domain: Payment.com.my
                            Channel: ALB-Paymex
                            VrfKey: ded0adf6fcbfa6bcaccf465750f9f61a
                            Currency: MYR
                            ErrorCode: 
                            ErrorDesc: ";



            GatewayResult gatewayResult = PlainTextToClassObjectConverter.ConvertPlainTextToClass<GatewayResult>(input);

            Console.WriteLine("Finsih");
        }
    }

    public class GatewayResult
    {
        public string StatCode { get; set; }
        public string StatName { get; set; }
        public string TranID { get; set; }
        public decimal Amount { get; set; }
        public string Domain { get; set; }
        public string Channel { get; set; }
        public string VrfKey { get; set; }
        public string Currency { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
    }
}
