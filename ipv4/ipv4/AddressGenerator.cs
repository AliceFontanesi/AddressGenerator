using System;

namespace ipv4
{
    class AddressGenerator : IAddress
    {
        int[,] ipAddress;
        int cidr;

        public AddressGenerator(string bits)
        {
            if (VeirifyIp(bits))
            {
                ipAddress = new int[4, 8];
                for (int i = 0; i < ipAddress.Length; i++)
                    ipAddress[i / 8, i % 8] = Convert.ToInt32(bits[i].ToString());
            }
            else
                throw new Exception("Formato bits non valido");
        }

        public AddressGenerator(string bits, int cidr)
        {
            if (VeirifyIp(bits))
            {
                ipAddress = new int[4, 8];
                for (int i = 0; i < ipAddress.Length; i++)
                    ipAddress[i / 8, i % 8] = Convert.ToInt32(bits[i].ToString());
            }
            else
                throw new Exception("Formato bits non valido");

            if (cidr < 1 || cidr > 31)
                throw new Exception("Cidr non valido");
            else
                this.cidr = cidr;
        }

        public string generateIPv4()
        {
            double tmp = 0;
            string ip = "";

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                    tmp += Math.Pow(2, j) * ipAddress[i, 7 - j];
                if (i != 3)
                    ip += tmp.ToString() + '.';
                else
                    ip += tmp.ToString();
                tmp = 0;
            }
            return ip;
        }
        public string generateSubnet()
        {
            string sub = "";
            double tmp = 0;
            int i;
            int[,] subnet = new int[4, 8];

            if (cidr != 0)
            {
                for (i = 0; i < cidr; i++) subnet[i / 8, i % 8] = 1;
                for (int j = i + 1; j < 32; j++) subnet[i / 8, i % 8] = 0;

                for (int k = 0; k < 4; k++)
                {
                    for (int j = 0; j < 8; j++)
                        tmp += Math.Pow(2, j) * subnet[k, 7 - j];
                    if (k != 3)
                        sub += tmp.ToString() + '.';
                    else
                        sub += tmp.ToString();
                    tmp = 0;
                }
            }
            else
                throw new Exception("Cidr non valido");
            return sub;
        }

        private bool VeirifyIp(string bits)
        {
            if (bits.Length != 32)
                return false;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] != '1' && bits[i] != '0')
                    return false;
            }
            return true;
        }
    }
}
