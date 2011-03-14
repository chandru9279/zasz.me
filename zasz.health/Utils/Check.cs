using System;

namespace zasz.health.Utils
{
    class Check
    {
        private static int _CheckPoint = 0;
        public static void Point()
        {
            Console.WriteLine(++_CheckPoint);
        }
    }
}
