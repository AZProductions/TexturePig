using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexturePig.MineClient
{
    internal enum VersionType
    {
        /*  
            1 for versions 1.6.1 – 1.8.9
            2 for versions 1.9 – 1.10.2
            3 for versions 1.11 – 1.12.2
            4 for versions 1.13 – 1.14.4
            5 for versions 1.15 – 1.16.1
            6 for versions 1.16.2 – 1.16.5
            7 for versions 1.17.x
            8 for versions 1.18.x
        */

        v161to189 = 1,
        v190to1102 = 2,
        v111to1122 = 3,
        v1130to1144 = 4,
        v115to1161 = 5,
        v1162to1165 = 6,
        v117x = 7,
        v118x = 8
    }
}
