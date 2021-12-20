using ServiceReservasi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ServerReservasi_20190140022
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:8733/Design_Time_Addresses/ServiceReservasi/Service1/");
            BasicHttpBinding bind = new BasicHttpBinding();
            try
            {
                hostObj = new ServiceHost(typeof(Service1), address);
                //alamat base address
                hostObj.AddServiceEndpoint(typeof(IService1), bind, "");
                //alamat endpoint
                //wsdl
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior(); //service Runtime Player
                smb.HttpGetEnabled = true; //untuk mengaktifkan wsdl (dinuka saat development, tidak untuk dibuka)
                hostObj.Description.Behaviors.Add(smb);
                //mex
                Binding mexbind = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange), mexbind, "mex");
                hostObj.Open();
                Console.WriteLine("Server is ready!!!");
                Console.ReadLine();

                hostObj.Close();
            }
            catch (Exception ex)
            {
                hostObj = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
