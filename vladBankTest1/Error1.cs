using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vladBankTest1
{
    internal class Error1:Exception
    {
        public Error1(string ErrorMsg)
            : base(ErrorMsg)
        {

        }
    }
}
