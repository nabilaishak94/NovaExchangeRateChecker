using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace NovaExchangeRateChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Controller con = new Controller();
                con.init();
                Console.ReadLine();



                //ServiceBase[] ServicesToRun;
                //ServicesToRun = new ServiceBase[] { new NovaExchangeRateChecker() };
                //ServiceBase.Run(ServicesToRun);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
