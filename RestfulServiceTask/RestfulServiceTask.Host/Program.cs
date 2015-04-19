using System;
using System.ServiceModel.Web;

namespace RestfulServiceTask.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebServiceHost(typeof(MagazineService.MagazineService));
            host.Open();
           
            Console.WriteLine("START");
            Console.ReadLine();
            
            host.Close();
        }
    }
}
