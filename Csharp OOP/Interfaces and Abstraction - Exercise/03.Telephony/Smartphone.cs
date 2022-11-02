using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        private string number;
        private string url;

        public string Number
        {
            get => this.number;
            set
            {

                if (value.Any(char.IsLetter))
                {
                    throw new ArgumentException(String.Format(ExeptionMessages.InvalidNumberMessage));
                }

                this.number = value;
            }
        }

        public string Url 
        {
            get => this.url;
            set
            {
                if (value.Any(char.IsDigit))
                {
                    throw new ArgumentException(String.Format(ExeptionMessages.InvalidUrlMessage));
                }

                this.url = value;
            } 
        }

        public string Browse()
        {
            return $"Browsing: {this.url}!";
        }

        public string Call()
        {
            return $"Calling... {this.number}";
        }
    }
}
