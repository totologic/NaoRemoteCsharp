using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaoRemote;
using LitJson;

namespace ConsoleApplication1
{
    class Program
    {
        private static bool alive = true;

        static void Main(String[] args)
        {
            
            Console.WriteLine("GO");
            Nao n = new Nao();
            //n.connect("169.254.30.101");
            n.Connect("127.0.0.1");

            System.Threading.Thread.Sleep(1000);
            List<double> list = n.ALMotion.GetAngles("Body", true);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            n.Eval<List<double>>("ALMotion", false, "getAngles", "Body" );
            n.SubscribeToEvent("FrontTactilTouched", onEvent);

            System.Threading.Thread.Sleep(10000);

            n.UnsubscribeToEvent("FrontTactilTouched", onEvent);

            n.Disconnect();
            
            System.Threading.Thread.Sleep(1000);
        }

        public static void onEvent(String name, NaoEventData value)
        {
            double data = value.Extract<double>();
            Console.WriteLine("onEvent:");
            Console.WriteLine("    name -> " + name);
            Console.WriteLine("    value -> " + data);
            
        }

    }
}
