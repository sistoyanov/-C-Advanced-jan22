using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IBrowse
    {
        public string Browse();

        public string Url { get; set; }
    }
}
