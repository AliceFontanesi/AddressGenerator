using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipv4
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressGenerator ip;
            try
            {
                ip = new AddressGenerator("10000000111111110000000000000010", 24);
                Console.WriteLine(ip.generateIPv4());
                Console.WriteLine(ip.generateSubnet());
            }
            catch (Exception ms)
            {
                Console.WriteLine(ms.Message);
            }
            Console.ReadLine();
        }
    }
}
