using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ICall
    {
        public string Call();

        public string Number { get; set; }

    }
}
