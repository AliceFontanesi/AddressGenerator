﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipv4
{
    interface IAddress
    {
        string generateIPv4();
        string generateSubnet();
    }
}
