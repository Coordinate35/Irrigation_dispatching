using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irrigation_dispatching.Config
{
    public static class Security
    {
        private static int passwdSaltLength = 255;
        private static int passwdEncryptIterationCount = 1000;

        public static int PasswdSaltLenght
        {
            get
            {
                return passwdSaltLength;
            }
        }

        public static int PasswdEncryptIterationCount
        {
            get
            {
                return passwdEncryptIterationCount;
            }
        }
    }
}
