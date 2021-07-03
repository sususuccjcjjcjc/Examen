using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Transport
    {
        public int dostavka { get; set; }
        public int znachenie { get; set; }
        public static int MinEl(int a, int b)
        {
            if (a > b) return b;
            if (a == b) { return a; }
            else return a;
        }
    }
}
